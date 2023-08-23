using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GokalpLogistics.Persistence.Migrations
{
    public partial class FIRST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DRIVER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    TRUCK_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRUCK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    TRUCKNAME = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    TRUCKMODEL = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    LAT = table.Column<int>(type: "integer", nullable: false),
                    LNG = table.Column<int>(type: "integer", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRUCK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRUCK_DRIVER_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DRIVER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRUCK_DriverId",
                table: "TRUCK",
                column: "DriverId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRUCK");

            migrationBuilder.DropTable(
                name: "DRIVER");
        }
    }
}
