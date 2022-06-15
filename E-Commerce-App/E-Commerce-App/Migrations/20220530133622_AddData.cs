using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategorieId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Add a touch of natural beauty to your place! Through a variety of indoor ornamental plants equipped in containers and basins, in addition to large and small flowering indoor plants.", "INDOOR PLANTS " },
                    { 2, "A variety of outdoor plants that can be used in open spaces such as the garden of the house or around the walls and entrances of the house", "OUTDOOR PLANTS " },
                    { 3, "Bedroom plants can do more than just make your shelves look brighter. They can also boost your mood, enhance your creativity, reduce your stress levels, increase your productivity, naturally filter air pollutants, and much more. ", "Bedroom Plants " },
                    { 4, "Null", "Jungle Plants " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategorieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategorieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategorieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategorieId",
                keyValue: 4);
        }
    }
}
