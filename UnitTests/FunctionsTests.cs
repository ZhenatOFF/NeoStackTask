using NeoStackTask.Models;
using NeoStackTask.ViewModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class FunctionsTests
    {
        [Theory]
        [InlineData(2, 5, 3, 2, 4, 12)]
        [InlineData(2, 5, 3, 0, 0, 8)]
        [InlineData(2, 5, 3, -5, 10, -2)]
        public void LinearFunctionCalculatedCorrect(double A, double B, double C, double X, double Y, double expected)
        {
            //Arrange
            FunctionModel model = new FunctionModel("Линейная",
                new List<double> { 1, 2, 3, 4, 5 },
                (a, b, c, x, y) => a * x + b * 1 + c)
                { C = C };

            FunctionModel.A = A;
            FunctionModel.B = B;

            FunctionTableRow row = new FunctionTableRow();
            row.SetFunction(model);
            row.X = X;
            row.Y = Y;

            //Act
            double? result = row.F;

            //Assert
            Assert.Equal(result, expected);
        }


        [Theory]
        [InlineData(3,-2,10,0,0,10)]
        [InlineData(-2,4,20,3,-4,-14)]
        public void QuadraticFunctionCalculatedCorrect(double A, double B, double C, double X, double Y, double expected)
        {
            //Arrange
            FunctionModel model = new FunctionModel("Квадратичная",
                new List<double> { 10, 20, 30, 40, 50 },
                (a, b, c, x, y) => a * Math.Pow(x, 2) + b * Math.Pow(y, 1) + c)
                {  C = C };

            FunctionModel.A = A;
            FunctionModel.B = B;

            FunctionTableRow row = new FunctionTableRow();
            row.SetFunction(model);
            row.X = X;
            row.Y = Y;

            //Act
            double? result = row.F;

            //Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(-5,2,200,3,2,73)]
        public void ThirdDegreeFunctionCalculatedCorrect(double A, double B, double C, double X, double Y, double expected)
        {
            //Arrange
            FunctionModel model = new FunctionModel("Кубическая",
                new List<double> { 100, 200, 300, 400, 500 },
                (a, b, c, x, y) => a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c)
            { C = C };

            FunctionModel.A = A;
            FunctionModel.B = B;

            FunctionTableRow row = new FunctionTableRow();
            row.SetFunction(model);
            row.X = X;
            row.Y = Y;

            //Act
            double? result = row.F;

            //Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(2,-6,3000,3,-4,3546)]
        [InlineData(2,-6,3000,0,-10,9000)]
        public void FourthDegreeFunctionCalculatedCorrect(double A, double B, double C, double X, double Y, double expected)
        {
            //Arrange
            FunctionModel model = new FunctionModel("4-ой степени",
                new List<double> { 1000, 2000, 3000, 4000, 5000 },
                (a, b, c, x, y) => a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c)
            { C = C };

            FunctionModel.A = A;
            FunctionModel.B = B;

            FunctionTableRow row = new FunctionTableRow();
            row.SetFunction(model);
            row.X = X;
            row.Y = Y;

            //Act
            double? result = row.F;

            //Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(2,-3,10000, -4,2,7904)]
        public void FifthDegreeFunctionCalculatedCorrect(double A, double B, double C, double X, double Y, double expected)
        {
            //Arrange
            FunctionModel model = new FunctionModel("5-ой степени",
                new List<double> { 10000, 20000, 30000, 40000, 50000 },
                (a, b, c, x, y) => a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c)
            {C = C };

            FunctionModel.A = A;
            FunctionModel.B = B;

            FunctionTableRow row = new FunctionTableRow();
            row.SetFunction(model);
            row.X = X;
            row.Y = Y;

            //Act
            double? result = row.F;

            //Assert
            Assert.Equal(result, expected);
        }
    }
}