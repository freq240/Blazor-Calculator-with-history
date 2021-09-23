using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Infrastract.Entities
{
    public class HistoryPoint
    {

        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string Action { get; set; }


        public HistoryPoint(string action)
        {
            Datetime = DateTime.Now;
            Action = action;
        }

    }
}
