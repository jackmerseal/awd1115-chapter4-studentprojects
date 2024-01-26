using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactManager.Migrations
{
    /// <inheritdoc />
    public partial class Contacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "Firstname", "Lastname", "Phone" },
                values: new object[,]
                {
                    { 1, "james_hetfield@insideranken.org", "James", "Hetfield", "1234567890" },
                    { 2, "lars_ulrich@insideranken.org", "Lars", "Ulrich", "0987654321" },
                    { 3, "kirk_hammett@insideranken.org", "Kirk", "Hammett", "1357924680" },
                    { 4, "robert_trujillo@insideranken.org", "Robert", "Trujillo", "2468013579" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
