using Logic.Interfase;
using System;

namespace Logic
{
    /// <summary>
    /// Класс для выполнения поворота объектов, реализующих интерфейс IRotatable
    /// </summary>
    public class Rotate
    {
        private readonly IRotatable _rotatable;

        public Rotate(IRotatable rotatable)
        {
            _rotatable = rotatable;
        }

        /// <summary>
        /// Выполняет поворот объекта на указанный угол
        /// </summary>
        /// <param name="angle">Угол поворота в градусах</param>
        public void Execute(int angle)
        {
            // Проверяем, что можно прочитать текущий угол
            try
            {
                var currentAngle = _rotatable.GetAngle();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Невозможно прочитать текущий угол поворота", ex);
            }

            // Выполняем поворот
            try
            {
                _rotatable.SetAngle(angle);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Невозможно изменить угол поворота", ex);
            }
        }
    }
}

