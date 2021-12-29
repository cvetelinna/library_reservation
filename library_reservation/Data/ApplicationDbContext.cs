using System;
using System.Collections.Generic;
using System.Text;
using library_reservation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace library_reservation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ReservationModel>()
                .HasOne(r => r.Hall);
        }

        public virtual DbSet<ReservationModel> Reservations { get; set; }

        public virtual DbSet<RecurringSettings> RecurringSettings { get; set; }

        public virtual DbSet<Hall> Halls { get; set; }
    }
}