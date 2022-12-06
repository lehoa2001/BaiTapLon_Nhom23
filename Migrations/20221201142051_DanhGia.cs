using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNhom23.Migrations
{
    /// <inheritdoc />
    public partial class DanhGia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhGia",
                columns: table => new
                {
                    IDSp = table.Column<string>(type: "TEXT", nullable: false),
                    TenSp = table.Column<string>(type: "TEXT", nullable: true),
                    GopY = table.Column<string>(type: "TEXT", nullable: true),
                    DiemDanhGia = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGia", x => x.IDSp);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhGia");
        }
    }
}
