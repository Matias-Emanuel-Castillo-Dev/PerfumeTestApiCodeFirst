using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeTestApiBackend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeGender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfumerias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfumerias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    VolumeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfumes_Generos_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perfumes_Marcas_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perfumes_Volumes_VolumeID",
                        column: x => x.VolumeID,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    PerfumeID = table.Column<int>(type: "int", nullable: false),
                    PerfumeryID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => new { x.PerfumeID, x.PerfumeryID });
                    table.ForeignKey(
                        name: "FK_Stock_Perfumerias_PerfumeryID",
                        column: x => x.PerfumeryID,
                        principalTable: "Perfumerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Perfumes_PerfumeID",
                        column: x => x.PerfumeID,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_BrandID",
                table: "Perfumes",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_GenderID",
                table: "Perfumes",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_VolumeID",
                table: "Perfumes",
                column: "VolumeID");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_PerfumeryID",
                table: "Stock",
                column: "PerfumeryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Perfumerias");

            migrationBuilder.DropTable(
                name: "Perfumes");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Volumes");
        }
    }
}
