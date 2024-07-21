using MagicLandExplorer.Tasks;
using Newtonsoft.Json;

namespace MagicLandExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string jsonFilePath = Path.Combine(dataDirectory, "data.json");

            if (!File.Exists(jsonFilePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The data file could not be found: " + jsonFilePath);
                Console.ForegroundColor = ConsoleColor.Blue;
                return;
            }

            string json = File.ReadAllText(jsonFilePath);
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);

            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Show filtered destinations (duration < 100 minutes)");
                Console.WriteLine("2 - Show destination with the longest duration");
                Console.WriteLine("3 - Sort destinations by name");
                Console.WriteLine("4 - Show top 3 longest duration destinations");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("-------------------------------------------------");


                Console.ForegroundColor = ConsoleColor.Yellow;

                switch (Console.ReadLine())
                {
                    case "1":
                        var shortDestinations = FilterDestinations.GetDestinationsWithShortDuration(categories, 100);
                        foreach (var dest in shortDestinations)
                        {
                            Console.WriteLine($"{dest.Name} - {dest.Duration ?? "No duration"}");
                        }
                        break;
                    case "2":
                        var longestDestination = LongestDuration.GetLongestDurationDestination(categories);
                        Console.WriteLine($"{longestDestination.Name} - {longestDestination.Duration ?? "No duration"}");
                        break;
                    case "3":
                        var sortedDestinations = SortByName.GetSortedDestinationsByName(categories);
                        foreach (var dest in sortedDestinations)
                        {
                            Console.WriteLine(dest.Name);
                        }
                        break;
                    case "4":
                        var top3Destinations = Top3Duration.GetTop3LongestDurationDestinations(categories);
                        foreach (var dest in top3Destinations)
                        {
                            Console.WriteLine($"{dest.Name} - {dest.Duration ?? "No duration"}");
                        }
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-------------------------------------------------");
            }
        }
    }
}
