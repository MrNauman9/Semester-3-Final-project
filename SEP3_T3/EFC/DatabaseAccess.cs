using EFC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFC;

public class DatabaseAccess : DbContext {
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ReservationEntity> Reservations { get; set; }
    public DbSet<ShowEntity> Shows { get; set; }
    public DbSet<LocationEntity> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
       optionsBuilder.UseSqlite(@"Data Source = D:\VIA\Semester_03\SEP3_Group2\SEP3_T3\EFC\Circus_umar.db");
    }
            
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ShowLocationEntity>().HasKey(entity => new{entity.ShowId, entity.LocationName});
        modelBuilder.Entity<ShowLocationEntity>().HasOne(entity => entity.Show).WithMany(showEntity  => showEntity.ShowLocations).HasForeignKey(entity => entity.ShowId);
        modelBuilder.Entity<ShowLocationEntity>().HasOne(mi =>mi.Location).WithMany(location  => location.ShowLocations).HasForeignKey(mi => mi.LocationName);
    }

    
}