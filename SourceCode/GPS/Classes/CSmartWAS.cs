//Please, if you use this, share the improvements

using AgLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgOpenGPS
{
    /// <summary>
    /// Smart WAS Calibration - Collects and analyzes steering angle data during guidance
    /// to determine the optimal WAS zero point using statistical analysis
    /// </summary>
    public class CSmartWAS
    {
        private readonly FormGPS mf;

        // Data collection settings
        private const int MAX_SAMPLES = 2000;
        private const int MIN_SAMPLES = 200;
        private const double MIN_SPEED_KMH = 2.0;
        private const double MAX_ANGLE_DEG = 15.0;
        private const double MAX_DIST_OFF_MM = 500.0;

        // Collected data
        private readonly List<double> steerAngleHistory = new List<double>();
        private readonly object dataLock = new object();

        // Analysis results
        private double meanAngle;
        private double medianAngle;
        private double stdDeviation;
        private double recommendedOffset;
        private double confidenceLevel;
        private bool hasValidCalibration;

        #region Properties

        public bool IsCollecting { get; private set; }
        public int SampleCount => steerAngleHistory.Count;
        public double RecommendedOffset => recommendedOffset;
        public double Confidence => confidenceLevel;
        public bool HasValidCalibration => hasValidCalibration;
        public double Mean => meanAngle;
        public double Median => medianAngle;
        public double StdDev => stdDeviation;

        #endregion

        public CSmartWAS(FormGPS callingForm)
        {
            mf = callingForm;
            Reset();
        }

        /// <summary>
        /// Start collecting steering angle samples during autosteer operation
        /// </summary>
        public void Start()
        {
            lock (dataLock)
            {
                IsCollecting = true;
                Log.EventWriter("Smart WAS: Data collection started");
            }
        }

        /// <summary>
        /// Stop collecting samples and analyze the data
        /// </summary>
        public void Stop()
        {
            lock (dataLock)
            {
                IsCollecting = false;
                Log.EventWriter($"Smart WAS: Collection stopped, {SampleCount} samples collected");
            }
        }

        /// <summary>
        /// Clear all collected data and reset analysis
        /// </summary>
        public void Reset()
        {
            lock (dataLock)
            {
                steerAngleHistory.Clear();
                meanAngle = 0;
                medianAngle = 0;
                stdDeviation = 0;
                recommendedOffset = 0;
                confidenceLevel = 0;
                hasValidCalibration = false;
            }
        }

        /// <summary>
        /// Adjust collected data after applying WAS offset to prevent double-correction
        /// </summary>
        public void ApplyOffsetCorrection(double offsetDegrees)
        {
            lock (dataLock)
            {
                if (steerAngleHistory.Count == 0) return;

                for (int i = 0; i < steerAngleHistory.Count; i++)
                {
                    steerAngleHistory[i] += offsetDegrees;
                }

                AnalyzeData();
                Log.EventWriter($"Smart WAS: Applied {offsetDegrees:F2}° correction to {steerAngleHistory.Count} samples");
            }
        }

        /// <summary>
        /// Add a steering angle sample during autosteer operation
        /// Called from main GPS loop
        /// </summary>
        public void AddSample(double steerAngleDegrees)
        {
            // Check collection conditions
            if (!IsCollecting) return;
            if (!mf.isBtnAutoSteerOn) return;
            if (mf.avgSpeed < MIN_SPEED_KMH) return;
            if (Math.Abs(mf.guidanceLineDistanceOff) > MAX_DIST_OFF_MM) return;
            if (Math.Abs(steerAngleDegrees) > MAX_ANGLE_DEG) return;

            // Normalize for WAS inversion: inverted WAS flips the required correction direction
            bool wasInverted = (Properties.VehicleSettings.Default.setArdSteer_setting0 & 1) != 0;
            if (wasInverted) steerAngleDegrees = -steerAngleDegrees;

            lock (dataLock)
            {
                steerAngleHistory.Add(steerAngleDegrees);

                // Keep buffer size limited
                if (steerAngleHistory.Count > MAX_SAMPLES)
                {
                    steerAngleHistory.RemoveAt(0);
                }

                // Run analysis periodically
                if (steerAngleHistory.Count >= MIN_SAMPLES)
                {
                    AnalyzeData();
                }
            }
        }

        /// <summary>
        /// Get recommended WAS offset in counts based on current CPD setting
        /// </summary>
        public int GetOffsetCounts(int countsPerDegree)
        {
            if (!hasValidCalibration) return 0;
            return (int)Math.Round(recommendedOffset * countsPerDegree);
        }

        /// <summary>
        /// Perform statistical analysis on collected data
        /// </summary>
        private void AnalyzeData()
        {
            if (steerAngleHistory.Count < MIN_SAMPLES)
            {
                hasValidCalibration = false;
                return;
            }

            try
            {
                // Calculate statistics
                CalculateStatistics();

                // Recommended offset is negative of median
                // (if median is -2.3°, we need +2.3° correction)
                recommendedOffset = -medianAngle;

                // Calculate confidence score
                confidenceLevel = CalculateConfidence();

                // Valid if confidence is reasonable and offset is within safe range
                hasValidCalibration = confidenceLevel > 40 &&
                                    Math.Abs(recommendedOffset) < 10.0;
            }
            catch (Exception ex)
            {
                Log.EventWriter($"Smart WAS Analysis Error: {ex.Message}");
                hasValidCalibration = false;
            }
        }

        /// <summary>
        /// Calculate mean, median, and standard deviation
        /// </summary>
        private void CalculateStatistics()
        {
            int count = steerAngleHistory.Count;

            // Mean
            meanAngle = steerAngleHistory.Average();

            // Median
            var sorted = steerAngleHistory.OrderBy(x => x).ToList();
            if (count % 2 == 0)
            {
                medianAngle = (sorted[count / 2 - 1] + sorted[count / 2]) * 0.5;
            }
            else
            {
                medianAngle = sorted[count / 2];
            }

            // Standard Deviation (sample)
            if (count > 1)
            {
                double sumSquares = steerAngleHistory.Sum(x => (x - meanAngle) * (x - meanAngle));
                stdDeviation = Math.Sqrt(sumSquares / (count - 1));
            }
            else
            {
                stdDeviation = 0;
            }
        }

        /// <summary>
        /// Calculate confidence level based on data quality
        /// </summary>
        private double CalculateConfidence()
        {
            if (steerAngleHistory.Count < MIN_SAMPLES) return 0;

            // Count samples within standard deviations
            int within1Std = 0;
            int within2Std = 0;

            foreach (double angle in steerAngleHistory)
            {
                double deviation = Math.Abs(angle - medianAngle);
                if (deviation <= stdDeviation) within1Std++;
                if (deviation <= 2 * stdDeviation) within2Std++;
            }

            double pct1Std = (double)within1Std / steerAngleHistory.Count;
            double pct2Std = (double)within2Std / steerAngleHistory.Count;

            // Normal distribution expectations
            double expected1Std = 0.68;
            double expected2Std = 0.95;

            // Score based on normal distribution fit
            double score1 = 1 - Math.Abs(pct1Std - expected1Std) / expected1Std;
            double score2 = 1 - Math.Abs(pct2Std - expected2Std) / expected2Std;

            // Penalize large recommended offsets
            double magnitudeScore = Math.Max(0, 1 - Math.Abs(recommendedOffset) / 10.0);

            // Sample size factor
            double sizeFactor = Math.Min(1.0, (double)steerAngleHistory.Count / (MIN_SAMPLES * 3));

            // Combine scores
            double confidence = ((score1 * 0.3 + score2 * 0.3 + magnitudeScore * 0.2 + sizeFactor * 0.2) * 100);
            return Math.Max(0, Math.Min(100, confidence));
        }

        /// <summary>
        /// Get statistics string for UI display
        /// </summary>
        public string GetStatsString()
        {
            if (SampleCount == 0) return "No data";

            return $"Samples: {SampleCount}\n" +
                   $"Mean: {meanAngle:F2}°\n" +
                   $"Median: {medianAngle:F2}°\n" +
                   $"StdDev: {stdDeviation:F2}°\n" +
                   $"Offset: {recommendedOffset:F2}°\n" +
                   $"Confidence: {confidenceLevel:F0}%";
        }
    }
}
