// Solution for day 2, calculate total score following special strategy https://adventofcode.com/2022/day/1

namespace AdventOfCode_2022.Solutions
{
    public class DayTwo : ISolution
    {
        private readonly static string inputFile = "InputFiles\\DayTwoInput.txt";

        public void Run()
        {
            Console.WriteLine(CalculateTotalScore());
        }

        public void RunPartTwo()
        {
            Console.WriteLine(CalculateTotalScore(true));
        }

        public int CalculateTotalScore(bool alternateScoring = false)
        {
            var rounds = File.ReadAllLines(inputFile);

            var totalScore = 0;
            foreach (var round in rounds)
            {
                var choices = round.Split(" ");
                totalScore += alternateScoring ?
                    AlternateResolveScoreForRound(choices[0], choices[1]) :
                    ResolveScoreForRound(choices[0], choices[1]);
            }

            return totalScore;
        }

        // Opponent: A == Rock, B == Paper, C == Scissor
        // You: X == Rock, Y == Paper, Z == Scissor
        public int ResolveScoreForRound(string opponentsChoice, string yourChoice) => yourChoice switch
        {
            "X" => new Rock().ResolveScore(opponentsChoice),
            "Y" => new Paper().ResolveScore(opponentsChoice),
            "Z" => new Scissor().ResolveScore(opponentsChoice),
            _ => throw new ArgumentException("Incorrect input file"),
        };

        // Opponent: A == Rock, B == Paper, C == Scissor
        // You: X == Lose, Y == Draw, Z == Win
        public int AlternateResolveScoreForRound(string opponentsChoice, string forcedOutcome) => opponentsChoice switch
        {
            "A" => new Rock().GetScoreOnOutcome(forcedOutcome),
            "B" => new Paper().GetScoreOnOutcome(forcedOutcome),
            "C" => new Scissor().GetScoreOnOutcome(forcedOutcome),
            _ => throw new ArgumentException("Incorrect input file"),
        };
    }
}
