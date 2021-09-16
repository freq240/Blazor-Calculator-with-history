using BlazorCLC.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Components
{
    public partial class Calculator
    {
        
        [Inject]
        protected ICalculatorService CalculatorService { get; set; }
        [Inject]
        protected ICalculatorState CalculatorState { get; set; }
        [Inject]
        protected IHistoryLoggerService HistoryLogger { get; set; }


        public Calculator(IHistoryLoggerService _historyLogger)
        {
            this.HistoryLogger = _historyLogger;
        }

        public Calculator()
        {
            // Посмотреть что тут
        }

        // digits
        public void ButtonClick(string text)
        {
            if (CalculatorState.ValueFirst != null)
            {
                // checking on two dots in a row
                if (!(CalculatorState.ValueFirst.Contains(".") && text == "."))
                {
                    CalculatorState.ValueFirst += text;

                    HistoryLogger.Add($"Clicked on '{text}' digit");
                }
            }
            else
            {
                CalculatorState.ValueFirst += text;

                HistoryLogger.Add($"Clicked on '{text}' digit");
            }
        }

        // operation
        public void ButtonClick(int operation)
        {
            try
            {
                CalculatorState.DigitFirst = double.Parse(CalculatorState.ValueFirst);
                CalculatorState.ValueFirst = "";
                CalculatorState.Operation = operation;

                switch (operation)
                {
                    case 1:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " + ";
                        HistoryLogger.Add($"Clicked on '+' opperation");
                        break;
                    case 2:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " - ";
                        HistoryLogger.Add($"Clicked on '-' opperation");
                        break;
                    case 3:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " * ";
                        HistoryLogger.Add($"Clicked on '*' opperation");
                        break;
                    case 4:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " / ";
                        HistoryLogger.Add($"Clicked on '/' opperation");
                        break;
                    case 5:
                        CalculatorState.ValueSecond = CalculatorState.DigitFirst.ToString() + " % ";
                        HistoryLogger.Add($"Clicked on '%' opperation");
                        break;
                    case 6:
                        Calculate();
                        HistoryLogger.Add($"Clicked on '1/x' opperation");
                        break;
                    case 7:
                        Calculate();
                        HistoryLogger.Add($"Clicked on 'x^2' opperation");
                        break;
                    case 8:
                        Calculate();
                        HistoryLogger.Add($"Clicked on 'sqrt(x)' opperation");
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        public void Calculate()
        {
            HistoryLogger.Add($"Clicked on '=' operation");

            CalculatorState.ValueSecond = "";
            try
            {
                switch (CalculatorState.Operation)
                {
                    case 1:
                        CalculatorState.DigitSecond = CalculatorService.Add(CalculatorState.DigitFirst,double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case 2:
                        CalculatorState.DigitSecond = CalculatorService.Subtract(CalculatorState.DigitFirst, double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case 3:
                        CalculatorState.DigitSecond = CalculatorService.Multiply(CalculatorState.DigitFirst, double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case 4:
                        CalculatorState.DigitSecond = CalculatorService.Divide(CalculatorState.DigitFirst, double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case 5:
                        CalculatorState.DigitSecond = CalculatorService.ModuleDivide(CalculatorState.DigitFirst, double.Parse(CalculatorState.ValueFirst));
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case 6:
                        CalculatorState.DigitSecond = CalculatorService.DivideByOne(CalculatorState.DigitFirst);
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case 7:
                        CalculatorState.DigitSecond = CalculatorService.Pow(CalculatorState.DigitFirst);
                        CalculatorState.ValueFirst = CalculatorState.DigitSecond.ToString();
                        break;
                    case 8:
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

        public void Clear(int x)
        {

            switch (x)
            {
                case 0:
                    HistoryLogger.Add($"Cleared all");

                    // Delete and clear all
                    CalculatorState.ValueFirst = "";
                    CalculatorState.ValueSecond = "";
                    break;
                case 1:

                    // Deleting last symbol

                    if (CalculatorState.ValueFirst != null)
                    {
                        HistoryLogger.Add($"Deleted last symbol");
                        int length = CalculatorState.ValueFirst.Length - 1;
                        string line = CalculatorState.ValueFirst;
                        CalculatorState.ValueFirst = "";
                        for (int i = 0; i < length; i++)
                        {
                            CalculatorState.ValueFirst += line[i];
                        }
                    }
                    break;

                default:
                    break;
            }

        }
    }
}
