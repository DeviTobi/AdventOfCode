namespace AdventOfCode_2022.Solutions
{
    public class DaySix : ISolution
    {
        public void Run()
        {
            Console.WriteLine(DetectStartOfMessage(4));
        }

        public void RunPartTwo()
        {
            Console.WriteLine(DetectStartOfMessage(14));
        }

        public int DetectStartOfMessage(int requiredDistinctCharacters)
        {
            var dataPacket = File.ReadAllText("InputFiles\\Day-06-Input.txt");

            var queue = new Queue<char>();

            for (var i = 0; i < dataPacket.Length; i++)
            {
                var c = dataPacket[i];

                queue.Enqueue(c);

                if (queue.Count > requiredDistinctCharacters)
                    queue.Dequeue();

                if (queue.Count == requiredDistinctCharacters && MarkerFound(queue))
                    return i + 1;
            }

            throw new Exception("Start of message not found");
        }

        public bool MarkerFound(Queue<char> queue)
        {
            HashSet<char> chars = new HashSet<char>();
            foreach(var c in queue)
            {
                if (chars.Contains(c))
                    return false;

                chars.Add(c);
            }

            return true;
        }
    }
}
