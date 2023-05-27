using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthSystem.Migrations.Employee
{
    public partial class initialEmployeeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Egender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eaddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Eid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
