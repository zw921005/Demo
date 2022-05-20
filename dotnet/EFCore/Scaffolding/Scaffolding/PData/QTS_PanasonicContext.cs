using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scaffolding.PModels;

namespace Scaffolding.PData
{
    public partial class QTS_PanasonicContext : DbContext
    {
        public QTS_PanasonicContext()
        {
        }

        public QTS_PanasonicContext(DbContextOptions<QTS_PanasonicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysSetting> SysSettings { get; set; } = null!;
        public virtual DbSet<TestTable> TestTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.7.220;Initial Catalog=QTS_Panasonic;User Id = sa;Password = sce20181010;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysSetting>(entity =>
            {
                entity.HasKey(e => e.Settingkey)
                    .HasName("PK__sysSetti__0831F23268B0C63B");

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

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.ToTable("test_table");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Value).HasColumnName("VALUE");

                entity.Property(e => e.Ver).HasColumnName("VER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
