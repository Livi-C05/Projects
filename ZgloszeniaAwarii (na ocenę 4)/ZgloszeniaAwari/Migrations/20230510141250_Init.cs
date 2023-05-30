using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZgloszeniaAwari.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZgloszenieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Osoby",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zgloszenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TworcaZgloszeniaId = table.Column<int>(type: "int", nullable: false),
                    PrzypisaneDoId = table.Column<int>(type: "int", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wykonane = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zgloszenia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zgloszenia_Kategorje_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zgloszenia_Osoby_PrzypisaneDoId",
                        column: x => x.PrzypisaneDoId,
                        principalTable: "Osoby",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zgloszenia_Osoby_TworcaZgloszeniaId",
                        column: x => x.TworcaZgloszeniaId,
                        principalTable: "Osoby",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenia_KategoriaId",
                table: "Zgloszenia",
                column: "KategoriaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenia_PrzypisaneDoId",
                table: "Zgloszenia",
                column: "PrzypisaneDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenia_TworcaZgloszeniaId",
                table: "Zgloszenia",
                column: "TworcaZgloszeniaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zgloszenia");

            migrationBuilder.DropTable(
                name: "Kategorje");

            migrationBuilder.DropTable(
                name: "Osoby");
        }
    }
}
