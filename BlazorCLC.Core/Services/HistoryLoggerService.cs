using BlazorCLC.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorCLC.Infrastract.Entities;
using BlazorCLC.Core.Interfaces;

namespace BlazorCLC.Core.Services
{
    public class HistoryLoggerService : IHistoryLoggerService
    {
        private IHistoryPointRepository historyRepository { get; set; }

        public HistoryLoggerService(IHistoryPointRepository historyRepository)
        {
            this.historyRepository = historyRepository;
        }

        public Task<List<HistoryPoint>> GetAllHistoryPoints()
        {
            return historyRepository.GetAllHistoryPointsAsync();
        }

         public async Task AddHistoryPoint(HistoryPoint historyPoint)
        {
            await historyRepository.AddHistoryPointAsync(historyPoint);
        }

        public async Task DeleteHistoryPoint(int Id)
        {
            await historyRepository.DeleteHistoryPointAsync(Id);
        }

        public async Task ClearHistory()
        {
            await historyRepository.ClearHistory();
        }
    }
}
