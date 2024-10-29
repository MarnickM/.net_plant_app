using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plantdrationAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTagColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tag",
                table: "Plant",
                type: "nvarchar(max)",
                nullable: true);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPlant");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
