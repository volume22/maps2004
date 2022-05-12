using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace pooms2004
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<newEquipment> newEquipment { get; set; }
        public virtual DbSet<TableEquipmentHistory> TableEquipmentHistory { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturer { get; set; }
        public virtual DbSet<TablesModel> TablesModel { get; set; }
        public virtual DbSet<Timer> Timer { get; set; }
        public virtual DbSet<TimerArchive> TimerArchive { get; set; }
        public virtual DbSet<TimerInactivity> TimerInactivity { get; set; }
        public virtual DbSet<TimerInactivityArchive> TimerInactivityArchive { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.HoursMachines)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Document>()
                .Property(e => e.PartsCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Document>()
                .Property(e => e.WorkCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Document>()
                .Property(e => e.ConsumablesCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Document>()
                .Property(e => e.ComponentHours)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TablesManufacturer>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesManufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesModel>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesModel)
                .WillCascadeOnDelete(false);
        }
    }
}
