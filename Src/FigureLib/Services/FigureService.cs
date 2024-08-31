using FigureLib.AbstractClasses;
using FigureLib.Interfaces;
using FigureLib.Models;
using FigureLib.Services.Factory;

namespace FigureLib.Services;

public class FigureService : IFigureService
{
    private readonly IFigureFactory _figureFactory;

    public FigureService()
    {
        _figureFactory = new FigureFactory();
    }

    ///Вернёт 0, если фигура не фигура или количество сторон фигуры равно 0
    ///В этот сервис с switch дописываем ваши формулы фигур
    public double GetAreaFigure<T>(T figure) where T : Figure
    {
        if (figure.Sides.Count == 0)
        {
            Console.WriteLine("error: не удается подсчитать площадь, у фигуры отсутствуют стороны");
            return 0;
        }

        switch (figure)
        {
            case Circle:
                return GetAreaCircle(figure.Sides);
            case Triangle:
                return GetAreaTriangle(figure.Sides);
            default:
                Console.WriteLine("error: не удается подсчитать площадь, для данного типа фигуры нет формулы расчета площади");
                return 0;
        }
    }

    public double GetAreaFigureFromSides(List<double> sides)
    {
        try
        {
            var figure = _figureFactory.CreateFigure(sides);
            return GetAreaFigure(figure);
        }
        catch(Exception ex) 
        {
            Console.WriteLine($"error: {ex.Message}");
            return 0;
        }
    }

    //Регион, куда можно выносить расчет площадей для подстановки в основной метод
    #region Utility
    private double GetAreaCircle(List<double> sides)
    {
        return 2 * Math.PI * sides[0] * sides[0];
    }

    private double GetAreaTriangle(List<double> sides)
    {
        var perimeter = (sides[0] + sides[1] + sides[2]) / 2;

        return Math.Sqrt(
            perimeter *
            (perimeter - sides[0]) *
            (perimeter - sides[1]) *
            (perimeter - sides[2]));
    }
    #endregion
}
