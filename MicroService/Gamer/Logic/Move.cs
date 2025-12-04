using Logic.Interfase;
using System;

namespace Logic
{
    /// <summary>
    /// Класс для выполнения движения объектов, реализующих интерфейс IMovable
    /// </summary>
    public class Move
    {
        private readonly IMovable _movable;

        public Move(IMovable movable)
        {
            _movable = movable ?? throw new ArgumentNullException(nameof(movable));
        }

        /// <summary>
        /// Выполняет движение объекта на указанное смещение
        /// </summary>
        /// <param name="velocity">Смещение (скорость) для движения</param>
        public void Execute(Point velocity)
        {
            if (velocity == null)
                throw new ArgumentNullException(nameof(velocity));

            // Проверяем, что можно прочитать текущее положение
            Point currentPosition;
            try
            {
                currentPosition = _movable.GetPosition();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Невозможно прочитать положение в пространстве", ex);
            }

            // Проверяем, что можно прочитать скорость
            try
            {
                var currentVelocity = _movable.GetVelocity();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Невозможно прочитать значение мгновенной скорости", ex);
            }

            // Выполняем движение (SetPosition принимает смещение и добавляет его к текущей позиции)
            try
            {
                _movable.SetPosition(velocity);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Невозможно изменить положение в пространстве", ex);
            }
        }
    }
}

