using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Moq;

using BlazorCLC.Models;
using BlazorCLC.Services;
namespace BlazorCLCTests
{
    [TestFixture]
    public class CalculatorServiceTests
    {
        private CalculatorService calculatorService;

        [SetUp]
        public void SetUp()
        {
            calculatorService = new CalculatorService(new CalculatorState());
        }

        // Help-methods
        private double CallOperation(double first, string second, int count)
        {
            calculatorService.calc.Operation = count; // + opperation
            calculatorService.calc.DigitFirst = first;
            calculatorService.calc.ValueFirst = second;

            calculatorService.Calculate();

            return calculatorService.calc.DigitSecond;
        }

        private double ChooseOperation(double first, string second, int count)
        {
            calculatorService.calc.Operation = count; // + opperation
            calculatorService.calc.DigitFirst = first;
            calculatorService.calc.ValueSecond = second;

            calculatorService.Calculate();

            return calculatorService.calc.DigitSecond;

            // Дописать этот метод, разобраться с моками, дотестить интовый баттонклик и сделать тесты дял clcCI, возможно прописать интерфейсы для DI, скинуть паше и получить фидбек
            // Если будет желание переписать в тестах ретурны на ассерты
        }

        // Clear method tests
        [Test]
        public void Clear_DeletingAll_AllSymbolsDeleted()
        {

            calculatorService.calc.ValueFirst = "123";
            calculatorService.calc.ValueSecond = "456";

            calculatorService.Clear(0);

            Assert.IsTrue(calculatorService.calc.ValueFirst == "");
            Assert.IsTrue(calculatorService.calc.ValueSecond == "");
        }

        [Test]
        public void Clear_DeletingLastSymbol_LastSymbolDeleted()
        {

            calculatorService.calc.ValueFirst = "12345";

            calculatorService.Clear(1);

            Assert.IsTrue(calculatorService.calc.ValueFirst == "1234");
        }

        [Test]
        public void Clear_IsEmptyAll_AllEmpty()
        {

            calculatorService.Clear(0);

            Assert.IsEmpty(calculatorService.calc.ValueFirst);
            Assert.IsEmpty(calculatorService.calc.ValueSecond);
        }

       
        // Calculate method tests
        
        // ADD
        [TestCase (0, "5", ExpectedResult = 5)]
        [TestCase(0, "-5", ExpectedResult = -5)]
        [TestCase(0, "0", ExpectedResult = 0)]
        [TestCase(0, "0.72525", ExpectedResult = 0.72525)]
        [TestCase(0, "-0.4444", ExpectedResult = -0.4444)]
        [TestCase(2, "0", ExpectedResult = 2)]
        [TestCase(-2, "0", ExpectedResult = -2)]
        [TestCase(0.25, "0", ExpectedResult = 0.25)]
        [TestCase(-0.25, "0", ExpectedResult = -0.25)]
        [TestCase(5, "5", ExpectedResult = 10)]
        [TestCase(-5, "-5", ExpectedResult = -10)]
        [TestCase(-5, "5", ExpectedResult = 0)]
        [TestCase(5, "-5", ExpectedResult = 0)]
        [TestCase(0.25, "0.25", ExpectedResult = 0.5)]
        [TestCase(-0.25, "-0.25", ExpectedResult = -0.5)]
        [TestCase(0.25, "-0.25", ExpectedResult = 0)]
        [TestCase(-0.25, "0.25", ExpectedResult = -0)]
        public double Calculate_AddOperation_CorrectAddedValue(double first, string second)
        {
            return CallOperation(first, second, ((int)Operations.Add));
        }

