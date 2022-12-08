namespace AdventOfCode_2022.Solutions
{
    public class Paper : RockPaperScissor
    {
        public override int DefaultChoicePoints => 2;
        public override string LosesTo => "C";
        public override string WinsAgainst => "A";

        public override int GetScoreOnOutcome(string outcome) => outcome switch
        {
            "X" => new Rock().DefaultChoicePoints + 0,
            "Y" => new Paper().DefaultChoicePoints + 3,
            "Z" => new Scissor().DefaultChoicePoints + 6,
        };
    }
}
