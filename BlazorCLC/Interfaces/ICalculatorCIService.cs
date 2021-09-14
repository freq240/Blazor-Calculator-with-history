using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface ICalculatorCIService
    {
        public void ShowCompoundInterestMenu();
        public void Calculate(string startSum, string percentInYear, string times, string years);
    }
}
