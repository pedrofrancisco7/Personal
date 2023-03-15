using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yupass.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Permissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PerfilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcessoTemporario = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "Id", "AtualizadoEm", "CriadoEm", "Nome", "Permissao", "Status" },
                values: new object[,]
                {
                    { new Guid("127b7a47-e234-4525-92e3-33da0a913e9d"), null, new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2300), "Supervisor", "SUP", 1 },
                    { new Guid("1faf232e-199a-42b7-9f7f-02cab52f784b"), null, new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2250), "Administrador", "ADM", 1 },
                    { new Guid("37fb756f-a8e4-4263-91d3-dd92b13ccb0a"), null, new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2270), "Gestão de Acessos", "GA", 1 },
                    { new Guid("5057ddcc-6656-415c-a209-48224d72be30"), null, new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2310), "Operacional", "OPR", 1 },
                    { new Guid("71f596ac-2577-43b4-8027-f10d39d715b2"), null, new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2200), "SysAdmin", "SysAdmin", -1 },
                    { new Guid("c3e39ced-2d36-4c81-8642-b62c3efca2ef"), null, new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2290), "Centro de Operações de Rede", "NOC", 1 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "AcessoTemporario", "AtualizadoEm", "Cpf", "CriadoEm", "Email", "Nome", "PerfilId", "Senha", "Status" },
                values: new object[,]
                {
                    { new Guid("9a87bd3e-ee8b-4ea7-99e2-2981de6199c0"), false, null, "33667879881", new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2450), null, "Pedro Rodrigues", new Guid("71f596ac-2577-43b4-8027-f10d39d715b2"), "5feadddd041a836c742ccba61d11ebbc505a805552aec2cfc1225452a26683fb", 1 },
                    { new Guid("ebb5efb3-e879-4e2f-b61b-b857a8b40846"), false, null, "admin", new DateTime(2023, 1, 6, 12, 53, 27, 148, DateTimeKind.Local).AddTicks(2440), null, "Administrador", new Guid("71f596ac-2577-43b4-8027-f10d39d715b2"), "4cbf07ce91e4eb057dd4ea3be83ac829141cec8253be8dc167c702c35aa3b3ac", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_Id",
                table: "Perfis",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios",
                column: "PerfilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perfis");
        }
    }
}
