using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevMetrics.Infrastructure.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class UpdateUserTableWithProjectCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectCount",
                table: "Users");
        }
    }
}
