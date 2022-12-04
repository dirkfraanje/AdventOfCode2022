using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3 : IDayBase
    {
        List<string> input = new List<string>();

        public int Day => 3;

        public void ExecutePart1()
        {
            int result = 0;
            foreach (var rucksack in input)
            {
                int lineLength = rucksack.Length;
                var compartment1 = rucksack.Substring(0, lineLength / 2);
                var compartment2 = rucksack.Substring(lineLength / 2);
                foreach (var item in compartment1)
                {
                    if (compartment2.Contains(item))
                    {
                        //Console.WriteLine($"Match: {item}: {GetScore(item)}");
                        result += GetScore(item);
                        break;
                    }
                }
            }
            Console.WriteLine($"Result part 1: {result}");
            
        }

        public void ExecutePart2()
        {
            int resultpart2 = 0;
            while (input.Any())
            {
                var threeRucksacks = input.Take(3).ToList();
                input.RemoveRange(0, 3);
                var starter = threeRucksacks.First();
                //vJrwpWtwJgWrhcsFMMfFFhFp
                //jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                //PmmdzqPrVvPwwTWBwg
                int result = 0;
                foreach (var item in starter)
                {
                    if (threeRucksacks[1].Contains(item))
                        result++;
                    if (threeRucksacks[2].Contains(item))
                        result++;
                    if (result == 2)
                    {
                        resultpart2 += GetScore(item);
                        //Console.WriteLine(item);
                        break;
                    }
                        
                    else
                        result = 0;
                }
            }
            Console.WriteLine($"Result part 2: {resultpart2}");
        }

        int GetScore(Char item)
        {
            switch (item)
            {
                case 'a':
                    return 1;
                case 'b':
                    return 2;
                case 'c':
                    return 3;
                case 'd':
                    return 4;
                case 'e':
                    return 5;
                case 'f':
                    return 6;
                case 'g':
                    return 7;
                case 'h':
                    return 8;
                case 'i':
                    return 9;
                case 'j':
                    return 10;
                case 'k':
                    return 11;
                case 'l':
                    return 12;
                case 'm':
                    return 13;
                case 'n':
                    return 14;
                case 'o':
                    return 15;
                case 'p':
                    return 16;
                case 'q':
                    return 17;
                case 'r':
                    return 18;
                case 's':
                    return 19;
                case 't':
                    return 20;
                case 'u':
                    return 21;
                case 'v':
                    return 22;
                case 'w':
                    return 23;
                case 'x':
                    return 24;
                case 'y':
                    return 25;
                case 'z':
                    return 26;
                case 'A':
                    return 27;
                case 'B':
                    return 28;
                case 'C':
                    return 29;
                case 'D':
                    return 30;
                case 'E':
                    return 31;
                case 'F':
                    return 32;
                case 'G':
                    return 33;
                case 'H':
                    return 34;
                case 'I':
                    return 35;
                case 'J':
                    return 36;
                case 'K':
                    return 37;
                case 'L':
                    return 38;
                case 'M':
                    return 39;
                case 'N':
                    return 40;
                case 'O':
                    return 41;
                case 'P':
                    return 42;
                case 'Q':
                    return 43;
                case 'R':
                    return 44;
                case 'S':
                    return 45;
                case 'T':
                    return 46;
                case 'U':
                    return 47;
                case 'V':
                    return 48;
                case 'W':
                    return 49;
                case 'X':
                    return 50;
                case 'Y':
                    return 51;
                case 'Z':
                    return 52;
                default:
                    throw new Exception();
            }
        }

        public void LoadInput()
        {
            string line;
            //Add your own puzzle input to day3.txt
            System.IO.StreamReader file = new System.IO.StreamReader(@"DayInputs\day3.txt");
            while ((line = file.ReadLine()) != null)
            {
                input.Add(line);
            }
        }
    }
}
