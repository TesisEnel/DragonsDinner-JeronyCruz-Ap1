using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragonsDinner.Data.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Direcciones");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Direcciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ProvinciaId",
                table: "Direcciones",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Provincias_ProvinciaId",
                table: "Direcciones",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Provincias_ProvinciaId",
                table: "Direcciones");

            migrationBuilder.DropIndex(
                name: "IX_Direcciones_ProvinciaId",
                table: "Direcciones");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Direcciones");

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Direcciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
