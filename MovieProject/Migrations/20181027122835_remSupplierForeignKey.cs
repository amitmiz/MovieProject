using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class remSupplierForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Supplier_Supplier",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_Supplier",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Movie");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_SupplierId",
                table: "Movie",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Supplier_SupplierId",
                table: "Movie",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Supplier_SupplierId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_SupplierId",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "Supplier",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
