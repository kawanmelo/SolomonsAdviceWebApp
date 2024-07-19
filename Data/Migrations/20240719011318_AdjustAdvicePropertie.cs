using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolomonsAdviceWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdjustAdvicePropertie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verse",
                table: "Advices");

            migrationBuilder.AddColumn<string>(
                name: "Verses",
                table: "Advices",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Advices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Book", "Verses" },
                values: new object[] { "Provérbios", "7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verses",
                table: "Advices");

            migrationBuilder.AddColumn<int>(
                name: "Verse",
                table: "Advices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Advices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Book", "Verse" },
                values: new object[] { "", 19 });
        }
    }
}
