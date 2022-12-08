namespace AdventOfCode_2022.Solutions
{
    public partial class DayThree : ISolution
    {
        public void RunPartTwo()
        {
            var rucksacks = File.ReadAllLines("InputFiles\\DayThreeInput.txt").ToList();

            var sumOfItems = 0;
            for(int i = 0; i < rucksacks.Count; i=i+3)
            {
                sumOfItems += CharToPriority(GetGroupBadge(rucksacks.GetRange(i, 3)));
            }

            Console.WriteLine(sumOfItems);
        }

        public char GetGroupBadge(List<string> rucksacks)
        {
            var orderedRucksacks = rucksacks.OrderByDescending(s => s.Length).ToList();
            var longestString = orderedRucksacks.First();

            foreach(var c in longestString)
            {
                char? potentialGroupBadge = c;

                foreach(var rucksack in orderedRucksacks.Skip(1))
                {
                    if (rucksack.Contains(c))
                        continue;
                    else
                    {
                        potentialGroupBadge = null;
                        break;
                    }
                }

                if (potentialGroupBadge != null)
                    return (char)potentialGroupBadge;
            }

            throw new Exception("No wrong item found");
        }
    }
}
