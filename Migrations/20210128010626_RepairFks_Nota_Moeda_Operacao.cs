using Microsoft.EntityFrameworkCore.Migrations;

namespace testetobr.Migrations
{
    public partial class RepairFks_Nota_Moeda_Operacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMoeda",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "IdNota",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "IdOperacao",
                table: "SaidaTroco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMoeda",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdNota",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdOperacao",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
