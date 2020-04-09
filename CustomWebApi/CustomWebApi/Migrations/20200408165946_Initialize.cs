using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomWebApi.Migrations
{
    public partial class Initialize : Migration
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

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.MusicId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
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
                    { 16, "Cooking" },
                    { 15, "Kayaking" },
                    { 14, "Reading" },
                    { 12, "Skiing" },
                    { 11, "Boating" },
                    { 13, "Bowling" },
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
                    { 8, "Pokemon" },
                    { 12, "Minecraft" },
                    { 10, "The Walking Dead" },
                    { 9, "Star Trek" },
                    { 7, "The DC Universe" },
                    { 11, "Fortnite" },
                    { 5, "Marvel" },
                    { 4, "Game of Thrones" },
                    { 3, "Star Wars" },
                    { 2, "Harry Potter" },
                    { 6, "Stranger Things" },
                    { 1, "The Lord of the Rings" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Name" },
                values: new object[,]
                {
                    { 10, "Thelma and Louise" },
                    { 9, "Toy Story 2" },
                    { 8, "Jurassic Park" },
                    { 7, "Before Sunrise" },
                    { 6, "The Big Lebowski" },
                    { 4, "The Lion King" },
                    { 3, "The Shawshank Redemption" },
                    { 2, "Pulp Fiction" },
                    { 1, "The Departed" },
                    { 5, "Titanic" }
                });

            migrationBuilder.InsertData(
                table: "Music",
                columns: new[] { "MusicId", "Name" },
                values: new object[,]
                {
                    { 10, "Madonna" },
                    { 14, "Mariah Carey" },
                    { 15, "Eagles" },
                    { 13, "Taylor Swift" },
                    { 12, "Eminem" },
                    { 11, "Rihanna" },
                    { 9, "Elton John" },
                    { 2, "Guns N' Roses" },
                    { 7, "Elvis Presley" },
                    { 6, "The Rolling Stones" },
                    { 5, "Queen" },
                    { 4, "Led Zeppelin" },
                    { 3, "Pink Floyd" },
                    { 1, "The Beatles" },
                    { 8, "Michael Jackson" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { 4, "Hockey" },
                    { 1, "American Football" },
                    { 2, "Baseball" },
                    { 3, "Basketball" },
                    { 5, "Soccer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Fandoms");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
