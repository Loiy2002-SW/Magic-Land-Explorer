
namespace MagicLandExplorer.Tasks
{
    public static class FilterDestinations
    {
        public static IEnumerable<Destination> GetDestinationsWithShortDuration(IEnumerable<Category> categories, int maxDuration)
        {
            return categories.SelectMany(c => c.Destinations)
                             .Where(d => DurationHelper.ParseDuration(d.Duration) < maxDuration || DurationHelper.ParseDuration(d.Duration) == null);
        }
    }


}
