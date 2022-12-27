using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace AdventOfCode_2022.Solutions
{
    public class DaySeven : ISolution
    {
        private readonly Regex _fileSizePattern = new Regex("\\d*");

        public void Run()
        {
            var root = InitializeRootDirectory();

            Console.WriteLine(SumOfDirectoriesAtMax(root, 100000));
        }

        public void RunPartTwo()
        {
            var root = InitializeRootDirectory();

            var freeSpace = 70000000 - root.GetTotalSize();
            var requiredSpace = 30000000;
            var minimumSpaceToRemove = requiredSpace - freeSpace;

            Console.WriteLine(DirectorySizeToRemove(root, minimumSpaceToRemove, int.MaxValue));
        }

        private Directory InitializeRootDirectory()
        {
            var input = File.ReadAllLines("InputFiles\\Day-07-Input.txt").Skip(1);

            var root = new Directory("root", null);
            var currentDirectory = root;

            foreach (var line in input)
            {
                // Process Directories and Files in current map
                if (line.StartsWith("dir"))
                {
                    currentDirectory.Directories.Add(line[4..], new Directory(line[4..], currentDirectory));
                    continue;
                }

                if (char.IsDigit(line[0]))
                {
                    currentDirectory.CurrentLevelFileSize += int.Parse(_fileSizePattern.Match(line).Value);
                    continue;
                }

                // Move to another directory
                if (line.StartsWith("$ cd .."))
                {
                    currentDirectory = currentDirectory.Parent;
                    continue;
                }

                if (line.StartsWith("$ cd "))
                {
                    currentDirectory.Directories.TryGetValue(line[5..], out currentDirectory);
                    continue;
                }
            }

            while (currentDirectory.Parent != null)
                currentDirectory = currentDirectory.Parent;

            return currentDirectory;
        }

        private int SumOfDirectoriesAtMax(Directory dir, int max)
        {
            var sum = 0;

            var totalSize = dir.GetTotalSize();

            if (totalSize <= max)
                sum += totalSize;

            foreach(var directory in dir.Directories)
            {
                sum += SumOfDirectoriesAtMax(directory.Value, max);
            }

            return sum;
        }

        private int DirectorySizeToRemove(Directory dir, int spaceRequired, int currentLowestSize)
        {
            var totalSize = dir.GetTotalSize();

            if (totalSize < currentLowestSize && totalSize >= spaceRequired)
                currentLowestSize = totalSize;

            foreach(var directory in dir.Directories)
            {
                var potentialSizeToRemove = DirectorySizeToRemove(directory.Value, spaceRequired, currentLowestSize);
                if (potentialSizeToRemove < currentLowestSize)
                    currentLowestSize = potentialSizeToRemove;
            }

            return currentLowestSize;
        }
    }
}
