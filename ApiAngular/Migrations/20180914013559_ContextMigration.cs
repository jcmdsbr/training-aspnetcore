using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAngular.Migrations
{
    public partial class ContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "dbo",
                columns: table => new
                {
                    id_customer = table.Column<Guid>(nullable: false),
                    nm_customer = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id_customer);
                });

            migrationBuilder.CreateTable(
                name: "document",
                schema: "dbo",
                columns: table => new
                {
                    id_document = table.Column<Guid>(nullable: false),
                    init_document = table.Column<string>(maxLength: 20, nullable: false),
                    dc_document = table.Column<string>(maxLength: 100, nullable: false),
                    id_status = table.Column<int>(nullable: false),
                    id_customer = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document", x => x.id_document);
                    table.ForeignKey(
                        name: "FK_document_customer_id_customer",
                        column: x => x.id_customer,
                        principalSchema: "dbo",
                        principalTable: "customer",
                        principalColumn: "id_customer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_document_id_customer",
                schema: "dbo",
                table: "document",
                column: "id_customer");

            migrationBuilder.CreateIndex(
                name: "IX_document_init_document",
                schema: "dbo",
                table: "document",
                column: "init_document",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "document",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "customer",
                schema: "dbo");
        }
    }
}
