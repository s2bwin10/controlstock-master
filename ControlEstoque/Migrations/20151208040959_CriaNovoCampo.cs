using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ControlEstoque.Migrations
{
    public partial class CriaNovoCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Data", table: "Pedido");
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Pedido",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DataNascimento", table: "Pedido");
            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Pedido",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
