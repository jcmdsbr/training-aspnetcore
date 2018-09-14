using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhaLojaCore.Migrations
{
    public partial class MinhaLoja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "dbo");

            migrationBuilder.CreateTable(
                "categoria",
                schema: "dbo",
                columns: table => new
                {
                    cd_categoria = table.Column<Guid>(nullable: false),
                    dc_categoria = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_categoria", x => x.cd_categoria); });

            migrationBuilder.CreateTable(
                "fabricante",
                schema: "dbo",
                columns: table => new
                {
                    cd_fabricante = table.Column<Guid>(nullable: false),
                    cnpj = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_fabricante", x => x.cd_fabricante); });

            migrationBuilder.CreateTable(
                "produto",
                schema: "dbo",
                columns: table => new
                {
                    cd_produto = table.Column<Guid>(nullable: false),
                    dc_produto = table.Column<string>(nullable: true),
                    nm_produto = table.Column<string>(nullable: true),
                    dt_fabricacao = table.Column<DateTime>(nullable: false),
                    cd_fabricante = table.Column<Guid>(nullable: false),
                    cd_categoria = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.cd_produto);
                    table.ForeignKey(
                        "FK_produto_categoria_cd_categoria",
                        x => x.cd_categoria,
                        principalSchema: "dbo",
                        principalTable: "categoria",
                        principalColumn: "cd_categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_produto_fabricante_cd_fabricante",
                        x => x.cd_fabricante,
                        principalSchema: "dbo",
                        principalTable: "fabricante",
                        principalColumn: "cd_fabricante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_produto_cd_categoria",
                schema: "dbo",
                table: "produto",
                column: "cd_categoria");

            migrationBuilder.CreateIndex(
                "IX_produto_cd_fabricante",
                schema: "dbo",
                table: "produto",
                column: "cd_fabricante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "produto",
                "dbo");

            migrationBuilder.DropTable(
                "categoria",
                "dbo");

            migrationBuilder.DropTable(
                "fabricante",
                "dbo");
        }
    }
}