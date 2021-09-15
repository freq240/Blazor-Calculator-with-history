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
        public IHistoryLoggerService logger;

        public CalculatorCIService(ICalculatorCI _calc, IHistoryLoggerService _logger)
        {
            this.calc = _calc;
            this.logger = _logger;
            
        }

        public void ShowCompoundInterestMenu()
        {
            

            if (calc.FlagCImenuActive)
            {
                logger.Add($"Closed CI menu");
                calc.FlagCImenuActive = false;
            }
            else
            {
                logger.Add($"Opened CI menu");
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
                    logger.Add($"Calculated CI({P},{i},{n},{t})");
                }

                
            }
            catch
            {
                calc.IncorrectInputCI = true;
            }
        }
    }
}

