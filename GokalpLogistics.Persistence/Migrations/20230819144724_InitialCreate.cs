using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GokalpLogistics.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DRIVER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    MODEL = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRUCKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    MODEL = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Lat = table.Column<int>(type: "int", nullable: false),
                    Lng = table.Column<int>(type: "int", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRUCKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRUCKS_DRIVER_ID",
                        column: x => x.ID,
                        principalTable: "DRIVER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRUCKS");

            migrationBuilder.DropTable(
                name: "DRIVER");
        }
    }
}
