using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurrfectPair.Migrations
{
    /// <inheritdoc />
    public partial class m004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetAdoptingFormTable",
                columns: table => new
                {
                    pet_adopting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pet_submission_id = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAdoptingFormTable", x => x.pet_adopting_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetAdoptingFormTable");
        }
    }
}
