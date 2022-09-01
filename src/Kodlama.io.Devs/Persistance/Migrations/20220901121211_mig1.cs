using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgLanguages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProgLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "BMW" });

            migrationBuilder.InsertData(
                table: "ProgLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Mercedes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgLanguages");
        }
    }
}
