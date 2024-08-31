using FigureLib.Interfaces;
using FigureLib.Models;
using FigureLib.Services;
using FigureLib.Services.Factory;

namespace FigureLibTest.Tests;

public class FigureServiceTest
{
    private IFigureFactory _figureFactory;
    private IFigureService _figureService;

    [SetUp]
    public void SetUp()
    {
        _figureFactory = new FigureFactory();
        _figureService = new FigureService();
    }

    #region Circle
    /// <summary>
    /// Вернёт 0
    /// </summary>
    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void GetAreaCircle_NotValid(double radius)
    {
        var figure = _figureFactory.CreateFigure(new List<double> { radius });

        var result = _figureService.GetAreaFigure(figure);
        Assert.That(result ,Is.EqualTo(0));
    }

    [Test]
    [TestCase(1d)]
    [TestCase(1.2)]
    [TestCase(5d)]
    [TestCase(7.5)]
    public void GetAreaCircle_Valid(double radius) 
    {
        var figure = _figureFactory.CreateFigure(new List<double> { radius });

        var result = _figureService.GetAreaFigure(figure);
        double validResult = 2 * Math.PI * radius * radius;

        Assert.That(result, Is.EqualTo(validResult));
    }
    #endregion

    #region Triangle
    /// <summary>
    /// Вернет 0
    /// </summary>
    /// <param name="a">1-ая сторона треугольника</param>
    /// <param name="b">2-ая сторона треугольника</param>
    /// <param name="c">3-я сторона треугольника</param>
    [Test]
    [TestCase(-1d, 0d, 5d)]
    [TestCase(0d, 0d, 0d)]
    public void GetAreaTriangle_NotValid(double a, double b, double c)
    {
        var figure = _figureFactory.CreateFigure(new List<double>() { a, b, c });

        var result = _figureService.GetAreaFigure(figure);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    [TestCase(13, 14, 15)]
    public void GetAreaTriangle_Valid(double a, double b, double c)
    {
        var figure = _figureFactory.CreateFigure(new List<double>() { a, b, c });

        var result = _figureService.GetAreaFigure(figure);
        Assert.That(result, Is.EqualTo(84));
    }

    [Test]
    [TestCase(13, 14, 15)]
    [TestCase(5, 13, 13)]
    public void IsRectangular_NotValid(double a, double b, double c)
    {
        var figure = _figureFactory.CreateFigure(new List<double>() { a, b, c });

        var isRectangular = ((Triangle)figure).IsRectangular();
        Assert.IsFalse(isRectangular);
    }

    [Test]
    [TestCase(3, 4, 5)]
    [TestCase(8, 6, 10)]
    [TestCase(5, 13, 12)]
    public void IsRectangular_Valid(double a, double b, double c)
    {
        var figure = _figureFactory.CreateFigure(new List<double>() { a, b, c });

        var isRectangular = ((Triangle)figure).IsRectangular();
        Assert.IsTrue(isRectangular);
    }
    #endregion
}
