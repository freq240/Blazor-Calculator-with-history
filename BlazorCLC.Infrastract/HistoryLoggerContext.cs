using BlazorCLC.Infrastract.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCLC.Infrastract
{
    public class HistoryLoggerContext : DbContext
    {
        public HistoryLoggerContext(DbContextOptions<HistoryLoggerContext> options) : base(options)
        { }

        public DbSet<HistoryPoint> HistoryPoints { get; set; }

    }
}


