using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using BlazorCLC.Services;
using BlazorCLC.Interfaces;
using BlazorCLC.Models;

namespace BlazorCLCTests
{
    [TestFixture]
    public class CalculatorServiceCITests
    {
        private CalculatorCIService calculatorCIService;

        [SetUp]
        public void Setup()
        {
            calculatorCIService = new CalculatorCIService(new CalculatorCIState());
        }

        [Test]
        public void ShowCompoundInterestMenu_CloseMenu_FlagIsTrueShouldBeFalse()
        {
            calculatorCIService.calc.FlagCImenuActive = true;
            calculatorCIService.ShowCompoundInterestMenu();

            Assert.IsFalse(calculatorCIService.calc.FlagCImenuActive);
        }
        [Test]
        public void ShowCompoundInterestMenu_OpenMenu_FlagIsFalseShouldBeTrue()
        {
            calculatorCIService.calc.FlagCImenuActive = false;
            calculatorCIService.ShowCompoundInterestMenu();

            Assert.IsTrue(calculatorCIService.calc.FlagCImenuActive);
        }

        [Test]
        [TestCase("10000", "12.5", "1", "1", 11250)]
        [TestCase("100000", "30", "4", "5", 424785.11)]
        [TestCase("-50", "12.5", "1", "1", 0)]
        [TestCase("10000", "12.5", "1", "-1", 0)]
        public void Calculate_DifferentDataInput_ShouldRightCalculationProvided(string startSum, string percentInYear, string times, string years, double expected)
        {
            calculatorCIService.Calculate(startSum, percentInYear, times, years);
            Assert.That(calculatorCIService.calc.ValueCI, Is.EqualTo(expected).Within(1));
        }
    }
}
