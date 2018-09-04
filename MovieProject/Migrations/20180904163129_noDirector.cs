using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class noDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieDirecotr_DirectorID",
                table: "Movie");

            //migrationBuilder.DropTable(
            //    name: "MovieDirecotr");

            migrationBuilder.DropIndex(
                name: "IX_Movie_DirectorID",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");

            migrationBuilder.AddColumn<long>(
                name: "DirectorID",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieDirecotr",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    Genere = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirecotr", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorID",
                table: "Movie",
                column: "DirectorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieDirecotr_DirectorID",
                table: "Movie",
                column: "DirectorID",
                principalTable: "MovieDirecotr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
