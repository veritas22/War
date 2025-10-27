using Logic.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public  class MovableAdapter: IMovable
    {
        GameSpace _game;

        public MovableAdapter(GameSpace game) 
        {
            _game = game;
        }

        public Point GetPosition()
        {
            return _game.Point;
        }

        public void SetPosition(Point point)
        {
            _game.Point = new Point() {PositionX = point.PositionX + _game.Point.PositionX, PositionY = point.PositionY + _game.Point.PositionY };
        }
    }
}
