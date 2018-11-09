using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class Supplierid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Supplier_Supplier",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "Supplier",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Movie",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Supplier_Supplier",
                table: "Movie",
                column: "Supplier",
                principalTable: "Supplier",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Supplier_Supplier",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "Supplier",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Supplier_Supplier",
                table: "Movie",
                column: "Supplier",
                principalTable: "Supplier",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
