using AgendaVoluntaria.Api.Models.Core;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Psico> Psicos { get; set; }
        public DbSet<VolunteerShift> VolunteerShifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.Parse("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), Email = "ghmeyer0@gmail.com", Name = "Gabriel Helko Meyer", Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", Role = "admin", CreateAt = new DateTime(2020, 3, 29), UpdateAt = new DateTime(2020, 3, 29) }
            );

            modelBuilder.Entity<Shift>(entity =>
            {
                var lastShift = new DateTime(2020, 03, 20, 0, 0, 0, 0);
                List<Shift> list = new List<Shift>();
                for (int i = 0; i < 1105; i++)
                {
                    list.Add(new Shift
                    {
                        Id = NewId.NextGuid(),
                        Begin = lastShift,
                        End = lastShift.AddHours(6),
                        MaxVolunteer = lastShift.Hour == 0 && lastShift.AddHours(6).Hour == 6 ? 4 : 20
                    });
                    lastShift = lastShift.AddHours(6);
                }

                entity.HasData(list);
            });
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is CoreModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                (entityEntry.Entity as CoreModel).UpdateAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    (entityEntry.Entity as CoreModel).CreateAt = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync();
        }
    }
}
