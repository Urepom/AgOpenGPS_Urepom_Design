using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    /// <summary>
    /// This class helps converting a Curve to the CABCurve format.
    /// We use this class temporarily until we decouple the CABCurve functionality from the UI.
    /// </summary>
    public static class CurveCABTools
    {
        // Full pipeline: minimum spacing -> interpolate -> headings
        public static List<vec3> Preprocess(List<vec3> points, double minSpacing, double interpolationSpacing)
        {
            points = MakePointMinimumSpacing(points, minSpacing);
            points = InterpolatePoints(points, interpolationSpacing);
            points = CalculateHeadings(points);
            return points;
        }

        // Step 1: Ensure minimum spacing between points
        private static List<vec3> MakePointMinimumSpacing(List<vec3> points, double minSpacing)
        {
            if (points == null || points.Count < 2) return points;

            var spaced = new List<vec3>(points.Count);
            vec3 last = points[0];
            spaced.Add(last);

            double minSq = minSpacing * minSpacing;

            for (int i = 1; i < points.Count; i++)
            {
                double dx = points[i].easting - last.easting;
                double dy = points[i].northing - last.northing;
                if ((dx * dx + dy * dy) >= minSq)
                {
                    spaced.Add(points[i]);
                    last = points[i];
                }
            }

            // Always add the original last point
            vec3 final = points[points.Count - 1];
            vec3 compare = spaced[spaced.Count - 1];
            if (glm.DistanceSquared(final, compare) > 1e-10)
                spaced.Add(final);

            return spaced;
        }

        // Step 2: Interpolate points at fixed spacing
        private static List<vec3> InterpolatePoints(List<vec3> points, double spacingMeters)
        {
            if (points == null || points.Count < 2) return points;

            var result = new List<vec3>(points.Count * 2);

            for (int i = 0; i < points.Count - 1; i++)
            {
                vec3 a = points[i];
                vec3 b = points[i + 1];
                result.Add(a);

                double dx = b.easting - a.easting;
                double dy = b.northing - a.northing;
                double distance = Math.Sqrt(dx * dx + dy * dy);

                int steps = (int)(distance / spacingMeters);
                for (int j = 1; j < steps; j++)
                {
                    double t = (double)j / steps;
                    double x = a.easting + dx * t;
                    double y = a.northing + dy * t;
                    result.Add(new vec3(x, y, 0));
                }
            }

            result.Add(points[points.Count - 1]);
            return result;
        }

        // Step 3: Calculate headings
        public static List<vec3> CalculateHeadings(List<vec3> points)
        {
            if (points == null || points.Count < 2) return points;

            for (int i = 0; i < points.Count - 1; i++)
            {
                double dx = points[i + 1].easting - points[i].easting;
                double dy = points[i + 1].northing - points[i].northing;
                var pt = points[i];
                pt.heading = Math.Atan2(dx, dy);
                if (pt.heading < 0) pt.heading += glm.twoPI;
                points[i] = pt;
            }

            // Copy last heading from the second last
            var last = points[points.Count - 1];
            last.heading = points[points.Count - 2].heading;
            points[points.Count - 1] = last;

            return points;
        }

        // Step 4: Compute circular mean heading
        public static double ComputeAverageHeading(List<vec3> points)
        {
            if (points == null || points.Count == 0) return 0;

            double cx = 0, sy = 0;
            for (int i = 0; i < points.Count; i++)
            {
                cx += Math.Cos(points[i].heading);
                sy += Math.Sin(points[i].heading);
            }
            cx /= points.Count;
            sy /= points.Count;

            double avg = Math.Atan2(sy, cx);
            if (avg < 0) avg += glm.twoPI;
            return avg;
        }
    }
}
