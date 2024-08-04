using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolomonsAdviceWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class TemporallyAdjustForFavAdviceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteAdvices",
                table: "FavoriteAdvices");

            migrationBuilder.DeleteData(
                table: "FavoriteAdvices",
                keyColumn: "UserId",
                keyValue: "11189b29-5a80-4e45-b735-c8a05da230f7");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "FavoriteAdvices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteAdvices",
                table: "FavoriteAdvices",
                column: "Id");

            migrationBuilder.InsertData(
                table: "FavoriteAdvices",
                columns: new[] { "Id", "AdviceId", "UserId" },
                values: new object[] { "dc18f575-7507-4d63-85af-2a8c56905cf5", 1011, "11189b29-5a80-4e45-b735-c8a05da230f7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteAdvices",
                table: "FavoriteAdvices");

            migrationBuilder.DeleteData(
                table: "FavoriteAdvices",
                keyColumn: "Id",
                keyColumnType: "nvarchar(450)",
                keyValue: "dc18f575-7507-4d63-85af-2a8c56905cf5");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FavoriteAdvices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteAdvices",
                table: "FavoriteAdvices",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "FavoriteAdvices",
                columns: new[] { "UserId", "AdviceId" },
                values: new object[] { "11189b29-5a80-4e45-b735-c8a05da230f7", 1011 });
        }
    }
}
