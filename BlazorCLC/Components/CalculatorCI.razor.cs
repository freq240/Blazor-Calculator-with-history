using BlazorCLC.Interfaces;
using BlazorCLC.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCLC.Models;
using BlazorCLC.Infrastract.Entities;
using BlazorCLC.Core.Interfaces;
using MediatR;
using BlazorCLC.Core.Commands;

namespace BlazorCLC.Components
{
    public partial class CalculatorCI
    {
        [Inject]
        protected ICalculatorCIState CalculatorCIState { get; set; }
        [Inject]
        protected ICalculatorCIService CalculatorCIService { get; set; }
        [Inject]
        protected IMediator Mediator { get; set; }


        public void ShowCompoundInterestMenu()
        {

            if (CalculatorCIState.FlagCImenuActive)
            {
                Mediator.Send(new AddHistoryPointCommand(new HistoryPoint("Closed CI menu")));
                CalculatorCIState.FlagCImenuActive = false;
            }
            else
            {
                Mediator.Send(new AddHistoryPointCommand(new HistoryPoint("Opened CI menu")));
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
                    Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Calculated CI({StartSum},{PercentInYear},{Times},{Years})")));
                }


            }
            catch
            {
                CalculatorCIState.IncorrectInputCI = true;
            }
        }
    }
}
