using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.Interfase
{

    public interface IMovable
    {

        public Point GetPosition();

        public void SetPosition(Point point);
    }


}
