using BlazorCLC.Infrastract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Interfaces
{
    public interface IHistoryPointRepository
    {
        public Task<List<HistoryPoint>> GetAllHistoryPointsAsync();
        public Task AddHistoryPointAsync(HistoryPoint historyPoint);
        public Task DeleteHistoryPointAsync(int Id);
        public Task ClearHistory();
    }
}
