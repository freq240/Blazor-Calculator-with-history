using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Data
{
    public class CalculatorCI
    {
        public string StartSum { get; set; }
        public string PercentsInYear { get; set; }
        public string TimesAddSum { get; set; }
        public string Years { get; set; }
        public bool flag { get; set; } = false;

        public bool IncorrectInputCI { get; set; } = false;
        public double valueCI { get; set; }



        public void ShowCompoundInterestMenu()
        {
            if (flag)
            {
                this.flag = false;
            }
            else
            {
                this.flag = true;
            }
        }

        public void CalculateCI(string StartSum, string PercentInYear, string Times, string Years)
        {
            try
            {
                double P = Convert.ToDouble(StartSum);
                double i = Convert.ToDouble(PercentInYear);
                int n = Convert.ToInt32(Times);
                int t = Convert.ToInt32(Years);

                this.IncorrectInputCI = false;

                this.valueCI = P * Math.Pow((1 + (i / 100.0) / n), (n * t));
            }
            catch
            {
                this.IncorrectInputCI = true;
            }
        }
    }
}
