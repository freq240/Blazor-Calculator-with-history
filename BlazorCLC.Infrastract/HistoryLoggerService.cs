using BlazorCLC.Infrastract;
using BlazorCLC.Interfaces;
using BlazorCLC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorCLC.Infrastract.Extensions;

namespace BlazorCLC.Services
{
    public class HistoryLoggerService : IHistoryLoggerService
    {
        protected HistoryLoggerContext HistoryLoggerContext { get; set; }

        public HistoryLoggerService(HistoryLoggerContext _historyLoggerContext)
        {
            HistoryLoggerContext = _historyLoggerContext;
        }
        public async Task<List<HistoryPoint>> GetAllHistoryPointsAsync()
        {
            return await HistoryLoggerContext.HistoryPoints.ToListAsync();
        }

        public async Task<bool> InsertHistoryPointAsync(HistoryPoint historyPoint)
        {
            await HistoryLoggerContext.HistoryPoints.AddAsync(historyPoint);
            await HistoryLoggerContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteHistoryPointAsync(int Id)
        {
            HistoryPoint hp = await HistoryLoggerContext.HistoryPoints.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            HistoryLoggerContext.Remove(hp);
            await HistoryLoggerContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClearHistory()
        {
            HistoryLoggerContext.HistoryPoints.Clear();
            await HistoryLoggerContext.SaveChangesAsync();
            return true;
        }

    }
}
