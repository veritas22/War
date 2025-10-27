using Logic.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public  class RotatableAdapter : IRotatable
    {
        GameSpace _game;

        public RotatableAdapter(GameSpace game) 
        {
            _game = game;
        }
        public int GetAngle()
        {
            return _game.Angle;
        }
        public int SetAngle(int angle)
        {
            _game.Angle = _game.Angle + angle;
            return _game.Angle;
        }
    }
}
