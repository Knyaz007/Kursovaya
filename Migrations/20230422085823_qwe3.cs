using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kursovaya.Migrations
{
    /// <inheritdoc />
    public partial class qwe3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToursId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ToursId",
                table: "Customers",
                column: "ToursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tours_ToursId",
                table: "Customers",
                column: "ToursId",
                principalTable: "Tours",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tours_ToursId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ToursId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ToursId",
                table: "Customers");
        }
    }
}
