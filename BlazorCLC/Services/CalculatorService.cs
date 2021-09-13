using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCLC.Models;
using BlazorCLC.Interfaces;

namespace BlazorCLC.Services
{
    public class CalculatorService : ICalculatorService
    {
        public ICalculator calc;


        public CalculatorService(ICalculator _calc)
        {
            this.calc = _calc;
        }

        // digits
        public void ButtonClick(string text)
        {
            if (calc.ValueFirst != null)
            {
                // checking on two dots in a row
                if (!(calc.ValueFirst.Contains(".") && text == "."))
                {
                    calc.ValueFirst += text;
                }
            }
            else
            {
                calc.ValueFirst += text;
            }

        }

        // operation
        public void ButtonClick(int operation)
        {
            try
            {
                calc.DigitFirst = double.Parse(calc.ValueFirst);
                calc.ValueFirst = "";
                calc.Operation = operation;
                switch (operation)
                {
                    case 1:
                        calc.ValueSecond = calc.DigitFirst.ToString() + " + ";
                        break;
                    case 2:
                        calc.ValueSecond = calc.DigitFirst.ToString() + " - ";
                        break;
                    case 3:
                        calc.ValueSecond = calc.DigitFirst.ToString() + " * ";
                        break;
                    case 4:
                        calc.ValueSecond = calc.DigitFirst.ToString() + " / ";
                        break;
                    case 5:
                        calc.ValueSecond = calc.DigitFirst.ToString() + " % ";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        Calculate();
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        public void Calculate()
        {
            calc.ValueSecond = "";
            try
            {
                switch (calc.Operation)
                {
                    case 1:
                        calc.DigitSecond = calc.DigitFirst + double.Parse(calc.ValueFirst);
                        calc.ValueFirst = calc.DigitSecond.ToString();
                        break;
                    case 2:
                        calc.DigitSecond = calc.DigitFirst - double.Parse(calc.ValueFirst);
                        calc.ValueFirst = calc.DigitSecond.ToString();
                        break;
                    case 3:
                        calc.DigitSecond = calc.DigitFirst * double.Parse(calc.ValueFirst);
                        calc.ValueFirst = calc.DigitSecond.ToString();
                        break;
                    case 4:
                        calc.DigitSecond = calc.DigitFirst / double.Parse(calc.ValueFirst);
                        calc.ValueFirst = calc.DigitSecond.ToString();
                        break;
                    case 5:
                        calc.DigitSecond = calc.DigitFirst % double.Parse(calc.ValueFirst);
                        calc.ValueFirst = calc.DigitSecond.ToString();
                        break;
                    case 6:
                        calc.DigitSecond = 1 / calc.DigitFirst;
                        calc.ValueFirst = calc.DigitSecond.ToString();
                        break;
                    case 7:
                        calc.DigitSecond = Math.Pow(calc.DigitFirst, 2);
                        calc.ValueFirst = calc.DigitSecond.ToString();
                        break;
                    case 8:
                        calc.DigitSecond = Math.Sqrt(calc.DigitFirst);
                        calc.ValueFirst = calc.DigitSecond.ToString();
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

                    // Delete and clear all
                    calc.ValueFirst = "";
                    calc.ValueSecond = "";
                    break;
                case 1:

                    // Deleting last symbol

                    if (calc.ValueFirst != null)
                    {
                        int length = calc.ValueFirst.Length - 1;
                        string line = calc.ValueFirst;
                        calc.ValueFirst = "";
                        for (int i = 0; i < length; i++)
                        {
                            calc.ValueFirst += line[i];
                        }
                    }
                    break;


                default:
                    break;
            }

        }

    }
}

