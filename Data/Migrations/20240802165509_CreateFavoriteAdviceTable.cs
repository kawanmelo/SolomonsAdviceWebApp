using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolomonsAdviceWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateFavoriteAdviceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteAdvices",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    AdviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAdvices", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "FavoriteAdvices",
                columns: new[] { "UserId", "AdviceId" },
                values: new object[] { "11189b29-5a80-4e45-b735-c8a05da230f7", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteAdvices");
        }
    }
}
