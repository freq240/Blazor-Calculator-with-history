using BlazorCLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface IHistoryLoggerService
    {
        public Task<List<HistoryPoint>> GetAllHistoryPointsAsync();
        public Task<bool> InsertHistoryPointAsync(HistoryPoint historyPoint);
        public Task<bool> DeleteHistoryPointAsync(int Id);
        public Task<bool> ClearHistory();
    }
}
