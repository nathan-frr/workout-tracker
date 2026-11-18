using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTracker.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseAssetId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssetId",
                table: "Exercises",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_AssetId",
                table: "Exercises",
                column: "AssetId",
                unique: true,
                filter: "\"IsBuiltIn\" = TRUE AND \"AssetId\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exercises_AssetId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "Exercises");
        }
    }
}