        // SUBTRACT
        [TestCase(0, "5", ExpectedResult = -5)]
        [TestCase(0, "-5", ExpectedResult = 5)]
        [TestCase(0, "0", ExpectedResult = 0)]
        [TestCase(0, "0.72525", ExpectedResult = -0.72525)]
        [TestCase(0, "-0.4444", ExpectedResult = 0.4444)]
        [TestCase(2, "0", ExpectedResult = 2)]
        [TestCase(-2, "0", ExpectedResult = -2)]
        [TestCase(0.25, "0", ExpectedResult = 0.25)]
        [TestCase(-0.25, "0", ExpectedResult = -0.25)]
        [TestCase(5, "5", ExpectedResult = 0)]
        [TestCase(-5, "-5", ExpectedResult = 0)]
        [TestCase(-5, "5", ExpectedResult = -10)]
        [TestCase(5, "-5", ExpectedResult = 10)]
        [TestCase(0.25, "0.25", ExpectedResult = 0)]
        [TestCase(-0.25, "-0.25", ExpectedResult = 0)]
        [TestCase(0.25, "-0.25", ExpectedResult = 0.5)]
        [TestCase(-0.25, "0.25", ExpectedResult = -0.5)]
        public double Calculate_SubtractOperation_CorrectSubtractedValue(double first, string second)
        {
            return CallOperation(first, second, ((int)Operations.Subtract));
        }

        // MULTIPLICATION
        [TestCase(0, "5", ExpectedResult = 0)]
        [TestCase(0, "-5", ExpectedResult = 0)]
        [TestCase(0, "0", ExpectedResult = 0)]
        [TestCase(0, "0.72525", ExpectedResult = 0)]
        [TestCase(0, "-0.4444", ExpectedResult = 0)]
        [TestCase(2, "0", ExpectedResult = 0)]
        [TestCase(-2, "0", ExpectedResult = 0)]
        [TestCase(0.25, "0", ExpectedResult = 0)]
        [TestCase(-0.25, "0", ExpectedResult = 0)]
        [TestCase(5, "5", ExpectedResult = 25)]
        [TestCase(-5, "-5", ExpectedResult = 25)]
        [TestCase(-5, "5", ExpectedResult = -25)]
        [TestCase(5, "-5", ExpectedResult = -25)]
        [TestCase(0.25, "0.25", ExpectedResult = 0.0625)]
        [TestCase(-0.25, "-0.25", ExpectedResult = 0.0625)]
        [TestCase(0.25, "-0.25", ExpectedResult = -0.0625)]
        [TestCase(-0.25, "0.25", ExpectedResult = -0.0625)]
        public double Calculate_MultiplicationOperation_CorrectMultiplicatedValue(double first, string second)
        {
            return CallOperation(first, second, ((int)Operations.Multiplication));
        }

        // DIVISION
        [TestCase(0, "5", ExpectedResult = 0)]
        [TestCase(0, "-5", ExpectedResult = 0)]
        [TestCase(0, "0", ExpectedResult = Double.NaN)]
        [TestCase(0, "0.72525", ExpectedResult = 0)]
        [TestCase(0, "-0.4444", ExpectedResult = 0)]
        [TestCase(2, "0", ExpectedResult = Double.PositiveInfinity)]
        [TestCase(-2, "0", ExpectedResult = Double.NegativeInfinity)]
        [TestCase(0.25, "0", ExpectedResult = Double.PositiveInfinity)]
        [TestCase(-0.25, "0", ExpectedResult = Double.NegativeInfinity)]
        [TestCase(5, "5", ExpectedResult = 1)]
        [TestCase(-5, "-5", ExpectedResult = 1)]
        [TestCase(-5, "5", ExpectedResult = -1)]
        [TestCase(5, "-5", ExpectedResult = -1)]
        [TestCase(0.25, "0.25", ExpectedResult = 1)]
        [TestCase(-0.25, "-0.25", ExpectedResult = 1)]
        [TestCase(0.25, "-0.25", ExpectedResult = -1)]
        [TestCase(-0.25, "0.25", ExpectedResult = -1)]
        public double Calculate_DivisionOperation_CorrectDividedValue(double first, string second)
        {
            return CallOperation(first, second, ((int)Operations.Division));
        }

