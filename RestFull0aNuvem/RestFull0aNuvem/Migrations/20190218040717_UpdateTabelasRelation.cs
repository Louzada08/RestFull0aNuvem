using Microsoft.EntityFrameworkCore.Migrations;

namespace RestFull0aNuvem.Migrations
{
    public partial class UpdateTabelasRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PermissaoParentId",
                table: "Permissao",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "PermissaoId",
                table: "Permissao",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_PermissaoId",
                table: "Permissao",
                column: "PermissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissao_Permissao_PermissaoId",
                table: "Permissao",
                column: "PermissaoId",
                principalTable: "Permissao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissao_Permissao_PermissaoId",
                table: "Permissao");

            migrationBuilder.DropIndex(
                name: "IX_Permissao_PermissaoId",
                table: "Permissao");

            migrationBuilder.DropColumn(
                name: "PermissaoId",
                table: "Permissao");

            migrationBuilder.AlterColumn<long>(
                name: "PermissaoParentId",
                table: "Permissao",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
