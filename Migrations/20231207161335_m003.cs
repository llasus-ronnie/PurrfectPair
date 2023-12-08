using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurrfectPair.Migrations
{
    /// <inheritdoc />
    public partial class m003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "pet_is_adopting",
                table: "PetSubmitAdoptionTable",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pet_is_adopting",
                table: "PetSubmitAdoptionTable");
        }
    }
}
