using FigureLib.AbstractClasses;

namespace FigureLib.Models;

public class Triangle : Figure
{
    public Triangle(List<double> sides) : base(sides) { }

    private protected override bool ValidateSides(List<double> sides)
    {
        if (sides.Count != 3 || sides.Any(x => x <= 0))
        {
            Console.WriteLine("error: переданные аргументы не соответствуют фигуре - треугольник");
            return false;
        }

        return true;
    }

    public bool IsRectangular()
    {
        ///Тут сомнение, т.к. нужно ввести данную проверку, если фигура треугольник будет создана не через фабрику
        if (Sides.Count == 0)
        {
            Console.WriteLine("error: у фигуры - треугольник отсутствуют стороны для расчета на прямоугольный треугольник");
            return false;
        }

        var bigSide = Sides.Max();
        var otherSides = from otherSide in Sides
                         where otherSide != bigSide
                         select otherSide;

        if (otherSides.Count() != 2)
        {
            return false;
        }

        return bigSide * bigSide ==
            otherSides.First() * otherSides.First() +
            otherSides.Last() * otherSides.Last();
    }
}
