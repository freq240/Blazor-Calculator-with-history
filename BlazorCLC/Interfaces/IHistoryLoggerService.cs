using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface IHistoryLoggerService
    {
        public void Add(string action);
        public string Show();
    }
}
