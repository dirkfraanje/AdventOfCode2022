using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day1 : IDayBase
    {
        public int Day => 1;
        int result1 = 0;
        int result2 = 0;
        int result3 = 0;
        public void ExecutePart1()
        {
           
           
            Console.WriteLine($"Result part 1: {result1}");
        }

        public void ExecutePart2()
        {
            Console.WriteLine($"Result part 2: {result1 + result2 + result3}");
        }

        public void LoadInput()
        {
            string line;
            //Elf currentElf = new Elf();
            int currentResult = 0;
            //input.Add(currentElf);
            //Add your own puzzle input to day1.txt
            System.IO.StreamReader file = new System.IO.StreamReader(@"DayInputs\day1.txt");
            while ((line = file.ReadLine()) != null)
            {
                if(line == "")
                {
                    if (currentResult > result1)
                    {
                        result3 = result2;
                        result2 = result1;
                        result1 = currentResult;
                    }
                        
                    else if (currentResult > result2)
                    {
                        result3 = result2;
                        result2 = currentResult;
                    }
                        
                    else if (currentResult > result3)
                        result3 = currentResult;
                    currentResult = 0;
                }
                    
                else
                    currentResult += int.Parse(line);
            }
        }
    }
}
