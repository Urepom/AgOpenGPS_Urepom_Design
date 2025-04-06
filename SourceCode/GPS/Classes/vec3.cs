﻿//Please, if you use this, share the improvements

using System;

namespace AgOpenGPS
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    ///

    public struct vec3
    {
        public double easting;
        public double northing;
        public double heading;
        public DateTime now; //ajout memprou


        public vec3(double easting, double northing, double heading)
        {
            this.easting = easting;
            this.northing = northing;
            this.heading = heading;
            this.now = DateTime.Now; //ajout max

        }

        public vec3(vec3 v)
        {
            easting = v.easting;
            northing = v.northing;
            heading = v.heading;
            now = v.now; //ajout max

        }

    }

    public struct vecFix2Fix
    {
        public double easting; //easting
        public double distance; //distance since last point
        public double northing; //norting
        public int isSet;    //altitude

        public vecFix2Fix(double _easting, double _northing, double _distance, int _isSet)
        {
            this.easting = _easting;
            this.distance = _distance;
            this.northing = _northing;
            this.isSet = _isSet;
        }
    }

    public struct vec2
    {
        public double easting; //easting
        public double northing; //northing

        public vec2(double easting, double northing)
        {
            this.easting = easting;
            this.northing = northing;
        }

        public vec2(vec2 v)
        {
            easting = v.easting;
            northing = v.northing;
        }



        public static vec2 operator -(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.easting - rhs.easting, lhs.northing - rhs.northing);
        }

        //calculate the heading of dirction pointx to pointz
        public double HeadingXZ()
        {
            return Math.Atan2(easting, northing);
        }

        //normalize to 1
        public vec2 Normalize()
        {
            double length = GetLength();
            if (Math.Abs(length) < 0.000000000001)
            {
                throw new DivideByZeroException("Trying to normalize a vector with length of zero.");
            }

            return new vec2(easting /= length, northing /= length);
        }

        //Returns the length of the vector
        public double GetLength()
        {
            return Math.Sqrt((easting * easting) + (northing * northing));
        }

        // Calculates the squared length of the vector.
        public double GetLengthSquared()
        {
            return (easting * easting) + (northing * northing);
        }

        //scalar double
        public static vec2 operator *(vec2 self, double s)
        {
            return new vec2(self.easting * s, self.northing * s);
        }

        //add 2 vectors
        public static vec2 operator +(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.easting + rhs.easting, lhs.northing + rhs.northing);
        }
    }

}
