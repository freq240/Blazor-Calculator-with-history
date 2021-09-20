using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface ICalculatorCIService
    {
        public double Calculate(double startSum, double percentInYear, int times, int years);
    }
}
