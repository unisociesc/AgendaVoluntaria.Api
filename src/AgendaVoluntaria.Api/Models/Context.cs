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
                new User { Id = Guid.Parse("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), Email = "ghmeyer0@gmail.com", Name = "Gabriel Helko Meyer", Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", Role = "admin", CreateAt = new DateTime(2020, 3, 29), UpdateAt = new DateTime(2020, 3, 29) },
                new User { Id = Guid.Parse("95cf0000-dbca-d9ec-3724-08d7d51e7020"), Email = "ricardo.pfitscher@unisociesc.com.br",Name = "Ricardo Pfitscher", Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", Role = "admin", CreateAt = new DateTime(2020, 3, 29), UpdateAt = new DateTime(2020, 3, 29) },
                new User { Id = Guid.Parse("1e9e0000-6d1c-bc1b-eb06-08d7d524408d"), Email = "eslin@eslin.com", Name = "Éslin Makicine Martins", Password = "abad878fb17fb8710d8ac8c4612f379ee0ff9a0ad530bbe9729b7256f178f7bd", Role = "admin", CreateAt = new DateTime(2020, 3, 29), UpdateAt = new DateTime(2020, 3, 29) },
                new User { Id = Guid.Parse("3a480000-248f-9e93-51c3-08d7d5261675"), Email = "johnnyrtrentin@gmail.com", Name = "johnny", Password = "98bb0701a145990b4f0e0880398010d97c3d24eb189e8c80f818f6bc062a86d0", Role = "admin", CreateAt = new DateTime(2020, 3, 29), UpdateAt = new DateTime(2020, 3, 29) }
            );

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasData(
                    new Volunteer { Id = Guid.Parse("60180000-5e87-f520-b74d-08d7d52122bd"), Ra = 121815278, Course = "Engenharia", NeedPsico = false, IdUser = Guid.Parse("95cf0000-dbca-d9ec-3724-08d7d51e7020") }
                    );
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
