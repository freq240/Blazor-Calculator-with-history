using BlazorCLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface IHistoryLoggerService
    {
        public void Add(string action);
        public IEnumerable<HistoryPoint> GetHistoryPoints();
        public void DeleteById(int id);
    }
}
