using Logic.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GameSpace
    {
        public Point Point { get; set; }
        public int Velocity { get; set; }
        public int Angle { get; set; }
    }

    public class Point
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
