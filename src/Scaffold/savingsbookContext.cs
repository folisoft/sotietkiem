using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SoTietKiem.Scaffold
{
    public partial class savingsbookContext : DbContext
    {
        public savingsbookContext()
        {
        }

        public savingsbookContext(DbContextOptions<savingsbookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ChiTietSoTietKiem> ChiTietSoTietKiem { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<LoaiTietKiem> LoaiTietKiem { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<PhieuGuiRutTien> PhieuGuiRutTien { get; set; }
        public virtual DbSet<QuyDinh> QuyDinh { get; set; }
        public virtual DbSet<SoTk> SoTk { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=savingsbook;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ChiTietSoTietKiem>(entity =>
            {
                entity.HasKey(e => e.PhieuGuiRutTienId);

                entity.Property(e => e.PhieuGuiRutTienId).ValueGeneratedNever();

                entity.Property(e => e.Mskh).HasColumnName("MSKH");

                entity.Property(e => e.NgayGui).HasColumnType("datetime");

                entity.Property(e => e.NgayRut).HasColumnType("datetime");

                entity.Property(e => e.NghiepVu).HasColumnType("text");

                entity.HasOne(d => d.PhieuGuiRutTien)
                    .WithOne(p => p.ChiTietSoTietKiem)
                    .HasForeignKey<ChiTietSoTietKiem>(d => d.PhieuGuiRutTienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietSoTietKiem_PhieuGuiRutTien");
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<LoaiTietKiem>(entity =>
            {
                entity.Property(e => e.LoaiTietKiem1).HasColumnName("LoaiTietKiem");

                entity.Property(e => e.NgayHieuLuc).HasColumnType("datetime");
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type });

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PhieuGuiRutTien>(entity =>
            {
                entity.HasIndex(e => e.Mskh);

                entity.Property(e => e.KhachHang).HasColumnType("text");

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

                entity.Property(e => e.NoiDung).HasColumnType("text");
            });

            modelBuilder.Entity<SoTk>(entity =>
            {
                entity.HasKey(e => e.Mskh);

                entity.ToTable("SoTK");

                entity.HasIndex(e => e.LoaiTietKiemId);

                entity.Property(e => e.Mskh).HasColumnName("MSKH");

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(13);

                entity.Property(e => e.DiaChi).HasColumnType("text");

                entity.Property(e => e.KhachHang).HasMaxLength(50);

                entity.Property(e => e.NgayDongSo).HasColumnType("datetime");

                entity.Property(e => e.NgayMoSo).HasColumnType("datetime");

                entity.HasOne(d => d.LoaiTietKiem)
                    .WithMany(p => p.SoTk)
                    .HasForeignKey(d => d.LoaiTietKiemId)
                    .HasConstraintName("FK_SoTietKiem_LoaiTietKiem");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