        // MODULE DIVISION
        [TestCase(0, "5", ExpectedResult = 0)]
        [TestCase(0, "-5", ExpectedResult = 0)]
        [TestCase(0, "0", ExpectedResult = Double.NaN)]
        [TestCase(0, "0.72525", ExpectedResult = 0)]
        [TestCase(0, "-0.4444", ExpectedResult = 0)]
        [TestCase(2, "0", ExpectedResult = Double.NaN)]
        [TestCase(-2, "0", ExpectedResult = Double.NaN)]
        [TestCase(0.25, "0", ExpectedResult = Double.NaN)]
        [TestCase(-0.25, "0", ExpectedResult = Double.NaN)]
        [TestCase(5, "5", ExpectedResult = 0)]
        [TestCase(-5, "-5", ExpectedResult = 0)]
        [TestCase(-5, "5", ExpectedResult = 0)]
        [TestCase(5, "-5", ExpectedResult = 0)]
        [TestCase(0.25, "0.25", ExpectedResult = 0)]
        [TestCase(-0.25, "-0.25", ExpectedResult = 0)]
        [TestCase(0.25, "-0.25", ExpectedResult = 0)]
        [TestCase(-0.25, "0.25", ExpectedResult = 0)]
        [TestCase(5, "2", ExpectedResult = 1)]
        [TestCase(25, "5", ExpectedResult = 0)]
        [TestCase(28.5, "5", ExpectedResult = 3.5)]
        public double Calculate_ModuleDivisionOperation_CorrectModuleDividedValue(double first, string second)
        {
            return CallOperation(first, second, ((int)Operations.ModuleDivision));
        }




        // DIVISION BY ONE (1/x)
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(0, ExpectedResult = double.PositiveInfinity)]
        [TestCase(2, ExpectedResult = 0.5)]
        [TestCase(-1, ExpectedResult = -1)]
        [TestCase(-0.5, ExpectedResult = -2)]
        [TestCase(-2, ExpectedResult = -0.5)]
        public double Calculate_DivisionByOneOperation_CorrectDividedByOneValue(double first)
        {
            calculatorService.calc.Operation = (int)Operations.DivisionByOne;
            calculatorService.calc.DigitFirst = first;

            calculatorService.Calculate();

            return calculatorService.calc.DigitSecond;
        }

