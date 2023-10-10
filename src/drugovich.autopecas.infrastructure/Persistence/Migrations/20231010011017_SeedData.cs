using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace drugovich.autopecas.infrastructure.Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GERENTES",
                columns: new[] { "Id", "Email", "Nivel", "Nome" },
                values: new object[,]
                {
                    { 1, "gerente1@email.com", 1, "gerente1" },
                    { 2, "gerente2@email.com", 2, "gerente2" }
                });

            migrationBuilder.InsertData(
                table: "GRUPOS",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Grupo A" },
                    { 2, "Grupo B" }
                });

            migrationBuilder.InsertData(
                table: "CLIENTES",
                columns: new[] { "Id", "CNPJ", "DataFundacao", "GrupoId", "Nome" },
                values: new object[] { 1, "49341109000181", new DateTime(2022, 10, 9, 22, 10, 17, 379, DateTimeKind.Local).AddTicks(9578), 1, "Cliente1" });

            migrationBuilder.InsertData(
                table: "CLIENTES",
                columns: new[] { "Id", "CNPJ", "DataFundacao", "GrupoId", "Nome" },
                values: new object[] { 2, "49341109000181", new DateTime(2022, 10, 9, 22, 10, 17, 379, DateTimeKind.Local).AddTicks(9595), 2, "Cliente2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CLIENTES",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CLIENTES",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GERENTES",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GERENTES",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GRUPOS",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GRUPOS",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
