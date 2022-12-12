namespace AdventOfCode_2022.Solutions
{
    public class DayFour : ISolution
    {
        public void Run()
        {
            var pairs = File.ReadAllLines("InputFiles\\Day-04-Input.txt");

            var counter = 0;

            foreach (var line in pairs)
            {
                var pair = line.Split(",");

                var firstSection = new SectionRange(pair[0]);
                var secondSection = new SectionRange(pair[1]);

                if (IsFullyContained(firstSection, secondSection))
                    counter++;
            }

            Console.WriteLine(counter);
        }

        public void RunPartTwo()
        {
            var pairs = File.ReadAllLines("InputFiles\\Day-04-Input.txt");

            var counter = 0;

            foreach (var line in pairs)
            {
                var pair = line.Split(",");

                var firstSection = new SectionRange(pair[0]);
                var secondSection = new SectionRange(pair[1]);

                if (IsOverlapping(firstSection, secondSection))
                    counter++;
            }

            Console.WriteLine(counter);
        }

        public bool IsFullyContained(SectionRange firstRange, SectionRange secondRange)
        {
            return 
                (NumberIsWithinRange(firstRange.LowerBound, secondRange.LowerBound, secondRange.UpperBound) &&
                NumberIsWithinRange(firstRange.UpperBound, secondRange.LowerBound, secondRange.UpperBound)) 
                ||
                (NumberIsWithinRange(secondRange.LowerBound, firstRange.LowerBound, firstRange.UpperBound) &&
                NumberIsWithinRange(secondRange.UpperBound, firstRange.LowerBound, firstRange.UpperBound));
        }

        public bool IsOverlapping(SectionRange firstRange, SectionRange secondRange)
        {
            return
                (firstRange.LowerBound >= secondRange.LowerBound && firstRange.LowerBound <= secondRange.UpperBound) ||
                (firstRange.UpperBound >= secondRange.LowerBound && firstRange.UpperBound <= secondRange.UpperBound) ||
                (secondRange.LowerBound >= firstRange.LowerBound && secondRange.LowerBound <= firstRange.UpperBound) ||
                (secondRange.UpperBound >= firstRange.LowerBound && secondRange.UpperBound <= firstRange.UpperBound);
        }

        public bool NumberIsWithinRange(int number, int lowerBound, int upperBound) => (number >= lowerBound && number <= upperBound);
    }
}
