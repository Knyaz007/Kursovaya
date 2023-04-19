using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kursovaya.Migrations
{
    /// <inheritdoc />
    public partial class TravlAgenDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otchestvo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tour_start_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_date_of_the_tour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_of_tour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_of_power_supply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hotel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departure_flight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arrival_flight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
