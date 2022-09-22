using Xunit;
using NeoStackTask.ViewModels;
using NeoStackTask.Models;

namespace Tests
{
    public class Class1
    {
        [Theory]
        [InlineData(2,5,3,2,4,12)]
        [InlineData(2, 5, 3, 0, 0, 8)]
        [InlineData(2, 5, 3, -5, 10, -2)]
        public void LinearFunctionCalculatedCorrect(double a, double b, double c, double X, double y, double expected)
        {
            FunctionModel model = new FunctionModel("Линейная",
                new List<double> { 1, 2, 3, 4, 5 },
                (a, b, c, x, y) => a * X + b * 1 + c)
            { A = a, B = b, C = c };

            FunctionTableRow result = new FunctionTableRow();
            result.SetFunction(model);

            Assert.Equal
        }
    }
}