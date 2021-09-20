using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCLC.Interfaces;

namespace BlazorCLC.Models
{
    public class CalculatorCIState: ICalculatorCIState
    {
        public string StartSum { get; set; }
        public string PercentsInYear { get; set; }
        public string TimesAddSum { get; set; }
        public string Years { get; set; }
        public bool FlagCImenuActive { get; set; } = false;

        public bool IncorrectInputCI { get; set; } = false;
        public double ValueCI { get; set; } 
    }
}
