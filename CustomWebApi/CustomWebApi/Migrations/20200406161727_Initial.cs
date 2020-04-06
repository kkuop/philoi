using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomWebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Fandoms",
                columns: table => new
                {
                    FandomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fandoms", x => x.FandomId);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Name" },
                values: new object[,]
                {
                    { 1, "Hiking" },
                    { 20, "Collecting" },
                    { 19, "Crafting" },
                    { 18, "Gaming" },
                    { 17, "Painting" },
                    { 15, "Kayaking" },
                    { 14, "Reading" },
                    { 13, "Bowling" },
                    { 12, "Skiing" },
                    { 11, "Boating" },
                    { 16, "Cooking" },
                    { 9, "Bicycling" },
                    { 8, "Exercising" },
                    { 7, "Hunting" },
                    { 6, "Fishing" },
                    { 5, "Gardening" },
                    { 4, "Traveling" },
                    { 3, "Camping" },
                    { 2, "Running" },
                    { 10, "Swimming" }
                });

            migrationBuilder.InsertData(
                table: "Fandoms",
                columns: new[] { "FandomId", "Name" },
                values: new object[,]
                {
                    { 10, "The Walking Dead" },
                    { 9, "Star Trek" },
                    { 8, "Pokemon" },
                    { 7, "The DC Universe" },
                    { 6, "Stranger Things" },
                    { 2, "Harry Potter" },
                    { 4, "Game of Thrones" },
                    { 3, "Star Wars" },
                    { 1, "The Lord of the Rings" },
                    { 11, "Fortnite" },
                    { 5, "Marvel" },
                    { 12, "Minecraft" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Fandoms");
        }
    }
}
