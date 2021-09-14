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

        static public void DeleteById(int id)
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
