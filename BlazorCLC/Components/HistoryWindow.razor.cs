using BlazorCLC.Interfaces;
using BlazorCLC.Models;
using BlazorCLC.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCLC.Components
{
    public partial class HistoryWindow
    {
        [Inject]
        protected IHistoryLoggerService HistoryLoggerService { get; set; }
        private string DeletedId { get; set; }


        private void CheckCorrectIdAndDeleteById(string id)
        {
            try
            {
                HistoryLoggerService.DeleteById(Convert.ToInt32(id));
            }
            catch
            {
                // Some exception
                // 
            }
        }
    }
}
