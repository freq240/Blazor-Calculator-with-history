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
    public class CalculatorCIServiceTests
    {
        private CalculatorCIService calculatorCIService;

        [SetUp]
        public void SetUp()
        {
            calculatorCIService = new CalculatorCIService();
        }

        [Test]
        [TestCase(10000, 12.5, 1, 1, 11250)]
        [TestCase(100000, 30, 4, 5, 424785.11)]
        [TestCase(-50, 12.5, 1, 1, 0)]
        [TestCase(10000, 12.5, 1, -1, 0)]
        public void CalculatorCIService_Calculate_ShouldRightCalculationProvided(double startSum, double percentInYear, int times, int years, double expected)
        {
            Assert.That(calculatorCIService.Calculate(startSum, percentInYear, times, years), Is.EqualTo(expected).Within(1));
        }
    }
}
