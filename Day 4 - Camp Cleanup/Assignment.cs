using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    
    internal class Assignment
    {
        int first, second,third, fourth;

        public Assignment(int[] numbers)
        {
            this.first = numbers[0];
            this.second = numbers[1];
            this.third = numbers[2];
            this.fourth = numbers[3];
        }

        public override string ToString()
        {
            return $"{first} {second} {third} {fourth}";
        }
        public bool Overlaps()
        {
            return (third >= first && fourth <= second) || (first >= third && second <= fourth);
        }

        public bool OverlapsAtAll()
        {
            //2-6,4-8 overlaps in sections 4, 5, and 6//
            //if (1 <= x && x <= 100)
            if (first <= third && third <= second)
                return true;
            if (first <= fourth && fourth <= second)
                return true;
            if (third <= first && first <= fourth)
                return true;
            if (third <= second && second <= fourth)
                return true;
            return false;

        }
    }
}
