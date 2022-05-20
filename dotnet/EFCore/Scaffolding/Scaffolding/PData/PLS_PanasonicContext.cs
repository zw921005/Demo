using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scaffolding.PModels;

namespace Scaffolding.PData
{
    public partial class PLS_PanasonicContext : DbContext
    {
        public PLS_PanasonicContext()
        {
        }

        public PLS_PanasonicContext(DbContextOptions<PLS_PanasonicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysSetting> SysSettings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.7.220;Initial Catalog=PLS_Panasonic;User Id = sa;Password = sce20181010;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysSetting>(entity =>
            {
                entity.HasKey(e => e.Settingkey);

                entity.ToTable("sysSetting");

                entity.Property(e => e.Settingkey)
                    .HasMaxLength(50)
                    .HasColumnName("SETTINGKEY");

                entity.Property(e => e.Modifydate)
                    .HasColumnType("datetime")
                    .HasColumnName("MODIFYDATE");

                entity.Property(e => e.Modifyuser)
                    .HasMaxLength(20)
                    .HasColumnName("MODIFYUSER");

                entity.Property(e => e.Settingdesc)
                    .HasMaxLength(100)
                    .HasColumnName("SETTINGDESC");

                entity.Property(e => e.Settingvalue)
                    .HasMaxLength(100)
                    .HasColumnName("SETTINGVALUE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
