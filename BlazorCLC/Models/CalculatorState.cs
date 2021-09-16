using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCLC.Interfaces;

namespace BlazorCLC.Models
{
    public class CalculatorState : ICalculatorState
    {
        public string ValueFirst { get; set; }
        public string ValueSecond { get; set; }

        public double DigitFirst { get; set; }
        public double DigitSecond { get; set; }

        public int Operation { get; set; }
    }
  
}
