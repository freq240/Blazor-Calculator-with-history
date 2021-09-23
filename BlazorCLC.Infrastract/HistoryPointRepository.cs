using BlazorCLC.Infrastract;
using BlazorCLC.Interfaces;
using BlazorCLC.Infrastract.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorCLC.Infrastract.Extensions;


namespace BlazorCLC.Services
{
    public class HistoryPointRepository : IHistoryPointRepository
    {
        protected HistoryLoggerContext HistoryLoggerContext { get; set; }

        public HistoryPointRepository(HistoryLoggerContext _historyLoggerContext)
        {
            HistoryLoggerContext = _historyLoggerContext;
        }
        public Task<List<HistoryPoint>> GetAllHistoryPointsAsync()
        {
            return HistoryLoggerContext.HistoryPoints.ToListAsync();
        }

        public async Task AddHistoryPointAsync(HistoryPoint historyPoint)
        {
            await HistoryLoggerContext.HistoryPoints.AddAsync(historyPoint);
            await HistoryLoggerContext.SaveChangesAsync();
        }

        public async Task DeleteHistoryPointAsync(int Id)
        {
            HistoryPoint hp = await HistoryLoggerContext.HistoryPoints.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            HistoryLoggerContext.Remove(hp);
            await HistoryLoggerContext.SaveChangesAsync();
        }

        public async Task ClearHistory()
        {
            HistoryLoggerContext.HistoryPoints.Clear();
            await HistoryLoggerContext.SaveChangesAsync();
        }

    }
}
