using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManage.Migrations
{
    /// <inheritdoc />
    public partial class AddBacTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BacSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BacSubjectCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BacSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacSubjectCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BacSubjectCourses_BacSubjects_BacSubjectId",
                        column: x => x.BacSubjectId,
                        principalTable: "BacSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BacSubjectCourses_BacSubjectId",
                table: "BacSubjectCourses",
                column: "BacSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BacSubjectCourses");

            migrationBuilder.DropTable(
                name: "BacSubjects");
        }
    }
}
