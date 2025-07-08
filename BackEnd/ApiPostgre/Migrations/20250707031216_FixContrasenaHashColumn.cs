using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPostgre.Migrations
{
    /// <inheritdoc />
    public partial class FixContrasenaHashColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foros_Modulos_CodigoModulo",
                table: "Foros");

            migrationBuilder.DropForeignKey(
                name: "FK_Foros_Personas_CodigoPersona",
                table: "Foros");

            migrationBuilder.DropForeignKey(
                name: "FK_Modulos_Categorias_CodigoCategoria",
                table: "Modulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Multimedia_Modulos_CodigoModulo",
                table: "Multimedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Multimedia_Personas_PersonaCreadora",
                table: "Multimedia");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaMultimedia_Multimedia_CodigoMultimedia",
                table: "PersonaMultimedia");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaMultimedia_Personas_CodigoPersona",
                table: "PersonaMultimedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_Foros_CodigoForo",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_Personas_CodigoPersona",
                table: "Publicaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Personas_CodigoPersona",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Valoraciones_Personas_CodigoPersona",
                table: "Valoraciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Valoraciones",
                table: "Valoraciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Multimedia",
                table: "Multimedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modulos",
                table: "Modulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicaciones",
                table: "Publicaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonaMultimedia",
                table: "PersonaMultimedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foros",
                table: "Foros");

            migrationBuilder.DropColumn(
                name: "Contrasena",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Vigencia",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Valoraciones",
                newName: "valoraciones");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "personas");

            migrationBuilder.RenameTable(
                name: "Multimedia",
                newName: "multimedia");

            migrationBuilder.RenameTable(
                name: "Modulos",
                newName: "modulos");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "categorias");

            migrationBuilder.RenameTable(
                name: "Publicaciones",
                newName: "publicacion");

            migrationBuilder.RenameTable(
                name: "PersonaMultimedia",
                newName: "persona_multimedia");

            migrationBuilder.RenameTable(
                name: "Foros",
                newName: "foro");

            migrationBuilder.RenameIndex(
                name: "IX_Valoraciones_CodigoPersona",
                table: "valoraciones",
                newName: "IX_valoraciones_CodigoPersona");

            migrationBuilder.RenameColumn(
                name: "TipoUsuario",
                table: "usuarios",
                newName: "tipo_usuario");

            migrationBuilder.RenameColumn(
                name: "CodigoPersona",
                table: "usuarios",
                newName: "codigo_persona");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "usuarios",
                newName: "usuario");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "usuarios",
                newName: "contrasena_hash");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_CodigoPersona",
                table: "usuarios",
                newName: "IX_usuarios_codigo_persona");

            migrationBuilder.RenameIndex(
                name: "IX_Multimedia_PersonaCreadora",
                table: "multimedia",
                newName: "IX_multimedia_PersonaCreadora");

            migrationBuilder.RenameIndex(
                name: "IX_Multimedia_CodigoModulo",
                table: "multimedia",
                newName: "IX_multimedia_CodigoModulo");

            migrationBuilder.RenameIndex(
                name: "IX_Modulos_CodigoCategoria",
                table: "modulos",
                newName: "IX_modulos_CodigoCategoria");

            migrationBuilder.RenameColumn(
                name: "Vigencia",
                table: "categorias",
                newName: "vigencia");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "categorias",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "categorias",
                newName: "codigo");

            migrationBuilder.RenameIndex(
                name: "IX_Publicaciones_CodigoPersona",
                table: "publicacion",
                newName: "IX_publicacion_CodigoPersona");

            migrationBuilder.RenameIndex(
                name: "IX_Publicaciones_CodigoForo",
                table: "publicacion",
                newName: "IX_publicacion_CodigoForo");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaMultimedia_CodigoMultimedia",
                table: "persona_multimedia",
                newName: "IX_persona_multimedia_CodigoMultimedia");

            migrationBuilder.RenameIndex(
                name: "IX_Foros_CodigoPersona",
                table: "foro",
                newName: "IX_foro_CodigoPersona");

            migrationBuilder.RenameIndex(
                name: "IX_Foros_CodigoModulo",
                table: "foro",
                newName: "IX_foro_CodigoModulo");

            migrationBuilder.AlterColumn<string>(
                name: "tipo_usuario",
                table: "usuarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "categorias",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_valoraciones",
                table: "valoraciones",
                column: "CodigoValoracion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personas",
                table: "personas",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_multimedia",
                table: "multimedia",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modulos",
                table: "modulos",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categorias",
                table: "categorias",
                column: "codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_publicacion",
                table: "publicacion",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_persona_multimedia",
                table: "persona_multimedia",
                columns: new[] { "CodigoPersona", "CodigoMultimedia" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_foro",
                table: "foro",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_foro_modulos_CodigoModulo",
                table: "foro",
                column: "CodigoModulo",
                principalTable: "modulos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_foro_personas_CodigoPersona",
                table: "foro",
                column: "CodigoPersona",
                principalTable: "personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modulos_categorias_CodigoCategoria",
                table: "modulos",
                column: "CodigoCategoria",
                principalTable: "categorias",
                principalColumn: "codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_multimedia_modulos_CodigoModulo",
                table: "multimedia",
                column: "CodigoModulo",
                principalTable: "modulos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_multimedia_personas_PersonaCreadora",
                table: "multimedia",
                column: "PersonaCreadora",
                principalTable: "personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_multimedia_multimedia_CodigoMultimedia",
                table: "persona_multimedia",
                column: "CodigoMultimedia",
                principalTable: "multimedia",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_multimedia_personas_CodigoPersona",
                table: "persona_multimedia",
                column: "CodigoPersona",
                principalTable: "personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publicacion_foro_CodigoForo",
                table: "publicacion",
                column: "CodigoForo",
                principalTable: "foro",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publicacion_personas_CodigoPersona",
                table: "publicacion",
                column: "CodigoPersona",
                principalTable: "personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_personas_codigo_persona",
                table: "usuarios",
                column: "codigo_persona",
                principalTable: "personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_valoraciones_personas_CodigoPersona",
                table: "valoraciones",
                column: "CodigoPersona",
                principalTable: "personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foro_modulos_CodigoModulo",
                table: "foro");

            migrationBuilder.DropForeignKey(
                name: "FK_foro_personas_CodigoPersona",
                table: "foro");

            migrationBuilder.DropForeignKey(
                name: "FK_modulos_categorias_CodigoCategoria",
                table: "modulos");

            migrationBuilder.DropForeignKey(
                name: "FK_multimedia_modulos_CodigoModulo",
                table: "multimedia");

            migrationBuilder.DropForeignKey(
                name: "FK_multimedia_personas_PersonaCreadora",
                table: "multimedia");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_multimedia_multimedia_CodigoMultimedia",
                table: "persona_multimedia");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_multimedia_personas_CodigoPersona",
                table: "persona_multimedia");

            migrationBuilder.DropForeignKey(
                name: "FK_publicacion_foro_CodigoForo",
                table: "publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_publicacion_personas_CodigoPersona",
                table: "publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_personas_codigo_persona",
                table: "usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_valoraciones_personas_CodigoPersona",
                table: "valoraciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_valoraciones",
                table: "valoraciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_personas",
                table: "personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_multimedia",
                table: "multimedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modulos",
                table: "modulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categorias",
                table: "categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_publicacion",
                table: "publicacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_persona_multimedia",
                table: "persona_multimedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_foro",
                table: "foro");

            migrationBuilder.RenameTable(
                name: "valoraciones",
                newName: "Valoraciones");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "personas",
                newName: "Personas");

            migrationBuilder.RenameTable(
                name: "multimedia",
                newName: "Multimedia");

            migrationBuilder.RenameTable(
                name: "modulos",
                newName: "Modulos");

            migrationBuilder.RenameTable(
                name: "categorias",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "publicacion",
                newName: "Publicaciones");

            migrationBuilder.RenameTable(
                name: "persona_multimedia",
                newName: "PersonaMultimedia");

            migrationBuilder.RenameTable(
                name: "foro",
                newName: "Foros");

            migrationBuilder.RenameIndex(
                name: "IX_valoraciones_CodigoPersona",
                table: "Valoraciones",
                newName: "IX_Valoraciones_CodigoPersona");

            migrationBuilder.RenameColumn(
                name: "tipo_usuario",
                table: "Usuarios",
                newName: "TipoUsuario");

            migrationBuilder.RenameColumn(
                name: "codigo_persona",
                table: "Usuarios",
                newName: "CodigoPersona");

            migrationBuilder.RenameColumn(
                name: "usuario",
                table: "Usuarios",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "contrasena_hash",
                table: "Usuarios",
                newName: "Correo");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_codigo_persona",
                table: "Usuarios",
                newName: "IX_Usuarios_CodigoPersona");

            migrationBuilder.RenameIndex(
                name: "IX_multimedia_PersonaCreadora",
                table: "Multimedia",
                newName: "IX_Multimedia_PersonaCreadora");

            migrationBuilder.RenameIndex(
                name: "IX_multimedia_CodigoModulo",
                table: "Multimedia",
                newName: "IX_Multimedia_CodigoModulo");

            migrationBuilder.RenameIndex(
                name: "IX_modulos_CodigoCategoria",
                table: "Modulos",
                newName: "IX_Modulos_CodigoCategoria");

            migrationBuilder.RenameColumn(
                name: "vigencia",
                table: "Categorias",
                newName: "Vigencia");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "Categorias",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "Categorias",
                newName: "Codigo");

            migrationBuilder.RenameIndex(
                name: "IX_publicacion_CodigoPersona",
                table: "Publicaciones",
                newName: "IX_Publicaciones_CodigoPersona");

            migrationBuilder.RenameIndex(
                name: "IX_publicacion_CodigoForo",
                table: "Publicaciones",
                newName: "IX_Publicaciones_CodigoForo");

            migrationBuilder.RenameIndex(
                name: "IX_persona_multimedia_CodigoMultimedia",
                table: "PersonaMultimedia",
                newName: "IX_PersonaMultimedia_CodigoMultimedia");

            migrationBuilder.RenameIndex(
                name: "IX_foro_CodigoPersona",
                table: "Foros",
                newName: "IX_Foros_CodigoPersona");

            migrationBuilder.RenameIndex(
                name: "IX_foro_CodigoModulo",
                table: "Foros",
                newName: "IX_Foros_CodigoModulo");

            migrationBuilder.AlterColumn<int>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Contrasena",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Vigencia",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Valoraciones",
                table: "Valoraciones",
                column: "CodigoValoracion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Multimedia",
                table: "Multimedia",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modulos",
                table: "Modulos",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicaciones",
                table: "Publicaciones",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonaMultimedia",
                table: "PersonaMultimedia",
                columns: new[] { "CodigoPersona", "CodigoMultimedia" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foros",
                table: "Foros",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Foros_Modulos_CodigoModulo",
                table: "Foros",
                column: "CodigoModulo",
                principalTable: "Modulos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foros_Personas_CodigoPersona",
                table: "Foros",
                column: "CodigoPersona",
                principalTable: "Personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modulos_Categorias_CodigoCategoria",
                table: "Modulos",
                column: "CodigoCategoria",
                principalTable: "Categorias",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Multimedia_Modulos_CodigoModulo",
                table: "Multimedia",
                column: "CodigoModulo",
                principalTable: "Modulos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Multimedia_Personas_PersonaCreadora",
                table: "Multimedia",
                column: "PersonaCreadora",
                principalTable: "Personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaMultimedia_Multimedia_CodigoMultimedia",
                table: "PersonaMultimedia",
                column: "CodigoMultimedia",
                principalTable: "Multimedia",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaMultimedia_Personas_CodigoPersona",
                table: "PersonaMultimedia",
                column: "CodigoPersona",
                principalTable: "Personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_Foros_CodigoForo",
                table: "Publicaciones",
                column: "CodigoForo",
                principalTable: "Foros",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_Personas_CodigoPersona",
                table: "Publicaciones",
                column: "CodigoPersona",
                principalTable: "Personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Personas_CodigoPersona",
                table: "Usuarios",
                column: "CodigoPersona",
                principalTable: "Personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Valoraciones_Personas_CodigoPersona",
                table: "Valoraciones",
                column: "CodigoPersona",
                principalTable: "Personas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
