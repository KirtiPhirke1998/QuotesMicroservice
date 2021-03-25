using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotesMicroservice.Migrations
{
    public partial class InitialModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuotesList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyValueFrom = table.Column<int>(type: "int", nullable: false),
                    PropertyValueTo = table.Column<int>(type: "int", nullable: false),
                    BussinessValueFrom = table.Column<int>(type: "int", nullable: false),
                    BussinessValueTo = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteInsurance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotesList", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotesList");
        }
    }
}
