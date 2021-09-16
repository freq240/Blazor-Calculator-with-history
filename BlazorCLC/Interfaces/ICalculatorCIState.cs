using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface ICalculatorCIState
    {
        public string StartSum { get; set; }
        public string PercentsInYear { get; set; }
        public string TimesAddSum { get; set; }
        public string Years { get; set; }
        public bool FlagCImenuActive { get; set; }

        public bool IncorrectInputCI { get; set; }
        public double ValueCI { get; set; }
    }
}
