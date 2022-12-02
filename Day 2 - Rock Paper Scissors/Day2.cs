using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day2 : IDayBase
    {
        //A / X = Rock Score = 1
        //B / Y = Paper Score = 2
        //C / Z = Scissor Score = 3
        //Draw = 3 Win = 6
        public int Day => 2;
        List<string> input1 = new List<string>();
        List<string> input2 = new List<string>();
        int scorePart1 = 0;
        int scorePart2 = 0;
        public void ExecutePart1()
        {
            foreach (var line in input1)
            {
                var opponent = line.Split(' ')[0];
                var me = line.Split(' ')[1];
                if (opponent == "A")
                {
                    //opponent = rock
                    switch (me)
                    {
                        case "X":
                            //rock  = 1;
                            scorePart1 += 1;
                            //draw = 3
                            scorePart1 += 3;
                            break;
                        case "Y":
                            //paper + 2;
                            scorePart1 += 2;
                            //paper wins from rock + 6
                            scorePart1 += 6;
                            break;
                        case "Z":
                            //scissors = 3;
                            scorePart1 += 3;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }

                if (opponent == "B")
                {
                    //b opponent = paper
                    switch (me)
                    {
                        case "X":
                            //rock = 1;
                            scorePart1 += 1;
                            break;
                        case "Y":
                            //paper + 2;
                            scorePart1 += 2;
                            //draw
                            scorePart1 += 3;
                            break;
                        case "Z":
                            //win
                            scorePart1 += 3;
                            scorePart1 += 6;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }

                if (opponent == "C")
                {
                    //b opponent = scissor
                    switch (me)
                    {
                        case "X":
                            //win
                            scorePart1 += 1;
                            scorePart1 += 6;
                            break;
                        case "Y":
                            //loss
                            scorePart1 += 2;
                            break;
                        case "Z":
                            //win
                            scorePart1 += 3;
                            scorePart1 += 3;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
            }
            Console.WriteLine($"Result part 1: {scorePart1}");
        }

        public void ExecutePart2()
        {
            foreach(string line in input2)
            {
                var opponent = line.Split(' ')[0];
                var me = line.Split(' ')[1];
                if (opponent == "A")
                {
                    //Opponent = Rock
                    switch (me)
                    {
                        case "X":
                            //X = Loose with Scissor
                            scorePart2 += 3;
                            break;
                        case "Y":
                            //Draw with rock
                            scorePart2 += 1;
                            //Y = Draw
                            scorePart2 += 3;
                            break;
                        case "Z":
                            //Win with Paper
                            scorePart2 += 2;
                            //Z = Win
                            scorePart2 += 6;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                }
                if (opponent == "B")
                {
                    //Opponent = Paper
                    switch (me)
                    {
                        case "X":
                            //X = Loose with Rock
                            scorePart2 += 1;
                            break;
                        case "Y":
                            //Draw with Paper
                            scorePart2 += 2;
                            //Y = Draw
                            scorePart2 += 3;
                            break;
                        case "Z":
                            //Win with Scissor
                            scorePart2 += 3;
                            //Z = Win
                            scorePart2 += 6;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                }

                if (opponent == "C")
                {
                    //Opponent = Scissors
                    switch (me)
                    {
                        case "X":
                            //X = Loose with paper
                            scorePart2 += 2;
                            break;
                        case "Y":
                            //Draw with Scissor
                            scorePart2 += 3;
                            //Y = Draw
                            scorePart2 += 3;
                            break;
                        case "Z":
                            //Win with Rock
                            scorePart2 += 1;
                            //Z = Win
                            scorePart2 += 6;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                }
            }
            Console.WriteLine($"Result part 2: {scorePart2}");
        }

        public void LoadInput()
        {
            string line;
            //Add your own puzzle input to day2.txt
            System.IO.StreamReader file = new System.IO.StreamReader(@"DayInputs\day2.txt");
            while ((line = file.ReadLine()) != null)
            {
                input1.Add(line);
                input2.Add(line);
                
            }
        }
    }
}
