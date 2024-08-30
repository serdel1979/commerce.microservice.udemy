using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CommercioCarrito.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarritoSesions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarritoSesionDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Producto = table.Column<string>(type: "text", nullable: false),
                    CarritoSesionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesionDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarritoSesionDetalles_CarritoSesions_CarritoSesionId",
                        column: x => x.CarritoSesionId,
                        principalTable: "CarritoSesions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoSesionDetalles_CarritoSesionId",
                table: "CarritoSesionDetalles",
                column: "CarritoSesionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoSesionDetalles");

            migrationBuilder.DropTable(
                name: "CarritoSesions");
        }
    }
}
