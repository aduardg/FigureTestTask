using FigureLib.AbstractClasses;

namespace FigureLib.Interfaces;

public interface IFigureFactory
{
    /// <summary>
    /// Создает тип фигуры по сторонам
    /// </summary>
    /// <param name="sides">Стороны</param>
    /// <returns>Фигура</returns>
    public Figure CreateFigure(List<double> sides);
}
