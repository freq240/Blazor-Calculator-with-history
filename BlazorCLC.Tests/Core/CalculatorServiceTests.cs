using System;
using System.Collections.Generic;
using System.Text;
using BlazorCLC.Models;
using BlazorCLC.Services;
using NUnit.Framework;
using Moq;


namespace BlazorCLC.Tests.Core
{
    [TestFixture]
    public class CalculatorServiceTests
    {
        private CalculatorService calculatorService;

        [SetUp]
        public void SetUp()
        {
            calculatorService = new CalculatorService();
        }
        // Calculate method tests

        // ADD
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(0, -5, ExpectedResult = -5)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 0.72525, ExpectedResult = 0.72525)]
        [TestCase(0, -0.4444, ExpectedResult = -0.4444)]
        [TestCase(2, 0, ExpectedResult = 2)]
        [TestCase(-2, 0, ExpectedResult = -2)]
        [TestCase(0.25, 0, ExpectedResult = 0.25)]
        [TestCase(-0.25, 0, ExpectedResult = -0.25)]
        [TestCase(5, 5, ExpectedResult = 10)]
        [TestCase(-5, -5, ExpectedResult = -10)]
        [TestCase(-5, 5, ExpectedResult = 0)]
        [TestCase(5, -5, ExpectedResult = 0)]
        [TestCase(0.25, 0.25, ExpectedResult = 0.5)]
        [TestCase(-0.25, -0.25, ExpectedResult = -0.5)]
        [TestCase(0.25, -0.25, ExpectedResult = 0)]
        [TestCase(-0.25, 0.25, ExpectedResult = -0)]
        public double CalculatorService_Add_CorrectAddedValue(double first, double second)
        {
            return calculatorService.Add(first, second);
        }

        // SUBTRACT
        [TestCase(0, 5, ExpectedResult = -5)]
        [TestCase(0, -5, ExpectedResult = 5)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 0.72525, ExpectedResult = -0.72525)]
        [TestCase(0, -0.4444, ExpectedResult = 0.4444)]
        [TestCase(2, 0, ExpectedResult = 2)]
        [TestCase(-2, 0, ExpectedResult = -2)]
        [TestCase(0.25, 0, ExpectedResult = 0.25)]
        [TestCase(-0.25, 0, ExpectedResult = -0.25)]
        [TestCase(5, 5, ExpectedResult = 0)]
        [TestCase(-5, -5, ExpectedResult = 0)]
        [TestCase(-5, 5, ExpectedResult = -10)]
        [TestCase(5, -5, ExpectedResult = 10)]
        [TestCase(0.25, 0.25, ExpectedResult = 0)]
        [TestCase(-0.25, -0.25, ExpectedResult = 0)]
        [TestCase(0.25, -0.25, ExpectedResult = 0.5)]
        [TestCase(-0.25, 0.25, ExpectedResult = -0.5)]
        public double CalculatorService_Subtract_CorrectSubtractedValue(double first, double second)
        {
            return calculatorService.Subtract(first, second);
        }

        // MULTIPLICATION
        [TestCase(0, 5, ExpectedResult = 0)]
        [TestCase(0, -5, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 0.72525, ExpectedResult = 0)]
        [TestCase(0, -0.4444, ExpectedResult = 0)]
        [TestCase(2, 0, ExpectedResult = 0)]
        [TestCase(-2, 0, ExpectedResult = 0)]
        [TestCase(0.25, 0, ExpectedResult = 0)]
        [TestCase(-0.25, 0, ExpectedResult = 0)]
        [TestCase(5, 5, ExpectedResult = 25)]
        [TestCase(-5, -5, ExpectedResult = 25)]
        [TestCase(-5, 5, ExpectedResult = -25)]
        [TestCase(5, -5, ExpectedResult = -25)]
        [TestCase(0.25, 0.25, ExpectedResult = 0.0625)]
        [TestCase(-0.25, -0.25, ExpectedResult = 0.0625)]
        [TestCase(0.25, -0.25, ExpectedResult = -0.0625)]
        [TestCase(-0.25, 0.25, ExpectedResult = -0.0625)]
        public double CalculatorService_Multiply_CorrectMultiplicatedValue(double first, double second)
        {
            return calculatorService.Multiply(first, second);
        }

        // DIVISION
        [TestCase(0, 5, ExpectedResult = 0)]
        [TestCase(0, -5, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = Double.NaN)]
        [TestCase(0, 0.72525, ExpectedResult = 0)]
        [TestCase(0, -0.4444, ExpectedResult = 0)]
        [TestCase(2, 0, ExpectedResult = Double.PositiveInfinity)]
        [TestCase(-2, 0, ExpectedResult = Double.NegativeInfinity)]
        [TestCase(0.25, 0, ExpectedResult = Double.PositiveInfinity)]
        [TestCase(-0.25, 0, ExpectedResult = Double.NegativeInfinity)]
        [TestCase(5, 5, ExpectedResult = 1)]
        [TestCase(-5, -5, ExpectedResult = 1)]
        [TestCase(-5, 5, ExpectedResult = -1)]
        [TestCase(5, -5, ExpectedResult = -1)]
        [TestCase(0.25, 0.25, ExpectedResult = 1)]
        [TestCase(-0.25, -0.25, ExpectedResult = 1)]
        [TestCase(0.25, -0.25, ExpectedResult = -1)]
        [TestCase(-0.25, 0.25, ExpectedResult = -1)]
        public double CalculatorService_Division_CorrectDividedValue(double first, double second)
        {
            return calculatorService.Divide(first, second);
        }

        // MODULE DIVISION
        [TestCase(0, 5, ExpectedResult = 0)]
        [TestCase(0, -5, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = Double.NaN)]
        [TestCase(0, 0.72525, ExpectedResult = 0)]
        [TestCase(0, -0.4444, ExpectedResult = 0)]
        [TestCase(2, 0, ExpectedResult = Double.NaN)]
        [TestCase(-2, 0, ExpectedResult = Double.NaN)]
        [TestCase(0.25, 0, ExpectedResult = Double.NaN)]
        [TestCase(-0.25, 0, ExpectedResult = Double.NaN)]
        [TestCase(5, 5, ExpectedResult = 0)]
        [TestCase(-5, -5, ExpectedResult = 0)]
        [TestCase(-5, 5, ExpectedResult = 0)]
        [TestCase(5, -5, ExpectedResult = 0)]
        [TestCase(0.25, 0.25, ExpectedResult = 0)]
        [TestCase(-0.25, -0.25, ExpectedResult = 0)]
        [TestCase(0.25, -0.25, ExpectedResult = 0)]
        [TestCase(-0.25, 0.25, ExpectedResult = 0)]
        [TestCase(5, 2, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 0)]
        [TestCase(28.5, 5, ExpectedResult = 3.5)]
        public double CalculatorService_ModuleDivide_CorrectModuleDividedValue(double first, double second)
        {
            return calculatorService.ModuleDivide(first, second);
        }


        // DIVISION BY ONE (1/x)
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(0, ExpectedResult = double.PositiveInfinity)]
        [TestCase(2, ExpectedResult = 0.5)]
        [TestCase(-1, ExpectedResult = -1)]
        [TestCase(-0.5, ExpectedResult = -2)]
        [TestCase(-2, ExpectedResult = -0.5)]
        public double CalculatorService_DivideByOne_CorrectDividedByOneValue(double first)
        {
            return calculatorService.DivideByOne(first);
        }

        // POW (x^2)
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 4)]
        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(-2, ExpectedResult = 4)]
        [TestCase(0.25, ExpectedResult = 0.0625)]
        [TestCase(-0.25, ExpectedResult = 0.0625)]
        [TestCase(0, ExpectedResult = 0)]
        public double CalculatorService_Pow_CorrectPowedValue(double first)
        {
            return calculatorService.Pow(first);
        }

        // SQRT (sqrt(x))
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 2)]
        [TestCase(-1, ExpectedResult = double.NaN)]
        [TestCase(0.0625, ExpectedResult = 0.25)]
        [TestCase(-0.0625, ExpectedResult = double.NaN)]
        [TestCase(0, ExpectedResult = 0)]
        public double CalculatorService_Sqrt_CorrectSquaredValue(double first)
        {
            return calculatorService.Sqrt(first);
        }
     
    }
}

