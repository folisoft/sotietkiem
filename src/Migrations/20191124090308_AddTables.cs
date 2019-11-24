using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoTietKiem.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiTietKiem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiTietKiem = table.Column<string>(maxLength: 255, nullable: true),
                    LaiSuat = table.Column<double>(nullable: true),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    KyHan = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTietKiem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyDinh",
                columns: table => new
                {
                    MSQD = table.Column<string>(maxLength: 3, nullable: false),
                    Ngay = table.Column<DateTime>(type: "datetime", nullable: true),
<<<<<<< HEAD:src/Migrations/20191124090308_AddTables.cs
                    NoiDung = table.Column<string>(maxLength: 255, nullable: true)
=======
                    NoiDung = table.Column<string>(type: "ntext", nullable: true)
>>>>>>> d8379b457a26bb3903a865a43aa33e2abb374555:src/Migrations/20191123193352_Initial_Migration.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyDinh", x => x.MSQD);
                });

            migrationBuilder.CreateTable(
                name: "SoTK",
                columns: table => new
                {
                    MSKH = table.Column<string>(maxLength: 5, nullable: false),
                    LoaiTietKiemId = table.Column<int>(nullable: false),
                    KhachHang = table.Column<string>(maxLength: 255, nullable: true),
                    CMND = table.Column<string>(maxLength: 13, nullable: true),
<<<<<<< HEAD:src/Migrations/20191124090308_AddTables.cs
                    DiaChi = table.Column<string>(maxLength: 255, nullable: true),
=======
                    DiaChi = table.Column<string>(type: "ntext", nullable: true),
>>>>>>> d8379b457a26bb3903a865a43aa33e2abb374555:src/Migrations/20191123193352_Initial_Migration.cs
                    NgayMoSo = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoTienGui = table.Column<double>(nullable: true),
                    NgayDongSo = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoDu = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoTK", x => x.MSKH);
                    table.ForeignKey(
                        name: "FK_SoTK_LoaiTietKiem",
                        column: x => x.LoaiTietKiemId,
                        principalTable: "LoaiTietKiem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuGuiRutTien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
<<<<<<< HEAD:src/Migrations/20191124090308_AddTables.cs
                    MSKH = table.Column<string>(maxLength: 5, nullable: true),
                    KhachHang = table.Column<string>(maxLength: 255, nullable: true),
=======
                    MSKH = table.Column<int>(nullable: true),
                    KhachHang = table.Column<string>(type: "ntext", nullable: true),
>>>>>>> d8379b457a26bb3903a865a43aa33e2abb374555:src/Migrations/20191123193352_Initial_Migration.cs
                    SoTien = table.Column<double>(nullable: true),
                    Ngay = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuGuiRutTien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuGuiRutTien_SoTK",
                        column: x => x.MSKH,
                        principalTable: "SoTK",
                        principalColumn: "MSKH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSoTietKiem",
                columns: table => new
                {
                    PhieuGuiRutTienId = table.Column<int>(nullable: false),
                    MSKH = table.Column<string>(maxLength: 5, nullable: true),
                    NgayGui = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoTienGui = table.Column<double>(nullable: true),
                    NgayRut = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoTienRut = table.Column<double>(nullable: true),
                    LoaiTietKiemId = table.Column<int>(nullable: true),
                    LaiSuat = table.Column<double>(nullable: true),
                    SoDuDauKy = table.Column<double>(nullable: true),
                    SoThangLaiSuat = table.Column<int>(nullable: true),
                    LaiSuatThang = table.Column<double>(nullable: true),
                    SoNgayLaiSuat = table.Column<int>(nullable: true),
                    LaiSuatNgay = table.Column<double>(nullable: true),
                    SoDuCuoiKy = table.Column<double>(nullable: true),
<<<<<<< HEAD:src/Migrations/20191124090308_AddTables.cs
                    NghiepVu = table.Column<string>(maxLength: 50, nullable: true)
=======
                    NghiepVu = table.Column<string>(type: "ntext", nullable: true)
>>>>>>> d8379b457a26bb3903a865a43aa33e2abb374555:src/Migrations/20191123193352_Initial_Migration.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSoTietKiem", x => x.PhieuGuiRutTienId);
                    table.ForeignKey(
                        name: "FK_ChiTietSoTietKiem_PhieuGuiRutTien",
                        column: x => x.PhieuGuiRutTienId,
                        principalTable: "PhieuGuiRutTien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuGuiRutTien_MSKH",
                table: "PhieuGuiRutTien",
                column: "MSKH");

            migrationBuilder.CreateIndex(
                name: "IX_SoTK_LoaiTietKiemId",
                table: "SoTK",
                column: "LoaiTietKiemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietSoTietKiem");

            migrationBuilder.DropTable(
                name: "QuyDinh");

            migrationBuilder.DropTable(
                name: "PhieuGuiRutTien");

            migrationBuilder.DropTable(
                name: "SoTK");

            migrationBuilder.DropTable(
                name: "LoaiTietKiem");
        }
    }
}
