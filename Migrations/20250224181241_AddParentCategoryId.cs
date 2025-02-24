using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketProject.Migrations
{
    /// <inheritdoc />
    public partial class AddParentCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentCtegoryId",
                table: "Category",
                newName: "ParentCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "Category",
                newName: "ParentCtegoryId");
        }
    }
}
