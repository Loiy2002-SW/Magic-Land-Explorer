

namespace MagicLandExplorer.Tasks
{
    public static class SortByName
    {
        public static IEnumerable<Destination> GetSortedDestinationsByName(IEnumerable<Category> categories)
        {
            return categories.SelectMany(c => c.Destinations)
                             .OrderBy(d => d.Name);
        }
    }


}
