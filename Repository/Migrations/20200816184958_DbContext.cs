using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class DbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Municipality = table.Column<string>(nullable: true),
                    FromDate = table.Column<string>(nullable: true),
                    ToDate = table.Column<string>(nullable: true),
                    TaxRate = table.Column<float>(nullable: false),
                    TaxSlab = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxes");
        }
    }
}
