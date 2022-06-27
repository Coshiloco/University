using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UiniversityApiBackend.Migrations
{
    public partial class CorrectionenumfieldofCursetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneType",
                table: "Curse",
                newName: "LevelAlumn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LevelAlumn",
                table: "Curse",
                newName: "PhoneType");
        }
    }
}
