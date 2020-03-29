using AgendaVoluntaria.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgendaVoluntaria.Api
{
    public static class SqliteAgendaVoluntariaContextFactory
    {
        public static AgendaVoluntariaContext GetAgendaVoluntariaContext()
        {
            var options = new DbContextOptionsBuilder<AgendaVoluntariaContext>()
                         .UseSqlite("Data Source=" + Guid.NewGuid() + ".db")
                         .Options;
            var context = new AgendaVoluntariaContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;

        }
    }
}
