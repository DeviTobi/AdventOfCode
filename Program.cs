using AdventOfCode_2022.Solutions;

namespace AdventOfCode_2022
{
    public class Program
    {
        private static readonly List<ISolution> solutionsToRun = new()
        {
            new DayOne(), new DayTwo(), new DayThree(), new DayFour(), new DayFive(), new DaySix()
        };

        public static void Main()
        {
            var dayCounter = 1;

            foreach(var solution in solutionsToRun)
            {
                Console.Write($"Day {dayCounter++}: ");
                solution.Run();
                Console.Write("Part 2: ");
                solution.RunPartTwo();
            }
        }
    }
}
