using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionColumnAndRenameTrueOwnerColumnToOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrueOwner",
                table: "Wands",
                newName: "Owner");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Wands",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Wands");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Wands",
                newName: "TrueOwner");
        }
    }
}
