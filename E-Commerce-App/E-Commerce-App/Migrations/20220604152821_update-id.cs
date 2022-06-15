using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Migrations
{
    public partial class updateid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Categories",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategorieId");
        }
    }
}
