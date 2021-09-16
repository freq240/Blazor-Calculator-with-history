using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface ICalculatorService
    {
        public double Add(double x, double y);
        public double Subtract(double x, double y);
        public double Multiply(double x, double y);
        public double Divide(double x, double y);
        public double ModuleDivide(double x, double y);
        public double DivideByOne(double x);
        public double Pow(double x);
        public double Sqrt(double x);
    }
}
