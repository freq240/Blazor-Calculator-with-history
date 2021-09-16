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

        public CalculatorCI(IHistoryLoggerService _logger)
        {
            this.HistoryLogger = _logger;
        }

        public CalculatorCI()
        {
            // ТОЖЕ РАЗОБРАТЬСЯ ПОЧЕМУ ТРЕБУЕТ ПУСТОЙ КОНСТРУКТОР ЕСЛИ ЕСТЬ СВЕРХУ С ЛОГГЕРОМ
        }

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
                double ss = Convert.ToDouble(startSum);
                double piy = Convert.ToDouble(percentInYear);
                int t = Convert.ToInt32(times);
                int y = Convert.ToInt32(years);

                if (ss < 1 || piy < 0 || t < 1 || y < 1)
                {
                    CalculatorCIState.IncorrectInputCI = true;
                }
                else
                {
                    CalculatorCIState.IncorrectInputCI = false;

                    CalculatorCIState.ValueCI = CalculatorCIService.Calculate(ss, piy, t, y);
                    HistoryLogger.Add($"Calculated CI({ss},{piy},{t},{y})");
                }


            }
            catch
            {
                CalculatorCIState.IncorrectInputCI = true;
            }
        }
    }
}
