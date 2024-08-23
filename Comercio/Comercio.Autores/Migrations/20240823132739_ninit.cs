using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Comercio.Autores.Migrations
{
    /// <inheritdoc />
    public partial class ninit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoresLibros",
                columns: table => new
                {
                    AutorLibroId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido = table.Column<string>(type: "text", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresLibros", x => x.AutorLibroId);
                });

            migrationBuilder.CreateTable(
                name: "GradoAcademicos",
                columns: table => new
                {
                    GradoAcademicoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    CentroAcademico = table.Column<string>(type: "text", nullable: true),
                    FechaGrado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AutorLibroId = table.Column<int>(type: "integer", nullable: false),
                    GradoAcademicoGuid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoAcademicos", x => x.GradoAcademicoId);
                    table.ForeignKey(
                        name: "FK_GradoAcademicos_AutoresLibros_AutorLibroId",
                        column: x => x.AutorLibroId,
                        principalTable: "AutoresLibros",
                        principalColumn: "AutorLibroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradoAcademicos_AutorLibroId",
                table: "GradoAcademicos",
                column: "AutorLibroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradoAcademicos");

            migrationBuilder.DropTable(
                name: "AutoresLibros");
        }
    }
}
