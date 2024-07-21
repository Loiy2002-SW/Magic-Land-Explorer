

namespace MagicLandExplorer.Tasks
{
    public static class Top3Duration
    {
        public static IEnumerable<Destination> GetTop3LongestDurationDestinations(IEnumerable<Category> categories)
        {
            return categories.SelectMany(c => c.Destinations)
                             .OrderByDescending(d => DurationHelper.ParseDuration(d.Duration) ?? 0)
                             .Take(3);
        }
    }


}
