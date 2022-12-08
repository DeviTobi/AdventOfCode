// Solution for day 1, calories counting https://adventofcode.com/2022/day/1

namespace AdventOfCode_2022.Solutions
{
    public class DayOne : ISolution
    {
        private readonly static string inputFile = "InputFiles\\DayOneInput.txt";
        private Stack<decimal> leaderboard = new Stack<decimal>();

        public void Run()
        {
            Console.WriteLine(HighestConsecutiveNumber());
        }

        public void RunPartTwo()
        {
            var topThree = 0m;
            for (int i = 0; i < 3; i++)
                topThree += leaderboard.Pop();

            Console.WriteLine(topThree);
        }

        public decimal HighestConsecutiveNumber()
        {
            var highestNumber = 0m;
            var currentNumber = 0m;

            void UpdateScoreAndLeaderboard()
            {
                if (currentNumber < highestNumber)
                    return;

                highestNumber = currentNumber;
                leaderboard.Push(highestNumber);
            };

            var numbers = File.ReadAllLines(inputFile);

            foreach (var line in numbers)
            {
                if (string.IsNullOrEmpty(line))
                {
                    UpdateScoreAndLeaderboard();

                    currentNumber = 0;
                    continue;
                }

                if (decimal.TryParse(line, out var number))
                    currentNumber += number;
            }

            UpdateScoreAndLeaderboard();

            return highestNumber;
        }
    }
}
