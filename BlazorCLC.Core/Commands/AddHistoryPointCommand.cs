using BlazorCLC.Infrastract.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCLC.Core.Commands
{
    public record AddHistoryPointCommand(HistoryPoint HistoryPoint) : IRequest;
}
