

namespace MagicLandExplorer
{
    public static class DurationHelper
    {
        public static int? ParseDuration(string duration)
        {
            if (string.IsNullOrWhiteSpace(duration))
            {
                return null; // No duration provided
            }

            // Handle durations with "minutes" suffix
            if (duration.Contains("minutes"))
            {
                string[] parts = duration.Split(' ');
                if (int.TryParse(parts[0], out int parsedDuration))
                {
                    return parsedDuration;
                }
            }

            return null; // Unable to parse duration
        }
    }


}
