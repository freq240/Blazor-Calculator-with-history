using BlazorCLC.Core.Commands;
using BlazorCLC.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorCLC.Core.Handlers
{
    public class ClearHistoryHandler : IRequestHandler<ClearHistoryCommand>
    {
        private readonly IHistoryLoggerService historyLoggerService;

        public ClearHistoryHandler(IHistoryLoggerService historyLoggerService)
        {
            this.historyLoggerService = historyLoggerService;
        }
        public async Task<Unit> Handle(ClearHistoryCommand request, CancellationToken cancellationToken)
        {
            await historyLoggerService.ClearHistory();

            return Unit.Value;
        }
    }
}
