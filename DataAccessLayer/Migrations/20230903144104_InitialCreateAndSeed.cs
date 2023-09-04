using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: true),
                    DbCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DbUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    DbCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DbUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DbCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DbUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DbCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DbUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LegalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_LegalPersons_LegalPersonId",
                        column: x => x.LegalPersonId,
                        principalTable: "LegalPersons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_NaturalPersons_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPersons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DbCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DbUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LegalPersons",
                columns: new[] { "Id", "CompanyName", "CustomerId", "DbCreationDate", "DbUpdateDate", "RegistrationNumber" },
                values: new object[,]
                {
                    { new Guid("a56aea8c-404c-434d-a74d-9b15c966b93e"), "XYZ Corp.", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 3, 14, 41, 4, 870, DateTimeKind.Utc).AddTicks(898), null, 67890 },
                    { new Guid("d3db25b4-da63-4c84-a2c4-226bec0b8081"), "ABC Inc.", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 3, 14, 41, 4, 870, DateTimeKind.Utc).AddTicks(893), null, 12345 }
                });

            migrationBuilder.InsertData(
                table: "NaturalPersons",
                columns: new[] { "Id", "CustomerId", "DbCreationDate", "DbUpdateDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("a3b0ba5c-f640-4d76-ae32-53590f173e1a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 9, 3, 14, 41, 4, 870, DateTimeKind.Utc).AddTicks(549), null, "Ion", "Buton" },
                    { new Guid("ccea339c-6d4b-465c-a0a7-b10d9bde6b66"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Radu", "Bradu" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerType", "DbCreationDate", "DbUpdateDate", "LegalPersonId", "NaturalPersonId" },
                values: new object[,]
                {
                    { new Guid("3f15f605-7c03-45a2-ad92-8aeade94d878"), "Natural", new DateTime(2023, 9, 3, 14, 41, 4, 870, DateTimeKind.Utc).AddTicks(1105), null, null, new Guid("ccea339c-6d4b-465c-a0a7-b10d9bde6b66") },
                    { new Guid("9682d317-a31d-4e43-9a9a-ca2c9d5f9be0"), "Legal", new DateTime(2023, 9, 3, 14, 41, 4, 870, DateTimeKind.Utc).AddTicks(1120), null, new Guid("d3db25b4-da63-4c84-a2c4-226bec0b8081"), null },
                    { new Guid("a6b68a23-41fc-47b9-9b16-0b6141144c78"), "Natural", new DateTime(2023, 9, 3, 14, 41, 4, 870, DateTimeKind.Utc).AddTicks(1051), null, null, new Guid("a3b0ba5c-f640-4d76-ae32-53590f173e1a") },
                    { new Guid("ef167409-460e-4df9-8a21-883ce49aa711"), "Legal", new DateTime(2023, 9, 3, 14, 41, 4, 870, DateTimeKind.Utc).AddTicks(1073), null, new Guid("a56aea8c-404c-434d-a74d-9b15c966b93e"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LegalPersonId",
                table: "Customers",
                column: "LegalPersonId",
                unique: true,
                filter: "[LegalPersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NaturalPersonId",
                table: "Customers",
                column: "NaturalPersonId",
                unique: true,
                filter: "[NaturalPersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersons_RegistrationNumber",
                table: "LegalPersons",
                column: "RegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CarId",
                table: "Sales",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LegalPersons");

            migrationBuilder.DropTable(
                name: "NaturalPersons");
        }
    }
}
