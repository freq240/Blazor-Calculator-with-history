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
    public class AddHistoryPointHandler : IRequestHandler<AddHistoryPointCommand>
    {
        private readonly IHistoryLoggerService historyLoggerService;

        public AddHistoryPointHandler(IHistoryLoggerService historyLoggerService)
        {
            this.historyLoggerService = historyLoggerService;
        }
        public async Task<Unit> Handle(AddHistoryPointCommand request, CancellationToken cancellationToken)
        {
            await historyLoggerService.AddHistoryPoint(request.HistoryPoint);

            return Unit.Value;
        }
    }
}
