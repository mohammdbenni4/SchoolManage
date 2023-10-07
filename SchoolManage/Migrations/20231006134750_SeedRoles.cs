using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManage.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                    table: "Roles",
                    columns: new[] {"Id","Name", "NormalizedName", "ConcurrencyStamp" },
                    values: new object[] {Guid.NewGuid().ToString(), "Admin","Admin".ToUpper(),Guid.NewGuid().ToString()}
                ) ;
            migrationBuilder.InsertData(
                    table: "Roles",
                    columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                    values: new object[] { Guid.NewGuid().ToString(), "Teacher", "Teacher".ToUpper(), Guid.NewGuid().ToString() }
                ); 
            migrationBuilder.InsertData(
                    table: "Roles",
                    columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                    values: new object[] { Guid.NewGuid().ToString(), "Secretary", "Secretary".ToUpper(), Guid.NewGuid().ToString() }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Roles]");
        }
    }
}
