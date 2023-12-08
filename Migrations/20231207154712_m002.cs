using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurrfectPair.Migrations
{
    /// <inheritdoc />
    public partial class m002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pet_type",
                table: "PetSubmitAdoptionTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pet_type",
                table: "PetSubmitAdoptionTable");
        }
    }
}
