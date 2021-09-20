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
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Subtract(double x, double y)
        {
            return x - y;
        }
        public double Multiply(double x, double y)
        {
            return x * y;
        }
        public double Divide(double x, double y)
        {
            return x / y;
        }
        public double ModuleDivide(double x, double y)
        {
            return x % y;
        }
        public double DivideByOne(double x)
        {
            return 1 / x;
        }
        public double Pow(double x)
        {
            return Math.Pow(x, 2);
        }
        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }

    }
}

