using FigureLib.AbstractClasses;

namespace FigureLib.Interfaces;

public interface IFigureService
{
    /// <summary>
    /// Функция расчета площади фигуры
    /// </summary>
    /// <typeparam name="T">Класс, наследуемый от Figure</typeparam>
    /// <param name="figure">Фигура</param>
    /// <returns>Площадь фигуры</returns>
    public double GetAreaFigure<T>(T figure) where T: Figure;

    /// <summary>
    /// Функция расчета площади фигуры по сторонам
    /// </summary>
    /// <param name="sides">Стороны фигуры</param>
    /// <returns>Площадь фигуры</returns>
    public double GetAreaFigureFromSides(List<double> sides);
}
