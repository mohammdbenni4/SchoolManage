using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManage.Migrations
{
    /// <inheritdoc />
    public partial class AddGradesColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grades",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grades",
                table: "Users");
        }
    }
}
