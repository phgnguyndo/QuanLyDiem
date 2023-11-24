using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_QuanLiDiem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaiDois",
                columns: table => new
                {
                    MaDaiDoi = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnhDaiDoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDaiDoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaiDoiTruong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanSo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaiDois", x => x.MaDaiDoi);
                });

            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    MaKhoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TokenId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RefreshToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", unicode: false, maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LopChuyenNganhs",
                columns: table => new
                {
                    MaLopChuyenNganh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DaiDoiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnhLCN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenLopChuyenNganh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoHV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopChuyenNganhs", x => x.MaLopChuyenNganh);
                    table.ForeignKey(
                        name: "FK_LopChuyenNganhs_DaiDois_DaiDoiId",
                        column: x => x.DaiDoiId,
                        principalTable: "DaiDois",
                        principalColumn: "MaDaiDoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoMons",
                columns: table => new
                {
                    MaBM = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenBM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMons", x => x.MaBM);
                    table.ForeignKey(
                        name: "FK_BoMons_Khoas_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    MaHV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LopChuyenNganhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhHV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    QueQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapBac = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.MaHV);
                    table.ForeignKey(
                        name: "FK_HocViens_LopChuyenNganhs_LopChuyenNganhId",
                        column: x => x.LopChuyenNganhId,
                        principalTable: "LopChuyenNganhs",
                        principalColumn: "MaLopChuyenNganh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiangViens",
                columns: table => new
                {
                    MaGV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoMonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangViens", x => x.MaGV);
                    table.ForeignKey(
                        name: "FK_GiangViens_BoMons_BoMonId",
                        column: x => x.BoMonId,
                        principalTable: "BoMons",
                        principalColumn: "MaBM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocPhans",
                columns: table => new
                {
                    MaHocPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHocPhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTiet = table.Column<int>(type: "int", nullable: false),
                    SoTC = table.Column<int>(type: "int", nullable: false),
                    HocKy = table.Column<int>(type: "int", nullable: false),
                    BoMonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocPhans", x => x.MaHocPhan);
                    table.ForeignKey(
                        name: "FK_HocPhans_BoMons_BoMonId",
                        column: x => x.BoMonId,
                        principalTable: "BoMons",
                        principalColumn: "MaBM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhans",
                columns: table => new
                {
                    MaLopHocPhan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoHV = table.Column<int>(type: "int", nullable: false),
                    HocPhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhans", x => x.MaLopHocPhan);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_HocPhans_HocPhanId",
                        column: x => x.HocPhanId,
                        principalTable: "HocPhans",
                        principalColumn: "MaHocPhan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayHocs",
                columns: table => new
                {
                    MaDayHoc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiangVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LopHocPhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayHocs", x => x.MaDayHoc);
                    table.ForeignKey(
                        name: "FK_DayHocs_GiangViens_GiangVienId",
                        column: x => x.GiangVienId,
                        principalTable: "GiangViens",
                        principalColumn: "MaGV");
                    table.ForeignKey(
                        name: "FK_DayHocs_LopHocPhans_LopHocPhanId",
                        column: x => x.LopHocPhanId,
                        principalTable: "LopHocPhans",
                        principalColumn: "MaLopHocPhan");
                });

            migrationBuilder.CreateTable(
                name: "PhieuDiems",
                columns: table => new
                {
                    MaPhieuDiem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LopHocPhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HocVienId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiemCC = table.Column<float>(type: "real", nullable: false),
                    DiemTX = table.Column<float>(type: "real", nullable: false),
                    DiemThi = table.Column<float>(type: "real", nullable: false),
                    DiemThiLai = table.Column<float>(type: "real", nullable: false),
                    LanThi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuDiems", x => x.MaPhieuDiem);
                    table.ForeignKey(
                        name: "FK_PhieuDiems_HocViens_HocVienId",
                        column: x => x.HocVienId,
                        principalTable: "HocViens",
                        principalColumn: "MaHV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuDiems_LopHocPhans_LopHocPhanId",
                        column: x => x.LopHocPhanId,
                        principalTable: "LopHocPhans",
                        principalColumn: "MaLopHocPhan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoMons_KhoaId",
                table: "BoMons",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_DayHocs_GiangVienId",
                table: "DayHocs",
                column: "GiangVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DayHocs_LopHocPhanId",
                table: "DayHocs",
                column: "LopHocPhanId");

            migrationBuilder.CreateIndex(
                name: "IX_GiangViens_BoMonId",
                table: "GiangViens",
                column: "BoMonId");

            migrationBuilder.CreateIndex(
                name: "IX_HocPhans_BoMonId",
                table: "HocPhans",
                column: "BoMonId");

            migrationBuilder.CreateIndex(
                name: "IX_HocViens_LopChuyenNganhId",
                table: "HocViens",
                column: "LopChuyenNganhId");

            migrationBuilder.CreateIndex(
                name: "IX_LopChuyenNganhs_DaiDoiId",
                table: "LopChuyenNganhs",
                column: "DaiDoiId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_HocPhanId",
                table: "LopHocPhans",
                column: "HocPhanId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDiems_HocVienId",
                table: "PhieuDiems",
                column: "HocVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDiems_LopHocPhanId",
                table: "PhieuDiems",
                column: "LopHocPhanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayHocs");

            migrationBuilder.DropTable(
                name: "PhieuDiems");

            migrationBuilder.DropTable(
                name: "tbl_RefreshToken");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "GiangViens");

            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "LopHocPhans");

            migrationBuilder.DropTable(
                name: "LopChuyenNganhs");

            migrationBuilder.DropTable(
                name: "HocPhans");

            migrationBuilder.DropTable(
                name: "DaiDois");

            migrationBuilder.DropTable(
                name: "BoMons");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
