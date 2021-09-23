using BlazorCLC.Infrastract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCLC.Core.Interfaces
{
    public interface IHistoryLoggerService
    {
        public Task<List<HistoryPoint>> GetAllHistoryPoints();
        public Task AddHistoryPoint(HistoryPoint historyPoint);
        public Task DeleteHistoryPoint(int Id);
        public  Task ClearHistory();

    }
}
