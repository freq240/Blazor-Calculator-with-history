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

        List<HistoryPoint> HistoryPointsList { get; set; }
        protected override async Task OnInitializedAsync()
        {
            HistoryPointsList = await Task.Run(() => HistoryLoggerService.GetAllHistoryPointsAsync());
        }

        private void CheckCorrectIdAndDeleteById(string id)
        {
            try
            {
                HistoryLoggerService.DeleteHistoryPointAsync(Convert.ToInt32(id));

                HistoryPointsList.Remove(HistoryPointsList.Find(x => x.Id == Convert.ToInt32(id)));
            }
            catch 
            {

               
            }
        }

        private void UpdateListWhenClearHistory()
        {
            HistoryLoggerService.ClearHistory();

            HistoryPointsList.Clear();
        }
    }
}
