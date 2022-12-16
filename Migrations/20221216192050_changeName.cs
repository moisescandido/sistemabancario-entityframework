using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banco.Migrations
{
    /// <inheritdoc />
    public partial class changeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContaCorrete",
                table: "ContaCorrete");

            migrationBuilder.RenameTable(
                name: "ContaCorrete",
                newName: "ContaCorrente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContaCorrente",
                table: "ContaCorrente",
                column: "Numero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContaCorrente",
                table: "ContaCorrente");

            migrationBuilder.RenameTable(
                name: "ContaCorrente",
                newName: "ContaCorrete");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContaCorrete",
                table: "ContaCorrete",
                column: "Numero");
        }
    }
}
