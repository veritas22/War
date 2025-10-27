using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfase
{
    public interface IGameSpace
    {
        Point Point { get; set; }
        int Velocity { get; set; }
        int Angle { get; set; }
    }
}
