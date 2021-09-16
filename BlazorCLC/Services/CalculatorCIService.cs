using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCLC.Models;
using BlazorCLC.Interfaces;

namespace BlazorCLC.Services
{
    public class CalculatorCIService: ICalculatorCIService
    {

        public double Calculate(double startSum, double percentInYear, int times, int years)
        {
            double P = Convert.ToDouble(startSum);
            double i = Convert.ToDouble(percentInYear);
            int n = Convert.ToInt32(times);
            int t = Convert.ToInt32(years);

            return P * Math.Pow((1 + (i / 100.0) / n), (n * t));
        }
    }
}

