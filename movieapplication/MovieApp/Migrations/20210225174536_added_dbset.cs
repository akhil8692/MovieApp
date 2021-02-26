using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Migrations
{
    public partial class added_dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loaction",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(nullable: false),
                    Pincode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaction", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Theatre",
                columns: table => new
                {
                    TheatreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheatreName = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theatre", x => x.TheatreId);
                    table.ForeignKey(
                        name: "FK_Theatre_Loaction_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Loaction",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Theatre_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Theatre_LocationId",
                table: "Theatre",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Theatre_MovieId",
                table: "Theatre",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Theatre");

            migrationBuilder.DropTable(
                name: "Loaction");
        }
    }
}
