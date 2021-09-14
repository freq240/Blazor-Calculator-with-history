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
        public static List<HistoryPoint> historyPoints { get; set; } = new List<HistoryPoint>();
        
        
        public void Add(string action)
        {
            var historyPoint = new HistoryPoint();

            historyPoint.Id = historyPoints.Count + 1;
            historyPoint.Datetime = DateTime.Now;
            historyPoint.Action = action;

            historyPoints.Add(historyPoint);
        }

        public string Show()
        {
            return historyPoints.ToArray().ToString();
        }

    }
}
