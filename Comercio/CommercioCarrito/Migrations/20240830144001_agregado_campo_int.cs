using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommercioCarrito.Migrations
{
    /// <inheritdoc />
    public partial class agregado_campo_int : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Producto",
                table: "CarritoSesionDetalles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "CarritoSesionDetalles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "CarritoSesionDetalles");

            migrationBuilder.AlterColumn<string>(
                name: "Producto",
                table: "CarritoSesionDetalles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
