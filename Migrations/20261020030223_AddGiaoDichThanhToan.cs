using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyThuVien_UNETI03_TI17A1ND.Migrations
{
    /// <inheritdoc />
    public partial class AddGiaoDichThanhToan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaoDichThanhToans",
                columns: table => new
                {
                    MaGiaoDich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaGiaoDichCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaPhieuMuon = table.Column<int>(type: "int", nullable: true),
                    MaDocGia = table.Column<int>(type: "int", nullable: true),
                    HuongDongTien = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LoaiThanhToan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NguonTienRa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NguonTienVao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhuongThuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NguoiThucHien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ThongTinTaiKhoanDoiUng = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayGiaoDich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoDichThanhToans", x => x.MaGiaoDich);
                    table.ForeignKey(
                        name: "FK_GiaoDichThanhToans_DocGias_MaDocGia",
                        column: x => x.MaDocGia,
                        principalTable: "DocGias",
                        principalColumn: "MaDocGia",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GiaoDichThanhToans_PhieuMuons_MaPhieuMuon",
                        column: x => x.MaPhieuMuon,
                        principalTable: "PhieuMuons",
                        principalColumn: "MaPhieuMuon",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDichThanhToans_MaDocGia",
                table: "GiaoDichThanhToans",
                column: "MaDocGia");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDichThanhToans_MaGiaoDichCode",
                table: "GiaoDichThanhToans",
                column: "MaGiaoDichCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDichThanhToans_MaPhieuMuon",
                table: "GiaoDichThanhToans",
                column: "MaPhieuMuon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaoDichThanhToans");
        }
    }
}
