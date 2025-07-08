using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPostgre.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTypeEnumMappingFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Esta sección se ha comentado porque las operaciones de eliminación/renombrado
            // de claves/tablas estaban causando errores ("constraint not found" o problemas de renombrado)
            // debido a que el estado esperado por EF Core no coincidía con el estado real de tu base de datos.
            // Asumimos que la tabla 'usuarios' debe permanecer en minúsculas y que sus claves existentes son válidas.

            // migrationBuilder.DropForeignKey(
            //     name: "FK_usuarios_personas_codigo_persona",
            //     table: "usuarios");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_usuarios",
            //     table: "usuarios");

            // migrationBuilder.RenameTable(
            //     name: "usuarios",
            //     newName: "Usuarios"); // Esto estaba intentando renombrar a mayúsculas, causando conflictos.

            // migrationBuilder.RenameIndex(
            //     name: "IX_usuarios_codigo_persona",
            //     table: "Usuarios",
            //     newName: "IX_Usuarios_codigo_persona");

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_Usuarios",
            //     table: "Usuarios",
            //     column: "usuario");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Usuarios_personas_codigo_persona",
            //     table: "Usuarios",
            //     column: "codigo_persona",
            //     principalTable: "personas",
            //     principalColumn: "Codigo",
            //     onDelete: ReferentialAction.Cascade);

            // --- Cambio real para el mapeo de TipoUsuarioEnum (si es necesario) ---
            // Si la columna 'tipo_usuario' en tu base de datos NO ES de tipo 'text' (por ejemplo, si era 'integer' antes),
            // descomenta y ajusta la siguiente línea. Esto la convertirá a 'text'.
            // Si ya es 'text', no es necesario hacer nada aquí, y el método Up() puede quedar casi vacío.
            // migrationBuilder.AlterColumn<string>(
            //     name: "tipo_usuario",
            //     table: "usuarios", // Usa el nombre de tabla en minúsculas
            //     type: "text",
            //     nullable: false, // Ajusta a 'true' si tu propiedad TipoUsuario permite nulos
            //     oldClrType: typeof(int)); // Cambia 'typeof(int)' al tipo de dato ANTERIOR de la columna si no era un int.

            // Si la clave foránea 'FK_usuarios_personas_codigo_persona' estaba *realmente faltando*
            // y necesitas que se cree, y la línea 'DropForeignKey' anterior estaba causando el error
            // por no existir la FK, entonces puedes descomentar la siguiente línea para *añadirla*.
            // Solo si estás seguro de que la FK no existe y debe ser creada.
            // migrationBuilder.AddForeignKey(
            //     name: "FK_usuarios_personas_codigo_persona", // Nombre de la clave foránea (ajusta si es diferente)
            //     table: "usuarios", // Tabla en minúsculas
            //     column: "codigo_persona",
            //     principalTable: "personas",
            //     principalColumn: "Codigo",
            //     onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Las operaciones de reversión también se comentan para evitar errores,
            // ya que las operaciones originales en Up() fueron comentadas.

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Usuarios_personas_codigo_persona",
            //     table: "Usuarios");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_Usuarios",
            //     table: "Usuarios");

            // migrationBuilder.RenameTable(
            //     name: "Usuarios",
            //     newName: "usuarios");

            // migrationBuilder.RenameIndex(
            //     name: "IX_Usuarios_codigo_persona",
            //     table: "usuarios",
            //     newName: "IX_usuarios_codigo_persona");

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_usuarios",
            //     table: "usuarios",
            //     column: "usuario");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_usuarios_personas_codigo_persona",
            //     table: "usuarios",
            //     column: "codigo_persona",
            //     principalTable: "personas",
            //     principalColumn: "Codigo",
            //     onDelete: ReferentialAction.Cascade);

            // // Si descomentaste AlterColumn en Up(), su reversión iría aquí.
            // // migrationBuilder.AlterColumn<int>(
            // //     name: "tipo_usuario",
            // //     table: "usuarios",
            // //     type: "integer",
            // //     nullable: false,
            // //     oldClrType: typeof(string));

            // // Si descomentaste AddForeignKey en Up(), su reversión iría aquí.
            // // migrationBuilder.DropForeignKey(
            // //     name: "FK_usuarios_personas_codigo_persona",
            // //     table: "usuarios");
        }
    }
}