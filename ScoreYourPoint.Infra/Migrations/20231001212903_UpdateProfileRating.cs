using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreYourPoint.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfileRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "ProfileRatings",
                newName: "Rating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "ProfileRatings",
                newName: "Rate");
        }
    }
}
