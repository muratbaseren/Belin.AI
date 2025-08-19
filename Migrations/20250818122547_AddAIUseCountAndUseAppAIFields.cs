using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelinAI.Migrations
{
    /// <inheritdoc />
    public partial class AddAIUseCountAndUseAppAIFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AIUseCount",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.AddColumn<bool>(
                name: "UseAppAI",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AIUseCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UseAppAI",
                table: "AspNetUsers");
        }
    }
}
