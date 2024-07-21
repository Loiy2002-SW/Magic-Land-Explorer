

namespace MagicLandExplorer.Tasks
{
    public static class LongestDuration
    {
        public static Destination GetLongestDurationDestination(IEnumerable<Category> categories)
        {
            return categories.SelectMany(c => c.Destinations)
                             .OrderByDescending(d => DurationHelper.ParseDuration(d.Duration) ?? 0)
                             .FirstOrDefault();
        }
    }


}
