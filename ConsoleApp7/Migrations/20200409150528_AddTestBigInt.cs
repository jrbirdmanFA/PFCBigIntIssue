using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp7.Migrations
{
    public partial class AddTestBigInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestBigInts",
                columns: table => new
                {
                    TestBigIntId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestBigInts", x => x.TestBigIntId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestBigInts");
        }
    }
}
