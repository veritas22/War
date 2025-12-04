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
            if (_game == null)
                throw new InvalidOperationException("Невозможно прочитать положение: объект GameSpace не инициализирован");
            
            if (_game.Point == null)
                throw new InvalidOperationException("Невозможно прочитать положение в пространстве: Point равен null");

            return _game.Point;
        }

        public Point GetVelocity()
        {
            if (_game == null)
                throw new InvalidOperationException("Невозможно прочитать скорость: объект GameSpace не инициализирован");
            
            // Проверяем, что скорость может быть прочитана
            // Velocity - это int, но может быть ситуация, когда объект не поддерживает чтение скорости
            // Для проверки используем try-catch или проверяем доступность свойства
            try
            {
                var velocity = _game.Velocity;
                // Возвращаем скорость как Point (используем Velocity как компонент X, 0 как Y)
                // Или можно использовать Velocity для обоих компонентов, если это скалярная скорость
                return new Point() { PositionX = velocity, PositionY = 0 };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Невозможно прочитать значение мгновенной скорости", ex);
            }
        }

        public void SetPosition(Point point)
        {
            if (_game == null)
                throw new InvalidOperationException("Невозможно изменить положение: объект GameSpace не инициализирован");
            
            if (_game.Point == null)
                throw new InvalidOperationException("Невозможно прочитать текущее положение в пространстве: Point равен null");

            // Проверяем, что скорость может быть прочитана перед движением
            try
            {
                var velocity = GetVelocity();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Невозможно прочитать значение мгновенной скорости");
            }

            // Проверяем, что можно изменить положение в пространстве
            try
            {
                var newPosition = new Point() {PositionX = point.PositionX + _game.Point.PositionX, PositionY = point.PositionY + _game.Point.PositionY };
                _game.Point = newPosition;
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is NotSupportedException || ex is UnauthorizedAccessException)
            {
                throw new InvalidOperationException("Невозможно изменить положение в пространстве", ex);
            }
        }
    }
}
