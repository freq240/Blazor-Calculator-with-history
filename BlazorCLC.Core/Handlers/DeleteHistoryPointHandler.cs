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
    public class DeleteHistoryPointHandler : IRequestHandler<DeleteHistoryPointCommand>
    {
        private readonly IHistoryLoggerService historyLoggerService;

        public DeleteHistoryPointHandler(IHistoryLoggerService historyLoggerService)
        {
            this.historyLoggerService = historyLoggerService;
        }
        public async Task<Unit> Handle(DeleteHistoryPointCommand request, CancellationToken cancellationToken)
        {
            await historyLoggerService.DeleteHistoryPoint(request.Id);

            return Unit.Value;
        }
    }
}
