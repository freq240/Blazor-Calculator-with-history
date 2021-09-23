using BlazorCLC.Infrastract.Entities;
using BlazorCLC.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCLC.Core.Queries
{
    public record GetHistoryPointQuery() : IRequest<List<HistoryPoint>>;
}
