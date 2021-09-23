using BlazorCLC.Core.Queries;
using BlazorCLC.Interfaces;
using BlazorCLC.Models;
using BlazorCLC.Services;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCLC.Infrastract.Handlers;
using BlazorCLC.Infrastract.Entities;
using BlazorCLC.Core.Interfaces;
using BlazorCLC.Core.Commands;

namespace BlazorCLC.Components
{
    public partial class HistoryWindow
    {
        [Inject]
        protected IHistoryLoggerService HistoryLoggerService { get; set; }
        [Inject]
        protected IMediator Mediator { get; set; }

        private string DeletedId { get; set; }

        private List<HistoryPoint> HistoryPointsList { get; set; }
        protected override async Task OnInitializedAsync()
        {
            HistoryPointsList = await Mediator.Send(new GetHistoryPointQuery());
        }

        private void CheckCorrectIdAndDeleteById(string id)
        {
            try
            {
                Mediator.Send(new DeleteHistoryPointCommand(Convert.ToInt32(id)));

                HistoryPointsList.Remove(HistoryPointsList.Find(x => x.Id == Convert.ToInt32(id)));
            }
            catch 
            {

               
            }
        }

        private void UpdateListWhenClearHistory()
        {
            Mediator.Send(new ClearHistoryCommand());

            HistoryPointsList.Clear();
        }
    }
}
