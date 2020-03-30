using AgendaVoluntaria.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgendaVoluntaria.Api
{
    public static class SqliteContextFactory
    {
        public static Context GetAgendaVoluntariaContext()
        {
            var options = new DbContextOptionsBuilder<Context>()
                         .UseSqlite("Data Source=" + Guid.NewGuid() + ".db")
                         .Options;
            var context = new Context(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;

        }
    }
}
