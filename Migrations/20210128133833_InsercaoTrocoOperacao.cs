using Microsoft.EntityFrameworkCore.Migrations;

namespace testetobr.Migrations
{
    public partial class InsercaoTrocoOperacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorTroco",
                table: "Operacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTroco",
                table: "Operacao");
        }
    }
}
