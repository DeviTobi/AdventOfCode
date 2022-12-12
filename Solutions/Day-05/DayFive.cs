using System.Text.RegularExpressions;

namespace AdventOfCode_2022.Solutions
{
    public class DayFive : ISolution
    {       
        public void Run()
        {
            var input = File.ReadAllLines("InputFiles\\Day-05-Input.txt");

            var cratesInformation = input.Where(s => s.StartsWith("["));
            var moveInstructions = input.Where(s => s.StartsWith("m"));

            List<Stack<string>> stackedCrates = InitializeCrates(cratesInformation);

            MoveCratesOneAtATime(stackedCrates, moveInstructions);

            foreach(var crate in stackedCrates)
            {
                Console.Write(crate.Pop());
            }
            Console.WriteLine();
        }

        public void RunPartTwo()
        {
            var input = File.ReadAllLines("InputFiles\\Day-05-Input.txt");

            var cratesInformation = input.Where(s => s.StartsWith("["));
            var moveInstructions = input.Where(s => s.StartsWith("m"));

            List<Stack<string>> stackedCrates = InitializeCrates(cratesInformation);

            MoveMultipleCrates(stackedCrates, moveInstructions);

            foreach (var crate in stackedCrates)
            {
                Console.Write(crate.Pop());
            }
            Console.WriteLine();
        }

        public List<Stack<string>> InitializeCrates(IEnumerable<string> cratesInformation)
        {
            List<Stack<string>> stackedCrates = new List<Stack<string>>();

            foreach (var crateLine in cratesInformation.Reverse())
            {
                for (var i = 0; i < crateLine.Length; i += 4)
                {
                    var crate = crateLine.Substring(i + 1, 1);

                    if (string.IsNullOrWhiteSpace(crate))
                        continue;

                    if (stackedCrates.ElementAtOrDefault(i / 4) == null)
                        stackedCrates.Insert(i / 4, new Stack<string>());

                    stackedCrates[i / 4].Push(crate);
                }
            }

            return stackedCrates;
        }

        public void MoveCratesOneAtATime(List<Stack<string>> stackedCrates, IEnumerable<string> moveInstructions)
        {
            var instructionRegex = new Regex(@"\d+");
            foreach(var instruction in moveInstructions)
            {
                var match = instructionRegex.Matches(instruction);
                var moveAmount = int.Parse(match[0].Value);
                var from = int.Parse(match[1].Value) - 1;
                var to = int.Parse(match[2].Value) - 1;

                for(var i=0; i<moveAmount; i++)
                {
                    var crate = stackedCrates[from].Pop();
                    stackedCrates[to].Push(crate);
                }
            }
        }

        public void MoveMultipleCrates(List<Stack<string>> stackedCrates, IEnumerable<string> moveInstructions)
        {
            var instructionRegex = new Regex(@"\d+");
            foreach (var instruction in moveInstructions)
            {
                var match = instructionRegex.Matches(instruction);
                var moveAmount = int.Parse(match[0].Value);
                var from = int.Parse(match[1].Value) - 1;
                var to = int.Parse(match[2].Value) - 1;

                var temp = new Stack<string>();

                for (var i = 0; i < moveAmount; i++)
                {
                    var crate = stackedCrates[from].Pop();
                    temp.Push(crate);
                }

                while(temp.Any())
                    stackedCrates[to].Push(temp.Pop());
            }
        }
    }
}
