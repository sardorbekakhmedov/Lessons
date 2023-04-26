using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Data.DbContext.Migrations
{
    public partial class FirstMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_passport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    serial = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false, defaultValue: "AA"),
                    serial_numbers = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false, comment: "Hello this is first comment"),
                    pnfl = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 14, nullable: false),
                    Tin = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_passport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_passport");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
