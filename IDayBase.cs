using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal interface IDayBase
    {
        public int Day { get; }
        public void ExecutePart1();
        public void ExecutePart2();
        public void LoadInput();
    }
}
