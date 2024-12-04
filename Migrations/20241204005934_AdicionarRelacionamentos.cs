using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    PathImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientePedidos",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PedidoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePedidos", x => new { x.ClienteId, x.PedidoId });
                    table.ForeignKey(
                        name: "FK_ClientePedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientePedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PedidoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProdutos", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_PedidoProdutos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoryId",
                table: "Produtos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_StatusId",
                table: "Pedidos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePedidos_PedidoId",
                table: "ClientePedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProdutos_ProdutoId",
                table: "PedidoProdutos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoryId",
                table: "Produtos",
                column: "CategoryId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoryId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ClientePedidos");

            migrationBuilder.DropTable(
                name: "PedidoProdutos");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoryId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_StatusId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Pedidos");
        }
    }
}
