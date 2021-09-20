using BlazorCLC.Interfaces;
using BlazorCLC.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Components
{
    public partial class CalculatorCI
    {
        [Inject]
        protected ICalculatorCIState CalculatorCIState { get; set; }
        [Inject]
        protected ICalculatorCIService CalculatorCIService { get; set; }
        [Inject]
        protected IHistoryLoggerService HistoryLogger { get; set; }


        public void ShowCompoundInterestMenu()
        {

            if (CalculatorCIState.FlagCImenuActive)
            {
                HistoryLogger.Add($"Closed CI menu");
                CalculatorCIState.FlagCImenuActive = false;
            }
            else
            {
                HistoryLogger.Add($"Opened CI menu");
                CalculatorCIState.FlagCImenuActive = true;
            }
        }

        public void CalculateWrapper(string startSum, string percentInYear, string times, string years)
        {
            try
            {
                double StartSum = Convert.ToDouble(startSum);
                double PercentInYear = Convert.ToDouble(percentInYear);
                int Times = Convert.ToInt32(times);
                int Years = Convert.ToInt32(years);

                if (StartSum < 1 || PercentInYear < 0 || Times < 1 || Years < 1)
                {
                    CalculatorCIState.IncorrectInputCI = true;
                }
                else
                {
                    CalculatorCIState.IncorrectInputCI = false;

                    CalculatorCIState.ValueCI = CalculatorCIService.Calculate(StartSum, PercentInYear, Times, Years);
                    HistoryLogger.Add($"Calculated CI({StartSum},{PercentInYear},{Times},{Years})");
                }


            }
            catch
            {
                CalculatorCIState.IncorrectInputCI = true;
            }
        }
    }
}
