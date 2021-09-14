using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Models
{
    public class HistoryPoint
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string Action { get; set; }
    }
}
