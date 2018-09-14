using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhaLojaCore.Migrations
{
    public partial class MinhaLoja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "categoria",
                schema: "dbo",
                columns: table => new
                {
                    cd_categoria = table.Column<Guid>(nullable: false),
                    dc_categoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.cd_categoria);
                });

            migrationBuilder.CreateTable(
                name: "fabricante",
                schema: "dbo",
                columns: table => new
                {
                    cd_fabricante = table.Column<Guid>(nullable: false),
                    cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fabricante", x => x.cd_fabricante);
                });

            migrationBuilder.CreateTable(
                name: "produto",
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
                        name: "FK_produto_categoria_cd_categoria",
                        column: x => x.cd_categoria,
                        principalSchema: "dbo",
                        principalTable: "categoria",
                        principalColumn: "cd_categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_fabricante_cd_fabricante",
                        column: x => x.cd_fabricante,
                        principalSchema: "dbo",
                        principalTable: "fabricante",
                        principalColumn: "cd_fabricante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_produto_cd_categoria",
                schema: "dbo",
                table: "produto",
                column: "cd_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_produto_cd_fabricante",
                schema: "dbo",
                table: "produto",
                column: "cd_fabricante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "categoria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "fabricante",
                schema: "dbo");
        }
    }
}
