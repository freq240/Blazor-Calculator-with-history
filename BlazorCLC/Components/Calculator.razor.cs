using BlazorCLC.Enums;
using BlazorCLC.Infrastract;
using BlazorCLC.Interfaces;
using BlazorCLC.Infrastract.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCLC.Services;
using BlazorCLC.Core.Interfaces;
using BlazorCLC.Core.Commands;

namespace BlazorCLC.Components
{
    public partial class Calculator
    {
        [Inject]
        protected ICalculatorService CalculatorService { get; set; }
        [Inject]
        protected ICalculatorState CalculatorState { get; set; }
        [Inject]
        protected IMediator Mediator { get; set; }





        // digits
        public void AddSymbolToInputString(string symbol)
        {
            if (CalculatorState.ValueFirst != null)
            {
                // checking on two dots in a row
                if (!(CalculatorState.ValueFirst.Contains(".") && symbol == "."))
                {
                    CalculatorState.ValueFirst += symbol;

                    Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '{symbol}' digit")));
                }
            }
            else
            {
                CalculatorState.ValueFirst += symbol;

                Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '{symbol}' digit")));
            }
        }

        // operation
        public void CallOperation(int operation)
        {
            try
            {
                CalculatorState.DigitFirst = double.Parse(CalculatorState.ValueFirst);
                CalculatorState.ValueFirst = "";
                CalculatorState.Operation = operation;

                switch ((Operations)operation)
                {
                    case Operations.Add:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " + ";
                        Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '+' opperation")));
                        break;
                    case Operations.Subtract:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " - ";
                        Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '-' opperation")));
                        break;
                    case Operations.Multiplication:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " * ";
                        Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '*' opperation")));
                        break;
                    case Operations.Division:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " / ";
                        Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '/' opperation")));
                        break;
                    case Operations.ModuleDivision:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " % ";
                        Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '%' opperation")));
                        break;
                    case Operations.DivisionByOne:
                        Calculate();
                        Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '1/x' opperation")));
                        break;
                    case Operations.Pow:
                        Calculate();
                        Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on 'x^2' opperation")));
                        break;
                    case Operations.Sqrt:
                        Calculate();
                        Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on 'sqrt(x)' opperation")));
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        public void Calculate()
        {
            Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Clicked on '=' opperation")));

            CalculatorState.ValueSecond = "";
            try
            {
                switch (CalculatorState.Operation)
                {  
                    case (int)Operations.Add:
                        CalculatorState.DigitSecond = CalculatorService.Add(CalculatorState.DigitFirst,double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case (int)Operations.Subtract:
                        CalculatorState.DigitSecond = CalculatorService.Subtract(CalculatorState.DigitFirst, double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case (int)Operations.Multiplication:
                        CalculatorState.DigitSecond = CalculatorService.Multiply(CalculatorState.DigitFirst, double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case (int)Operations.Division:
                        CalculatorState.DigitSecond = CalculatorService.Divide(CalculatorState.DigitFirst, double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case (int)Operations.ModuleDivision:
                        CalculatorState.DigitSecond = CalculatorService.ModuleDivide(CalculatorState.DigitFirst, double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case (int)Operations.DivisionByOne:
                        CalculatorState.DigitSecond = CalculatorService.DivideByOne(CalculatorState.DigitFirst);
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case (int)Operations.Pow:
                        CalculatorState.DigitSecond = CalculatorService.Pow(CalculatorState.DigitFirst);
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case (int)Operations.Sqrt:
                        CalculatorState.DigitSecond = CalculatorService.Sqrt(CalculatorState.DigitFirst);
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;

                    default:
                        break;
                }

            }
            catch
            {

            }
        }

        public void ClearAll()
        {
            // Delete and clear all
            CalculatorState.ValueFirst = "";
            CalculatorState.ValueSecond = "";
        }

        public void ClearLastSymbol()
        {
            if (CalculatorState.ValueFirst != null)
            {
                Mediator.Send(new AddHistoryPointCommand(new HistoryPoint($"Deleted last symbol")));
                int length = CalculatorState.ValueFirst.Length - 1;
                string line = CalculatorState.ValueFirst;
                CalculatorState.ValueFirst = "";
                for (int i = 0; i < length; i++)
                {
                    CalculatorState.ValueFirst += line[i];
                }
            }
        }
    }
}
