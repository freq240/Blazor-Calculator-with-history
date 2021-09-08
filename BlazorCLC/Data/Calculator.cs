using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Data
{
    public class Calculator
    {
        public string valueFirst { get; set; }
        public string valueSecond { get; set; }

        public double digitFirst { get; set; }
        public double digitSecond { get; set; }

        public int count { get; set; }

        // digits
        public void buttonClick(string text)
        {
            if (valueFirst != null)
            {
                // checking on two dots in a row
                if (valueFirst.Contains(".") && text == ".")
                {

                }
                else
                {
                    valueFirst += text;
                }
            }
            else
            {
                valueFirst += text;
            }

        }

        // operation
        public void buttonClick(int count)
        {
            try
            {
                digitFirst = double.Parse(valueFirst);
                valueFirst = "";
                this.count = count;
                switch (count)
                {
                    case 1:
                        valueSecond = digitFirst.ToString() + " + ";
                        break;
                    case 2:
                        valueSecond = digitFirst.ToString() + " - ";
                        break;
                    case 3:
                        valueSecond = digitFirst.ToString() + " * ";
                        break;
                    case 4:
                        valueSecond = digitFirst.ToString() + " / ";
                        break;
                    case 5:
                        valueSecond = digitFirst.ToString() + " % ";
                        break;
                    case 6:
                        Calculate();
                        break;
                    case 7:
                        Calculate();
                        break;
                    case 8:
                        Calculate();
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }


        }

        public void Calculate()
        {
            this.valueSecond = "";
            try
            {
                switch (count)
                {
                    case 1:
                        digitSecond = digitFirst + double.Parse(valueFirst);
                        valueFirst = digitSecond.ToString();
                        break;
                    case 2:
                        digitSecond = digitFirst - double.Parse(valueFirst);
                        valueFirst = digitSecond.ToString();
                        break;
                    case 3:
                        digitSecond = digitFirst * double.Parse(valueFirst);
                        valueFirst = digitSecond.ToString();
                        break;
                    case 4:
                        digitSecond = digitFirst / double.Parse(valueFirst);
                        valueFirst = digitSecond.ToString();
                        break;
                    case 5:
                        digitSecond = digitFirst % double.Parse(valueFirst);
                        valueFirst = digitSecond.ToString();
                        break;
                    case 6:
                        digitSecond = 1 / digitFirst;
                        valueFirst = digitSecond.ToString();
                        break;
                    case 7:
                        digitSecond = Math.Pow(digitFirst, 2);
                        valueFirst = digitSecond.ToString();
                        break;
                    case 8:
                        digitSecond = Math.Sqrt(digitFirst);
                        valueFirst = digitSecond.ToString();
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
                    valueFirst = "";
                    valueSecond = "";
                    break;
                case 1:

                    // Deleting last symbol

                    if (valueFirst != null)
                    {
                        int length = valueFirst.Length - 1;
                        string line = valueFirst;
                        valueFirst = "";
                        for (int i = 0; i < length; i++)
                        {
                            valueFirst += line[i];
                        }
                    }
                    break;


                default:
                    break;
            }

        }

    }
}
