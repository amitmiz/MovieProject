using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class add_supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimalAge",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Supplier",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Supplier",
                table: "Movie",
                column: "Supplier");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Supplier_Supplier",
                table: "Movie",
                column: "Supplier",
                principalTable: "Supplier",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Supplier_Supplier",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Movie_Supplier",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MinimalAge",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Movie");
        }
    }
}