        // POW (x^2)
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 4)]
        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(-2, ExpectedResult = 4)]
        [TestCase(0.25, ExpectedResult = 0.0625)]
        [TestCase(-0.25, ExpectedResult = 0.0625)]
        [TestCase(0, ExpectedResult = 0)]
        public double Calculate_PowOperation_CorrectPowedValue(double first)
        {
            calculatorService.calc.Operation = (int)Operations.Pow;
            calculatorService.calc.DigitFirst = first;

            calculatorService.Calculate();

            return calculatorService.calc.DigitSecond;
        }

        // SQRT (sqrt(x))
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 2)]
        [TestCase(-1, ExpectedResult = double.NaN)]
        [TestCase(0.0625, ExpectedResult = 0.25)]
        [TestCase(-0.0625, ExpectedResult = double.NaN)]
        [TestCase(0, ExpectedResult = 0)]
        public double Calculate_SqrtOperation_CorrectSquaredValue(double first)
        {
            calculatorService.calc.Operation = (int)Operations.Sqrt;
            calculatorService.calc.DigitFirst = first;

            calculatorService.Calculate();

            return calculatorService.calc.DigitSecond;
        }


        // ButtonClick(string) method tests
        [TestCase("", "5", ExpectedResult = "5")]
        [TestCase("", "-", ExpectedResult = "-")]
        [TestCase("1", "5", ExpectedResult = "15")]
        [TestCase("5", "5", ExpectedResult = "55")]
        [TestCase("-", "5", ExpectedResult = "-5")]
        [TestCase("5", ".", ExpectedResult = "5.")]
        [TestCase("0.25", ".", ExpectedResult = "0.25")]
        [TestCase("5.", ".", ExpectedResult = "5.")]
        public string ButtonClick_SymbolOfDigits_CorrectAddingSymbolsToString(string beforeString, string added)
        {
            calculatorService.calc.ValueFirst = beforeString;

            calculatorService.ButtonClick(added);

            return calculatorService.calc.ValueFirst;
        }


        // ButtonClick(int) method tests

        // Case 1
        [TestCase("5", " + ", ExpectedResult = "5 + ")]
        [TestCase("-2", " + ", ExpectedResult = "-2 + ")]
        [TestCase("0.25", " + ", ExpectedResult = "0.25 + ")]
        [TestCase("0.25", " + ", ExpectedResult = "0.25 + ")]
        [TestCase("0", " + ", ExpectedResult = "0 + ")]
        public string ButtonClick_IntInSwitch_CorrectAddingOperationsToString(string beforeString, string added)
        {
            calculatorService.calc.ValueFirst = beforeString;

            calculatorService.ButtonClick(added);

            return calculatorService.calc.ValueFirst;
        }

        [TestCase("5", " - ", ExpectedResult = "5 - ")]
        [TestCase("-2", " - ", ExpectedResult = "-2 - ")]
        [TestCase("0.25", " - ", ExpectedResult = "0.25 - ")]
        [TestCase("0.25", " - ", ExpectedResult = "0.25 - ")]
        [TestCase("0", " - ", ExpectedResult = "0 - ")]
        public string ButtonClick_IntInSwitch_CorrectSubtractOperationsToString(string beforeString, string added)
        {
            calculatorService.calc.ValueFirst = beforeString;

            calculatorService.ButtonClick(added);

            return calculatorService.calc.ValueFirst;
        }

        [TestCase("0", " * ", ExpectedResult = "0 * ")]
        [TestCase("1", " * ", ExpectedResult = "1 * ")]
        [TestCase("-1", " * ", ExpectedResult = "-1 * ")]
        [TestCase("-0.25", " * ", ExpectedResult = "-0.25 * ")]
        [TestCase("0.25", " * ", ExpectedResult = "0.25 * ")]
        public string ButtonClick_IntInSwitch_CorrectMultiplyOperationsToString(string beforeString, string added)
        {
            calculatorService.calc.ValueFirst = beforeString;

            calculatorService.ButtonClick(added);

            return calculatorService.calc.ValueFirst;
        }

        [TestCase("0", " / ", ExpectedResult = "0 / ")]
        [TestCase("1", " / ", ExpectedResult = "1 / ")]
        [TestCase("-1", " / ", ExpectedResult = "-1 / ")]
        [TestCase("-0.25", " / ", ExpectedResult = "-0.25 / ")]
        [TestCase("0.25", " / ", ExpectedResult = "0.25 / ")]
        public string ButtonClick_IntInSwitch_CorrectDivisionOperationsToString(string beforeString, string added)
        {
            calculatorService.calc.ValueFirst = beforeString;

            calculatorService.ButtonClick(added);

            return calculatorService.calc.ValueFirst;
        }

        [TestCase("0", " % ", ExpectedResult = "0 % ")]
        [TestCase("1", " % ", ExpectedResult = "1 % ")]
        [TestCase("-1", " % ", ExpectedResult = "-1 % ")]
        [TestCase("-0.25", " % ", ExpectedResult = "-0.25 % ")]
        [TestCase("0.25", " % ", ExpectedResult = "0.25 % ")]
        public string ButtonClick_IntInSwitch_CorrectDivisionByOneOperationsToString(string beforeString, string added)
        {
            calculatorService.calc.ValueFirst = beforeString;

            calculatorService.ButtonClick(added);

            return calculatorService.calc.ValueFirst;
        }
        
        public void Test()
        {
            var mock = new Mock<CalculatorService>(new CalculatorState());

            mock.Setup(x => x.Calculate()).Verifiable();
            calculatorService.ButtonClick(6);
            mock.Verify();
            

        }

    }
}
