
using BlazorCLC.Core.Interfaces;
using BlazorCLC.Core.Queries;
using BlazorCLC.Infrastract.Entities;
using BlazorCLC.Interfaces;
using BlazorCLC.Models;
using BlazorCLC.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorCLC.Infrastract.Handlers
{
    public record GetHistoryPointHandler : IRequestHandler<GetHistoryPointQuery, List<HistoryPoint>>
    {
        private readonly IHistoryLoggerService historyLoggerService;

        public GetHistoryPointHandler(IHistoryLoggerService historyLoggerService)
        {
            this.historyLoggerService = historyLoggerService;
        }

        public Task<List<HistoryPoint>> Handle(GetHistoryPointQuery request, CancellationToken cancellationToken)
        {
            return historyLoggerService.GetAllHistoryPoints();
        }
    }
}
