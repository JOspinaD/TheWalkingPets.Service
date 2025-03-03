using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWalkingPets.Service.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoMascota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreTipoMascota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMascota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashContraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RazaMascota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreRaza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoMascota = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RazaMascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RazaMascota_TipoMascota_IdTipoMascota",
                        column: x => x.IdTipoMascota,
                        principalTable: "TipoMascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgMascota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoMascota = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRazaMascota = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_RazaMascota_IdRazaMascota",
                        column: x => x.IdRazaMascota,
                        principalTable: "RazaMascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_TipoMascota_IdTipoMascota",
                        column: x => x.IdTipoMascota,
                        principalTable: "TipoMascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdRazaMascota",
                table: "Mascota",
                column: "IdRazaMascota");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdTipoMascota",
                table: "Mascota",
                column: "IdTipoMascota");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdUsuario",
                table: "Mascota",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RazaMascota_IdTipoMascota",
                table: "RazaMascota",
                column: "IdTipoMascota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "RazaMascota");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoMascota");
        }
    }
}
