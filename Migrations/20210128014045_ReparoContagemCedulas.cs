using Microsoft.EntityFrameworkCore.Migrations;

namespace testetobr.Migrations
{
    public partial class ReparoContagemCedulas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaidaTroco_Moeda_MoedaId",
                table: "SaidaTroco");

            migrationBuilder.DropForeignKey(
                name: "FK_SaidaTroco_Nota_NotaId",
                table: "SaidaTroco");

            migrationBuilder.DropForeignKey(
                name: "FK_SaidaTroco_Operacao_OperacaoId",
                table: "SaidaTroco");

            migrationBuilder.DropIndex(
                name: "IX_SaidaTroco_MoedaId",
                table: "SaidaTroco");

            migrationBuilder.DropIndex(
                name: "IX_SaidaTroco_NotaId",
                table: "SaidaTroco");

            migrationBuilder.DropIndex(
                name: "IX_SaidaTroco_OperacaoId",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "MoedaId",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "NotaId",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "OperacaoId",
                table: "SaidaTroco");

            migrationBuilder.AddColumn<int>(
                name: "IdOperacao",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoedaDe10",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoedaDe100",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoedaDe25",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoedaDe5",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoedaDe50",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotaDe10",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotaDe100",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotaDe2",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotaDe20",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotaDe200",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotaDe5",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotaDe50",
                table: "SaidaTroco",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOperacao",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "MoedaDe10",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "MoedaDe100",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "MoedaDe25",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "MoedaDe5",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "MoedaDe50",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "NotaDe10",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "NotaDe100",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "NotaDe2",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "NotaDe20",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "NotaDe200",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "NotaDe5",
                table: "SaidaTroco");

            migrationBuilder.DropColumn(
                name: "NotaDe50",
                table: "SaidaTroco");

            migrationBuilder.AddColumn<int>(
                name: "MoedaId",
                table: "SaidaTroco",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotaId",
                table: "SaidaTroco",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperacaoId",
                table: "SaidaTroco",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaidaTroco_MoedaId",
                table: "SaidaTroco",
                column: "MoedaId");

            migrationBuilder.CreateIndex(
                name: "IX_SaidaTroco_NotaId",
                table: "SaidaTroco",
                column: "NotaId");

            migrationBuilder.CreateIndex(
                name: "IX_SaidaTroco_OperacaoId",
                table: "SaidaTroco",
                column: "OperacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaidaTroco_Moeda_MoedaId",
                table: "SaidaTroco",
                column: "MoedaId",
                principalTable: "Moeda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaidaTroco_Nota_NotaId",
                table: "SaidaTroco",
                column: "NotaId",
                principalTable: "Nota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaidaTroco_Operacao_OperacaoId",
                table: "SaidaTroco",
                column: "OperacaoId",
                principalTable: "Operacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
