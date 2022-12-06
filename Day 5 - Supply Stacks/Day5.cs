using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5 : IDayBase
    {
        List<Stack<string>> stacks = new();
        List<Stack<string>> stacksPart2 = new();
        Stack<string> currentStack;
        Stack<string> currentStack2;
        int stackPosition = 1;
        List<List<int>> movingList = new();
        public int Day => 5;

        public void ExecutePart1()
        {
            foreach (var moving in movingList)
            {
                var stackFrom = stacks[moving[1] - 1];
                var stackTo = stacks[moving[2] - 1];

                for (int i = 0; i < moving[0]; i++)
                {
                    stackTo.Push(stackFrom.First());
                    stackFrom.Pop();
                }
            }
            string result = "";
            foreach (var stack in stacks)
            {
                result += stack.First().Substring(1, 1);
            }
            Console.WriteLine($"Result part 1: {result}");
        }

        public void ExecutePart2()
        {
            foreach (var moving in movingList)
            {
                var stackFrom = stacksPart2[moving[1] - 1];
                var stackTo = stacksPart2[moving[2] - 1];
                var betweenStack = new Stack<string>();
                for (int i = 0; i < moving[0]; i++)
                {
                    betweenStack.Push(stackFrom.First());
                    stackFrom.Pop();
                }

                for (int i = 0; i < moving[0]; i++)
                {
                    stackTo.Push(betweenStack.First());
                    betweenStack.Pop();
                }
            }
            string result = "";
            foreach (var stack in stacksPart2)
            {
                result += stack.First().Substring(1, 1);
            }
            Console.WriteLine($"Result part 1: {result}");
        }

        public void LoadInput()
        {
            string line;

            //Add your own puzzle input to day5.txt
            System.IO.StreamReader file = new System.IO.StreamReader($@"DayInputs\day{Day}.txt");
            while ((line = file.ReadLine()) != null)
            {
                //line = line.Replace(' ', '#');
                //    [D]
                //[N] [C]
                //[Z] [M] [P]
                // 1   2   3

                //Create the stacks with crates
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("move"))
                {
                    stackPosition = 1;
                    while (!string.IsNullOrEmpty(line))
                    {
                        if (!string.IsNullOrEmpty(line) && line.Length >= 4)
                        {
                            if (!Char.IsDigit(line[1]))
                                StackCrate(line, 4);
                            line = line.Remove(0, 4);
                        }

                        else if (!string.IsNullOrEmpty(line) && line.Length == 3)
                        {
                            if (!Char.IsDigit(line[1]))
                                StackCrate(line, 3);
                            line = line.Remove(0, 3);
                        }
                    }
                }

                //Interpret the movings
                if (!string.IsNullOrWhiteSpace(line) && line.StartsWith("move"))
                {
                    var movings = line.Split(' ');
                    movingList.Add(new List<int>() { int.Parse(movings[1]), int.Parse(movings[3]), int.Parse(movings[5]) });
                    //Console.WriteLine($"{movings[1]} {movings[3]} {movings[5]}");
                }

                //Set te stack right
                
            }
            var currentStacks = stacks.ToArray();
            stacks.Clear();
            foreach (var stack in currentStacks)
            {
                var currentStack = new Stack<string>();
                stacks.Add(currentStack);
                foreach (var crate in stack)
                {
                    currentStack.Push(crate);
                }
            }
        }

        private void StackCrate(string column, int length)
        {
            //First check if a stack has already been created for this column in the input file
            if (stacks.Count < stackPosition)
            {
                stacks.Add(new());
                stacksPart2.Add(new());
            }
                
            currentStack = stacks[stackPosition - 1];
            currentStack2 = stacksPart2[stackPosition - 1];
            //Console.WriteLine(column.Substring(0, length));
            if (!string.IsNullOrWhiteSpace(column.Substring(0, length)) && !Char.IsDigit(column[1]))
            {
                currentStack.Push(column.Substring(0, length));
                currentStack2.Push(column.Substring(0, length));
            }
            stackPosition++;
        }
    }
}
