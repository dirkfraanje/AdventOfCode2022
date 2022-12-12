using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day7 : IDayBase
    {
        List<Folder> SystemItems = new();
        int fileSystemSize = 70000000;
        int updateSpaceNeeded = 30000000;
        public int Day => 7;

        public void ExecutePart1()
        {
            Console.WriteLine(SystemItems.Count);
            var atMost1000 = new List<SystemItem>();
            foreach (var item in SystemItems.Where(x => x is Folder))
            {
                if (item.Size <= 100000)
                    atMost1000.Add(item);
            }
            Console.WriteLine($"Result part 1: {atMost1000.Sum(x => x.Size)}");
        }

        public void ExecutePart2()
        {
            var unUsedSpace = fileSystemSize - SystemItems.First(x => x.Name == "/").Size;
            
            var stillNeeded = updateSpaceNeeded - unUsedSpace;
            var biggerThenNeeded = SystemItems.Where(x => x.Size > stillNeeded).OrderBy(x=>x.Size);

            //Wrong: 48381165
            Console.WriteLine($"Result part 2: {biggerThenNeeded.First().Size}");
        }

        public void LoadInput()
        {
            string line;
            var root = new Folder("/", null);
            Folder currentDirectory = root;
            SystemItems.Add(root);
            //Add your own puzzle input to day7.txt
            System.IO.StreamReader file = new System.IO.StreamReader($@"DayInputs\day{Day}.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line == "$ cd /")
                    currentDirectory = root;
                else if (line.StartsWith("dir"))
                {
                    var newFolder = new Folder(line, null);
                    SystemItems.Add(newFolder);
                    newFolder.SetParent(currentDirectory);
                    newFolder.Parent.Children.Add(newFolder);
                }
                else if (line == "$ cd ..")
                    currentDirectory = currentDirectory.Parent;
                else if (line.StartsWith("$ cd"))
                    currentDirectory = (Folder)currentDirectory.Children.First(x => x is Folder && ((Folder)x).Name.Equals($"dir {line.Split(' ')[2]}"));
                else
                    currentDirectory.Children.Add(new File(line, currentDirectory));
            }
        }
    }
}
