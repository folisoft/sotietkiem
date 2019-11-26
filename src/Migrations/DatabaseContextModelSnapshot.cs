﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoTietKiem.Data;

namespace SoTietKiem.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoTietKiem.Models.ChiTietSoTietKiem", b =>
                {
                    b.Property<int>("PhieuGuiRutTienId")
                        .HasColumnType("int");

                    b.Property<double?>("LaiSuat")
                        .HasColumnType("float");

                    b.Property<double?>("LaiSuatNgay")
                        .HasColumnType("float");

                    b.Property<double?>("LaiSuatThang")
                        .HasColumnType("float");

                    b.Property<int?>("LoaiTietKiemId")
                        .HasColumnType("int");

                    b.Property<string>("Mskh")
                        .HasColumnName("MSKH")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime?>("NgayGui")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayRut")
                        .HasColumnType("datetime");

                    b.Property<string>("NghiepVu")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double?>("SoDuCuoiKy")
                        .HasColumnType("float");

                    b.Property<double?>("SoDuDauKy")
                        .HasColumnType("float");

                    b.Property<int?>("SoNgayLaiSuat")
                        .HasColumnType("int");

                    b.Property<int?>("SoThangLaiSuat")
                        .HasColumnType("int");

                    b.Property<double?>("SoTienGui")
                        .HasColumnType("float");

                    b.Property<double?>("SoTienRut")
                        .HasColumnType("float");

                    b.HasKey("PhieuGuiRutTienId");

                    b.ToTable("ChiTietSoTietKiem");
                });

            modelBuilder.Entity("SoTietKiem.Models.DinhMuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("TienGuiLanDauToiThieu")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DinhMuc");
                });

            modelBuilder.Entity("SoTietKiem.Models.LoaiTietKiem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KyHan")
                        .HasColumnType("int");

                    b.Property<double>("LaiSuat")
                        .HasColumnType("float");

                    b.Property<DateTime>("NgayHieuLuc")
                        .HasColumnType("datetime");

                    b.Property<string>("TenLoaiTietKiem")
                        .HasColumnName("TenLoaiTietKiem")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("LoaiTietKiem");
                });

            modelBuilder.Entity("SoTietKiem.Models.PhieuGuiRutTien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KhachHang")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Mskh")
                        .HasColumnName("MSKH")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime?>("Ngay")
                        .HasColumnType("datetime");

                    b.Property<double?>("SoTien")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Mskh");

                    b.ToTable("PhieuGuiRutTien");
                });

            modelBuilder.Entity("SoTietKiem.Models.QuyDinh", b =>
                {
                    b.Property<string>("Msqd")
                        .HasColumnName("MSQD")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<DateTime?>("Ngay")
                        .HasColumnType("datetime");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Msqd");

                    b.ToTable("QuyDinh");
                });

            modelBuilder.Entity("SoTietKiem.Models.SoTk", b =>
                {
                    b.Property<string>("Mskh")
                        .HasColumnName("MSKH")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Cmnd")
                        .HasColumnName("CMND")
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("KhachHang")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("LoaiTietKiemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayDongSo")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayMoSo")
                        .HasColumnType("datetime");

                    b.Property<double?>("SoDu")
                        .HasColumnType("float");

                    b.Property<double?>("SoTienGui")
                        .HasColumnType("float");

                    b.HasKey("Mskh");

                    b.HasIndex("LoaiTietKiemId");

                    b.ToTable("SoTK");
                });

            modelBuilder.Entity("SoTietKiem.Models.ChiTietSoTietKiem", b =>
                {
                    b.HasOne("SoTietKiem.Models.PhieuGuiRutTien", "PhieuGuiRutTien")
                        .WithOne("ChiTietSoTietKiem")
                        .HasForeignKey("SoTietKiem.Models.ChiTietSoTietKiem", "PhieuGuiRutTienId")
                        .HasConstraintName("FK_ChiTietSoTietKiem_PhieuGuiRutTien")
                        .IsRequired();
                });

            modelBuilder.Entity("SoTietKiem.Models.PhieuGuiRutTien", b =>
                {
                    b.HasOne("SoTietKiem.Models.SoTk", "MskhNavigation")
                        .WithMany("PhieuGuiRutTien")
                        .HasForeignKey("Mskh")
                        .HasConstraintName("FK_PhieuGuiRutTien_SoTK");
                });

            modelBuilder.Entity("SoTietKiem.Models.SoTk", b =>
                {
                    b.HasOne("SoTietKiem.Models.LoaiTietKiem", "LoaiTietKiem")
                        .WithMany("SoTk")
                        .HasForeignKey("LoaiTietKiemId")
                        .HasConstraintName("FK_SoTK_LoaiTietKiem")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
