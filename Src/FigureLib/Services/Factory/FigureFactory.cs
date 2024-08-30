using FigureLib.AbstractClasses;
using FigureLib.Interfaces;
using FigureLib.Models;

namespace FigureLib.Services.Factory;

public class FigureFactory : IFigureFactory
{
    public Figure CreateFigure(List<double> sides)
    {
        switch (sides.Count)
        {
            case 1:
                return new Circle(sides);
            case 3:
                return new Triangle(sides);
            default:
                throw new ArgumentException("Нет типа фигур с количеством переданных сторон");
        }
    }
}
