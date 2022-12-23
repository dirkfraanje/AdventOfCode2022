using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day8 : IDayBase
    {
        List<List<Tree>> Lines = new();
        List<List<Tree>> Columns = new();
        List<Tree> AllTrees = new();
        public int Day => 8;

        public void ExecutePart1()
        {
            //From the left
            foreach (var line in Lines.Take(new Range(1, Lines.Count - 1)))
            {
                var currentHighest = line[0];
                for (int i = 1; i < line.Count - 1; i++)
                {
                    var treeToCheck = line[i];
                    if (treeToCheck.Size > currentHighest.Size)
                    {
                        currentHighest = treeToCheck;
                    }
                    else
                    {
                        treeToCheck.LeftVisible = false;
                        //Console.WriteLine(treeToCheck.Size);
                    }
                }
                //Console.WriteLine();
            }

            //From the right
            foreach (var line in Lines.Take(new Range(1, Lines.Count - 1)))
            {
                var currentHighest = line[line.Count - 1];
                for (int i = line.Count - 2; i > 0; i--)
                {
                    var treeToCheck = line[i];
                    if (treeToCheck.Size > currentHighest.Size)
                    {
                        currentHighest = treeToCheck;
                    }
                    else
                    {
                        treeToCheck.RightVisible = false;
                        //Console.WriteLine(treeToCheck.Size);
                    }
                }
                //Console.WriteLine();
            }

            //From the left
            foreach (var line in Columns.Take(new Range(1, Lines.Count - 1)))
            {
                var currentHighest = line[0];
                for (int i = 1; i < line.Count - 1; i++)
                {
                    var treeToCheck = line[i];
                    if (treeToCheck.Size > currentHighest.Size)
                    {
                        currentHighest = treeToCheck;
                    }
                    else
                    {
                        treeToCheck.BottomVisible = false;
                        //Console.WriteLine(treeToCheck.Size);
                    }
                }
                //Console.WriteLine();
            }

            //From the right
            foreach (var line in Columns.Take(new Range(1, Lines.Count - 1)))
            {
                var currentHighest = line[line.Count - 1];
                for (int i = line.Count - 2; i > 0; i--)
                {
                    var treeToCheck = line[i];
                    if (treeToCheck.Size > currentHighest.Size)
                    {
                        currentHighest = treeToCheck;
                    }
                    else
                    {
                        treeToCheck.TopVisible = false;
                        //Console.WriteLine(treeToCheck.Size);
                    }
                }
                //Console.WriteLine();
            }

            var visible = new List<Tree>();
            foreach (var item in Lines)
            {
                visible.AddRange(item.Where(x => x.TopVisible == true || x.BottomVisible == true || x.LeftVisible == true || x.RightVisible == true));
            }
            var total = visible.Count;
            Console.WriteLine($"Result part 1: {total}");
        }

        public void ExecutePart2()
        {
            var total = 0;
            foreach (var test in AllTrees)
            {
                var treesLeft = AllTrees.Where(t => t.Y == test.Y && t.X < test.X).ToList();
                treesLeft.Reverse();
                var leftSum = 0;
                foreach (var tree in treesLeft)
                {
                    leftSum++;
                    if (tree.Size >= test.Size)
                        break;
                }
                var treesRight = AllTrees.Where(t => t.Y == test.Y && t.X > test.X).ToList();
                var rightSum = 0;
                foreach (var tree in treesRight)
                {
                    rightSum++;
                    if (tree.Size >= test.Size)
                        break;
                }
                var treesUp = AllTrees.Where(t => t.X == test.X && t.Y < test.Y).ToList();
                treesUp.Reverse();
                var upSum = 0;
                foreach (var tree in treesUp)
                {
                    upSum++;
                    if (tree.Size >= test.Size)
                        break;
                }
                var treesDown = AllTrees.Where(t => t.X == test.X && t.Y > test.Y).ToList();
                var downSum = 0;
                foreach (var tree in treesDown)
                {
                    downSum++;
                    if (tree.Size >= test.Size)
                        break;
                }
                var calculatedSum = leftSum * rightSum * upSum * downSum;
                if (calculatedSum > total)
                    total = calculatedSum;
            }
            Console.WriteLine($"Result part 2: {total}");
        }

        public void LoadInput()
        {
            string line;
            int lineNumber = 0;
            List<Tree> currentLine;
            //Add your own puzzle input to day8.txt
            System.IO.StreamReader file = new System.IO.StreamReader($@"DayInputs\day{Day}.txt");
            while ((line = file.ReadLine()) != null)
            {
                currentLine = new List<Tree>();
                Lines.Add(currentLine);
                
                for (int i = 0; i < line.Length; i++)
                {
                    var newTree = new Tree(i, lineNumber, (int)char.GetNumericValue(line[i]));
                    currentLine.Add(newTree);
                    AllTrees.Add(newTree);
                }
                lineNumber++;
            }

            for (int i = 0; i < lineNumber; i++)
            {
                Columns.Add(new List<Tree>());
            }

            for (int i = 0; i < lineNumber; i++)
            {
                var column = Columns[i];
                for (int j = lineNumber - 1; j >= 0; j--)
                {
                    column.Add(Lines[j][i]);
                }
            }

        }
    }
    internal class Tree
    {
        public int X;
        public int Y;
        public int Size;
        public bool LeftVisible = true;
        public bool RightVisible = true;
        public bool TopVisible = true;
        public bool BottomVisible = true;
        public Tree(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
        }

        internal void LeftVisibleFalse()
        {
            LeftVisible = false;
        }
        public override string ToString() {
            return $"X:{X} Y:{Y} Size: {Size}";
                ;
        }
    }
}
