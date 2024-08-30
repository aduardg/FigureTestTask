using FigureLib.Interfaces;

namespace FigureLib.AbstractClasses;

public abstract class Figure : IFigure
{
    /// <summary>
    /// Коллекция сторон фигуры
    /// </summary>
    public List<double> Sides { get; private set; } = new List<double>();

    public Figure(List<double> sides)
    {
        if (ValidateSides(sides))
        {
            Sides.AddRange(sides);
        }
    }

    /// <summary>
    /// Метод смены сторон фигуры
    /// </summary>
    /// <param name="sides">Стороны фигуры</param>
    public virtual void SetSides(List<double> sides)
    {
        if (ValidateSides(sides))
        {
            Sides.Clear();
            sides.AddRange(sides);
        }
    }

    /// <summary>
    /// Функция валидация фигуры
    /// </summary>
    /// <param name="sides">Передаваемые стороны для проверки</param>
    /// <returns>Флаг валидации</returns>
    private protected abstract bool ValidateSides(List<double> sides);
}
