using FigureLib.AbstractClasses;
using FigureLib.Interfaces;

namespace FigureLib.Models;

public class Circle : Figure
{
    public Circle(List<double> sides) : base(sides) { }

    private protected override bool ValidateSides(List<double> sides)
    {
        if (sides.Count != 1 || sides.Any(x => x <= 0))
        {
            Console.WriteLine("error: переданные аргументы не соответствуют фигуре - круг");
            return false;
        }

        return true;
    }
}
