using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4 : IDayBase
    {
        List<Assignment> assignments = new();
        public int Day => 4;

        public void ExecutePart1()
        {
            int result = 0;
            foreach (var assignment in assignments.Where(x=>x.Overlaps()))
            {
               result++;
                //Console.WriteLine(assignment.ToString());
            }
            Console.WriteLine($"Result part 1: {result}");
        }

        public void ExecutePart2()
        {
            int result = 0;
            foreach (var assignment in assignments.Where(x => x.OverlapsAtAll()))
            {
                result++;
                //Console.WriteLine(assignment.ToString());
            }
            Console.WriteLine($"Result part 2: {result}");
        }

        public void LoadInput()
        {
            string line;
            //Add your own puzzle input to day4.txt
            System.IO.StreamReader file = new System.IO.StreamReader(@$"DayInputs\day{Day}.txt");
            while ((line = file.ReadLine()) != null)
            {
                //24-91,80-92
                var splitted = line.Split(',');
                var assignment1 = splitted[0].Split('-');
                var number1 = int.Parse(assignment1[0]);
                var number2 = int.Parse(assignment1[1]);

                var assignment2 = splitted[1].Split('-');
                var number3 = int.Parse(assignment2[0]);
                var number4 = int.Parse(assignment2[1]);

                assignments.Add(new Assignment(new int[] { number1, number2, number3, number4 }));
            }
        }
    }
}
