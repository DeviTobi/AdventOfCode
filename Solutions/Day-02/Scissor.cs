namespace AdventOfCode_2022.Solutions
{
    public class Scissor : RockPaperScissor
    {
        public override int DefaultChoicePoints => 3;
        public override string LosesTo => "A";
        public override string WinsAgainst => "B";

        public override int GetScoreOnOutcome(string outcome) => outcome switch
        {
            "X" => new Paper().DefaultChoicePoints + 0,
            "Y" => new Scissor().DefaultChoicePoints + 3,
            "Z" => new Rock().DefaultChoicePoints + 6,
        };
    }
}
