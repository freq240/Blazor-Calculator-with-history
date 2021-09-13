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
        public ICalculatorCI calc;

        public CalculatorCIService(ICalculatorCI _calc)
        {
            this.calc = _calc;
        }

        public void ShowCompoundInterestMenu()
        {
            if (calc.FlagCImenuActive)
            {
                calc.FlagCImenuActive = false;
            }
            else
            {
                calc.FlagCImenuActive = true;
            }
        }

        public void Calculate(string startSum, string percentInYear, string times, string years)
        {
            try
            {
                double P = Convert.ToDouble(startSum);
                double i = Convert.ToDouble(percentInYear);
                int n = Convert.ToInt32(times);
                int t = Convert.ToInt32(years);

                if (P < 1 || i < 0 || n < 1 || t < 1)
                {
                    calc.IncorrectInputCI = true;
                }
                else
                {
                    calc.IncorrectInputCI = false;

                    calc.ValueCI = P * Math.Pow((1 + (i / 100.0) / n), (n * t));
                }

                
            }
            catch
            {
                calc.IncorrectInputCI = true;
            }
        }
    }
}

