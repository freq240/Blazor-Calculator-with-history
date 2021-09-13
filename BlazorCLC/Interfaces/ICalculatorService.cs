using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface ICalculatorService
    {
        public void ButtonClick(string text);
        public void ButtonClick(int operation);
        public void Calculate();
        public void Clear(int x);

    }
}
