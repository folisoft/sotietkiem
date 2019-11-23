using Microsoft.EntityFrameworkCore;
using SoTietKiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoTietKiem.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietSoTietKiem> ChiTietSoTietKiem { get; set; }
        public virtual DbSet<LoaiTietKiem> LoaiTietKiem { get; set; }
        public virtual DbSet<PhieuGuiRutTien> PhieuGuiRutTien { get; set; }
        public virtual DbSet<QuyDinh> QuyDinh { get; set; }
        public virtual DbSet<SoTK> SoTK { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=savingsbook;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietSoTietKiem>(entity =>
            {
                entity.HasKey(e => e.PhieuGuiRutTienId);

                entity.Property(e => e.PhieuGuiRutTienId).ValueGeneratedNever();

                entity.Property(e => e.Mskh).HasColumnName("MSKH");

                entity.Property(e => e.NgayGui).HasColumnType("datetime");

                entity.Property(e => e.NgayRut).HasColumnType("datetime");

                entity.Property(e => e.NghiepVu).HasColumnType("ntext");

                entity.HasOne(d => d.PhieuGuiRutTien)
                    .WithOne(p => p.ChiTietSoTietKiem)
                    .HasForeignKey<ChiTietSoTietKiem>(d => d.PhieuGuiRutTienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietSoTietKiem_PhieuGuiRutTien");
            });

            modelBuilder.Entity<LoaiTietKiem>(entity =>
            {
                entity.Property(e => e.LoaiTietKiem1).HasColumnName("LoaiTietKiem");

                entity.Property(e => e.NgayHieuLuc).HasColumnType("datetime");
            });

            modelBuilder.Entity<PhieuGuiRutTien>(entity =>
            {
                entity.Property(e => e.KhachHang).HasColumnType("ntext");

                entity.Property(e => e.Mskh).HasColumnName("MSKH");

                entity.Property(e => e.Ngay).HasColumnType("datetime");

                entity.HasOne(d => d.MskhNavigation)
                    .WithMany(p => p.PhieuGuiRutTien)
                    .HasForeignKey(d => d.Mskh)
                    .HasConstraintName("FK_PhieuGuiRutTien_SoTietKiem");
            });

            modelBuilder.Entity<QuyDinh>(entity =>
            {
                entity.HasKey(e => e.Msqd);

                entity.Property(e => e.Msqd).HasColumnName("MSQD");

                entity.Property(e => e.Ngay).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasColumnType("ntext");
            });

            modelBuilder.Entity<SoTK>(entity =>
            {
                entity.HasKey(e => e.Mskh);

                entity.Property(e => e.Mskh).HasColumnName("MSKH");

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(13);

                entity.Property(e => e.DiaChi).HasColumnType("ntext");

                entity.Property(e => e.KhachHang).HasMaxLength(50);

                entity.Property(e => e.NgayDongSo).HasColumnType("datetime");

                entity.Property(e => e.NgayMoSo).HasColumnType("datetime");

                entity.HasOne(d => d.LoaiTietKiem)
                    .WithMany(p => p.SoTietKiem)
                    .HasForeignKey(d => d.LoaiTietKiemId)
                    .HasConstraintName("FK_SoTietKiem_LoaiTietKiem");
            });
        }
    }
}
