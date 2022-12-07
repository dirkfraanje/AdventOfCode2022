using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day6 : IDayBase
    {
        string input = "";
        string checkedt = "";
        public int Day => 6;

        public void ExecutePart1()
        {
            checkedt = $"{input[0]}";
            FixIt(1, 4);
        }

        public void ExecutePart2()
        {
            checkedt = $"{input[0]}";
            FixIt(2, 14);
        }

        void FixIt(int part, int length)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (checkedt.Count() == length)
                {
                    Console.WriteLine($"Result part {part}: {i}");
                    return;
                }
                checkedt = checkedt.Substring(Compare(input[i]));
                checkedt += input[i];
            }
        }
        
        int Compare(char v2)
        {
            foreach (var kar in checkedt)
            {
                if (kar == v2)
                    return checkedt.IndexOf(v2) + 1;
            }
            return 0;
        }

        public void LoadInput()
        {
            string line;

            //Add your own puzzle input to day6.txt
            System.IO.StreamReader file = new System.IO.StreamReader($@"DayInputs\day{Day}.txt");
            while ((line = file.ReadLine()) != null)
            {
                input = line;
            }
        }
    }
}
