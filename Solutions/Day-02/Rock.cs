using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode_2022.Solutions
{
    public class Rock : RockPaperScissor
    {
        public override int DefaultChoicePoints => 1;
        public override string LosesTo => "B";
        public override string WinsAgainst => "C";

        public override int GetScoreOnOutcome(string outcome) => outcome switch
        {
            "X" => new Scissor().DefaultChoicePoints + 0,
            "Y" => new Rock().DefaultChoicePoints + 3,
            "Z" => new Paper().DefaultChoicePoints + 6,
        };
    }
}
