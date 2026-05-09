using System;
using System.Text.RegularExpressions;

namespace AgOpenGPS.Core.Models
{
    /// <summary>
    /// Semantic Version 2.0 implementation for version comparison.
    /// Supports version format: major.minor.patch[-prerelease][+build]
    /// </summary>
    public class SemanticVersion : IComparable<SemanticVersion>, IEquatable<SemanticVersion>
    {
        private static readonly Regex VersionRegex = new Regex(
            @"^(?<major>\d+)(?:\.(?<minor>\d+))?(?:\.(?<patch>\d+))?(?:-(?<prerelease>[0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?(?:\+(?<build>[0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture);

        public int Major { get; }
        public int Minor { get; }
        public int Patch { get; }
        public string Prerelease { get; }
        public string Build { get; }

        public SemanticVersion(int major, int minor, int patch, string prerelease = null, string build = null)
        {
            if (major < 0) throw new ArgumentOutOfRangeException(nameof(major), "Major version must be non-negative");
            if (minor < 0) throw new ArgumentOutOfRangeException(nameof(minor), "Minor version must be non-negative");
            if (patch < 0) throw new ArgumentOutOfRangeException(nameof(patch), "Patch version must be non-negative");

            Major = major;
            Minor = minor;
            Patch = patch;
            Prerelease = prerelease ?? string.Empty;
            Build = build ?? string.Empty;
        }

        /// <summary>
        /// Parse a version string into a SemanticVersion object.
        /// </summary>
        /// <param name="version">Version string (e.g., "1.2.3", "2.0.0-beta", "3.1.0-rc.1")</param>
        /// <returns>SemanticVersion object</returns>
        public static SemanticVersion Parse(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentException("Version string cannot be null or empty", nameof(version));

            var match = VersionRegex.Match(version.Trim());
            if (!match.Success)
                throw new FormatException($"Invalid semantic version format: {version}");

            int major = int.Parse(match.Groups["major"].Value);
            int minor = match.Groups["minor"].Success ? int.Parse(match.Groups["minor"].Value) : 0;
            int patch = match.Groups["patch"].Success ? int.Parse(match.Groups["patch"].Value) : 0;
            string prerelease = match.Groups["prerelease"].Success ? match.Groups["prerelease"].Value : null;
            string build = match.Groups["build"].Success ? match.Groups["build"].Value : null;

            return new SemanticVersion(major, minor, patch, prerelease, build);
        }

        /// <summary>
        /// Try to parse a version string.
        /// </summary>
        public static bool TryParse(string version, out SemanticVersion semanticVersion)
        {
            try
            {
                semanticVersion = Parse(version);
                return true;
            }
            catch
            {
                semanticVersion = null;
                return false;
            }
        }

        /// <summary>
        /// Check if this version is newer than the other version.
        /// </summary>
        public bool IsNewerThan(SemanticVersion other)
        {
            return CompareTo(other) > 0;
        }

        /// <summary>
        /// Check if this version is a pre-release version.
        /// </summary>
        public bool IsPrerelease => !string.IsNullOrEmpty(Prerelease);

        public int CompareTo(SemanticVersion other)
        {
            if (other == null) return 1;

            int result = Major.CompareTo(other.Major);
            if (result != 0) return result;

            result = Minor.CompareTo(other.Minor);
            if (result != 0) return result;

            result = Patch.CompareTo(other.Patch);
            if (result != 0) return result;

            // Pre-release versions have lower precedence than normal versions
            if (string.IsNullOrEmpty(Prerelease) && !string.IsNullOrEmpty(other.Prerelease))
                return 1;
            if (!string.IsNullOrEmpty(Prerelease) && string.IsNullOrEmpty(other.Prerelease))
                return -1;
            if (string.IsNullOrEmpty(Prerelease) && string.IsNullOrEmpty(other.Prerelease))
                return 0;

            // Compare pre-release identifiers dot-separated
            return ComparePrereleaseIdentifiers(Prerelease, other.Prerelease);
        }

        private static int ComparePrereleaseIdentifiers(string prerelease1, string prerelease2)
        {
            var identifiers1 = prerelease1.Split('.');
            var identifiers2 = prerelease2.Split('.');

            int maxLength = Math.Max(identifiers1.Length, identifiers2.Length);

            for (int i = 0; i < maxLength; i++)
            {
                string id1 = i < identifiers1.Length ? identifiers1[i] : null;
                string id2 = i < identifiers2.Length ? identifiers2[i] : null;

                // A larger set of pre-release fields has a higher precedence
                if (id1 == null) return -1;
                if (id2 == null) return 1;

                // Numeric identifiers have lower precedence than non-numeric identifiers
                bool id1Numeric = int.TryParse(id1, out int num1);
                bool id2Numeric = int.TryParse(id2, out int num2);

                if (id1Numeric && id2Numeric)
                {
                    int result = num1.CompareTo(num2);
                    if (result != 0) return result;
                }
                else if (id1Numeric)
                {
                    return -1;
                }
                else if (id2Numeric)
                {
                    return 1;
                }
                else
                {
                    int result = string.CompareOrdinal(id1, id2);
                    if (result != 0) return result;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            string version = $"{Major}.{Minor}.{Patch}";
            if (!string.IsNullOrEmpty(Prerelease))
                version += $"-{Prerelease}";
            if (!string.IsNullOrEmpty(Build))
                version += $"+{Build}";
            return version;
        }

        public bool Equals(SemanticVersion other)
        {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SemanticVersion);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + Major.GetHashCode();
                hash = hash * 31 + Minor.GetHashCode();
                hash = hash * 31 + Patch.GetHashCode();
                hash = hash * 31 + (Prerelease?.GetHashCode() ?? 0);
                return hash;
            }
        }

        // Comparison operators
        public static bool operator ==(SemanticVersion left, SemanticVersion right)
        {
            if (ReferenceEquals(left, null)) return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        public static bool operator !=(SemanticVersion left, SemanticVersion right)
        {
            return !(left == right);
        }

        public static bool operator <(SemanticVersion left, SemanticVersion right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(SemanticVersion left, SemanticVersion right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(SemanticVersion left, SemanticVersion right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(SemanticVersion left, SemanticVersion right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

        public static implicit operator string(SemanticVersion version) => version?.ToString();
    }
}
