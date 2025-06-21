using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiPostgre.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Vigencia = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "text", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sexo = table.Column<char>(type: "character(1)", nullable: false),
                    Rut = table.Column<string>(type: "text", nullable: false),
                    Vigencia = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    CodigoCategoria = table.Column<int>(type: "integer", nullable: false),
                    Vigencia = table.Column<bool>(type: "boolean", nullable: false),
                    Valoracion = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Modulos_Categorias_CodigoCategoria",
                        column: x => x.CodigoCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Contrasena = table.Column<string>(type: "text", nullable: false),
                    TipoUsuario = table.Column<int>(type: "integer", nullable: false),
                    CodigoPersona = table.Column<int>(type: "integer", nullable: false),
                    Vigencia = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_CodigoPersona",
                        column: x => x.CodigoPersona,
                        principalTable: "Personas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Valoraciones",
                columns: table => new
                {
                    CodigoValoracion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoPersona = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoraciones", x => x.CodigoValoracion);
                    table.ForeignKey(
                        name: "FK_Valoraciones_Personas_CodigoPersona",
                        column: x => x.CodigoPersona,
                        principalTable: "Personas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foros",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoPersona = table.Column<int>(type: "integer", nullable: false),
                    CodigoModulo = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foros", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Foros_Modulos_CodigoModulo",
                        column: x => x.CodigoModulo,
                        principalTable: "Modulos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Foros_Personas_CodigoPersona",
                        column: x => x.CodigoPersona,
                        principalTable: "Personas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Formato = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    CodigoModulo = table.Column<int>(type: "integer", nullable: false),
                    PersonaCreadora = table.Column<int>(type: "integer", nullable: false),
                    Vigencia = table.Column<bool>(type: "boolean", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Multimedia_Modulos_CodigoModulo",
                        column: x => x.CodigoModulo,
                        principalTable: "Modulos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Multimedia_Personas_PersonaCreadora",
                        column: x => x.PersonaCreadora,
                        principalTable: "Personas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CodigoPersona = table.Column<int>(type: "integer", nullable: false),
                    CodigoForo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Foros_CodigoForo",
                        column: x => x.CodigoForo,
                        principalTable: "Foros",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Personas_CodigoPersona",
                        column: x => x.CodigoPersona,
                        principalTable: "Personas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaMultimedia",
                columns: table => new
                {
                    CodigoPersona = table.Column<int>(type: "integer", nullable: false),
                    CodigoMultimedia = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaMultimedia", x => new { x.CodigoPersona, x.CodigoMultimedia });
                    table.ForeignKey(
                        name: "FK_PersonaMultimedia_Multimedia_CodigoMultimedia",
                        column: x => x.CodigoMultimedia,
                        principalTable: "Multimedia",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaMultimedia_Personas_CodigoPersona",
                        column: x => x.CodigoPersona,
                        principalTable: "Personas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foros_CodigoModulo",
                table: "Foros",
                column: "CodigoModulo");

            migrationBuilder.CreateIndex(
                name: "IX_Foros_CodigoPersona",
                table: "Foros",
                column: "CodigoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_CodigoCategoria",
                table: "Modulos",
                column: "CodigoCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_CodigoModulo",
                table: "Multimedia",
                column: "CodigoModulo");

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_PersonaCreadora",
                table: "Multimedia",
                column: "PersonaCreadora");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaMultimedia_CodigoMultimedia",
                table: "PersonaMultimedia",
                column: "CodigoMultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_CodigoForo",
                table: "Publicaciones",
                column: "CodigoForo");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_CodigoPersona",
                table: "Publicaciones",
                column: "CodigoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CodigoPersona",
                table: "Usuarios",
                column: "CodigoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Valoraciones_CodigoPersona",
                table: "Valoraciones",
                column: "CodigoPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaMultimedia");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Valoraciones");

            migrationBuilder.DropTable(
                name: "Multimedia");

            migrationBuilder.DropTable(
                name: "Foros");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
