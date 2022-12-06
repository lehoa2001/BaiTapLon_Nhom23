using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNhom23.Migrations
{
    /// <inheritdoc />
    public partial class QuanAo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuanAo",
                columns: table => new
                {
                    IDSp = table.Column<string>(type: "TEXT", nullable: false),
                    TenSp = table.Column<string>(type: "TEXT", nullable: true),
                    ThuongHieu = table.Column<string>(type: "TEXT", nullable: true),
                    GiaTien = table.Column<string>(type: "TEXT", nullable: true),
                    SoLuong = table.Column<int>(type: "INTEGER", nullable: true),
                    MaSize = table.Column<string>(type: "TEXT", nullable: true),
                    MaMau = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanAo", x => x.IDSp);
                    table.ForeignKey(
                        name: "FK_QuanAo_Mau_MaMau",
                        column: x => x.MaMau,
                        principalTable: "Mau",
                        principalColumn: "MaMau");
                    table.ForeignKey(
                        name: "FK_QuanAo_Size_MaSize",
                        column: x => x.MaSize,
                        principalTable: "Size",
                        principalColumn: "MaSize");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuanAo_MaMau",
                table: "QuanAo",
                column: "MaMau");

            migrationBuilder.CreateIndex(
                name: "IX_QuanAo_MaSize",
                table: "QuanAo",
                column: "MaSize");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuanAo");
        }
    }
}
