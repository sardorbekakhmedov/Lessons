using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson54_EF.Migrations
{
    public partial class FirstMgSQL_Server : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    viloyat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shahar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tuman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qishloq = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("manzil_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", maxLength: 200, nullable: false, defaultValue: 100),
                    address_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("person_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persons_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_persons_address_id",
                table: "persons",
                column: "address_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
