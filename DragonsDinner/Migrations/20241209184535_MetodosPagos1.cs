using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragonsDinner.Migrations
{
    /// <inheritdoc />
    public partial class MetodosPagos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetodosPagos_Tarjetas_TarjetaId",
                table: "MetodosPagos");

            migrationBuilder.DropIndex(
                name: "IX_MetodosPagos_TarjetaId",
                table: "MetodosPagos");

            migrationBuilder.DropColumn(
                name: "TarjetaId",
                table: "MetodosPagos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TarjetaId",
                table: "MetodosPagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MetodosPagos_TarjetaId",
                table: "MetodosPagos",
                column: "TarjetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetodosPagos_Tarjetas_TarjetaId",
                table: "MetodosPagos",
                column: "TarjetaId",
                principalTable: "Tarjetas",
                principalColumn: "TarjetaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
