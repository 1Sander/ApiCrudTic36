using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BaseDescription",
                table: "Produtos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Produtos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Produtos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PathImage",
                table: "Produtos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Produtos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseDescription",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PathImage",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Produtos");
        }
    }
}
