using BlazorCLC.Interfaces;
using BlazorCLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Services
{
    public class HistoryLoggerService : IHistoryLoggerService
    {
        private List<HistoryPoint> historyPoints { get; set; } = new List<HistoryPoint>();
        
      
        public void Add(string action)
        {
            var historyPoint = new HistoryPoint(historyPoints.Count + 1, action);
            historyPoints.Add(historyPoint);
            // Посмотреть references, добавить бд
            //using (HistoryLoggerContext db = new UserContext())
            //{
                

            //}
            //    historyPoints.Add(historyPoint);
        }

        public IEnumerable<HistoryPoint> GetHistoryPoints()
        {
            return historyPoints.Select(x => x);
        }

        public void DeleteById(int id)
        {
            try
            {
                historyPoints.RemoveAt(id - 1);
                for (int i = 0; i < historyPoints.Count; i++)
                {
                    historyPoints[i].Id = i + 1;
                }
            }
            catch
            {
                // ID IS NOT FOUND
            }
            
        }

    }
}
