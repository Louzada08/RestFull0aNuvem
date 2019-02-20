using Microsoft.EntityFrameworkCore.Migrations;

namespace RestFull0aNuvem.Migrations
{
    public partial class upgradeUsuarioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Idpk",
                table: "Usuario",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuario",
                newName: "Idpk");
        }
    }
}
