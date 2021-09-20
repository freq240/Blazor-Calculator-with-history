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
            double StartSum = Convert.ToDouble(startSum);
            double PercentInYear = Convert.ToDouble(percentInYear);
            int Times = Convert.ToInt32(times);
            int Years = Convert.ToInt32(years);

            return StartSum * Math.Pow((1 + (PercentInYear / 100.0) / Times), (Times * Years));
        }
    }
}

