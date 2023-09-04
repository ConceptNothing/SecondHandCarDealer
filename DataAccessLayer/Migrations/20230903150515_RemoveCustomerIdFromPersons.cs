using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomerIdFromPersons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("3f15f605-7c03-45a2-ad92-8aeade94d878"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("9682d317-a31d-4e43-9a9a-ca2c9d5f9be0"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a6b68a23-41fc-47b9-9b16-0b6141144c78"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ef167409-460e-4df9-8a21-883ce49aa711"));

            migrationBuilder.DeleteData(
                table: "LegalPersons",
                keyColumn: "Id",
                keyValue: new Guid("a56aea8c-404c-434d-a74d-9b15c966b93e"));

            migrationBuilder.DeleteData(
                table: "LegalPersons",
                keyColumn: "Id",
                keyValue: new Guid("d3db25b4-da63-4c84-a2c4-226bec0b8081"));

            migrationBuilder.DeleteData(
                table: "NaturalPersons",
                keyColumn: "Id",
                keyValue: new Guid("a3b0ba5c-f640-4d76-ae32-53590f173e1a"));

            migrationBuilder.DeleteData(
                table: "NaturalPersons",
                keyColumn: "Id",
                keyValue: new Guid("ccea339c-6d4b-465c-a0a7-b10d9bde6b66"));

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "NaturalPersons");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "LegalPersons");

            migrationBuilder.InsertData(
                table: "LegalPersons",
                columns: new[] { "Id", "CompanyName", "DbCreationDate", "DbUpdateDate", "RegistrationNumber" },
                values: new object[,]
                {
                    { new Guid("1a6363d4-b182-4706-adc8-340243450a7b"), "XYZ Corp.", new DateTime(2023, 9, 3, 15, 5, 15, 598, DateTimeKind.Utc).AddTicks(8661), null, 67890 },
                    { new Guid("d2db18d2-4e74-4aff-8301-71fca336f961"), "ABC Inc.", new DateTime(2023, 9, 3, 15, 5, 15, 598, DateTimeKind.Utc).AddTicks(8658), null, 12345 }
                });

            migrationBuilder.InsertData(
                table: "NaturalPersons",
                columns: new[] { "Id", "DbCreationDate", "DbUpdateDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("04c57516-f54f-4dc8-87c1-f46616d9934a"), new DateTime(2023, 9, 3, 15, 5, 15, 598, DateTimeKind.Utc).AddTicks(8332), null, "Ion", "Buton" },
                    { new Guid("78a0bbbe-85fd-445f-a124-6e88aa059b37"), new DateTime(2023, 9, 3, 15, 5, 15, 598, DateTimeKind.Utc).AddTicks(8338), null, "Radu", "Bradu" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerType", "DbCreationDate", "DbUpdateDate", "LegalPersonId", "NaturalPersonId" },
                values: new object[,]
                {
                    { new Guid("543a5f75-4ebe-41a3-9b8b-30acce4f2e88"), "Natural", new DateTime(2023, 9, 3, 15, 5, 15, 598, DateTimeKind.Utc).AddTicks(8877), null, null, new Guid("78a0bbbe-85fd-445f-a124-6e88aa059b37") },
                    { new Guid("d2a1b1a9-2792-416a-bb49-6bfe6a4d311e"), "Legal", new DateTime(2023, 9, 3, 15, 5, 15, 598, DateTimeKind.Utc).AddTicks(8857), null, new Guid("1a6363d4-b182-4706-adc8-340243450a7b"), null },
                    { new Guid("d4bdca13-b5dd-4383-838e-1d9854e46dba"), "Natural", new DateTime(2023, 9, 3, 15, 5, 15, 598, DateTimeKind.Utc).AddTicks(8833), null, null, new Guid("04c57516-f54f-4dc8-87c1-f46616d9934a") },
                    { new Guid("fcc50198-a910-4793-b0cc-d7caf2fd91b3"), "Legal", new DateTime(2023, 9, 3, 15, 5, 15, 598, DateTimeKind.Utc).AddTicks(8893), null, new Guid("d2db18d2-4e74-4aff-8301-71fca336f961"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("543a5f75-4ebe-41a3-9b8b-30acce4f2e88"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d2a1b1a9-2792-416a-bb49-6bfe6a4d311e"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d4bdca13-b5dd-4383-838e-1d9854e46dba"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("fcc50198-a910-4793-b0cc-d7caf2fd91b3"));

            migrationBuilder.DeleteData(
                table: "LegalPersons",
                keyColumn: "Id",
                keyValue: new Guid("1a6363d4-b182-4706-adc8-340243450a7b"));

            migrationBuilder.DeleteData(
                table: "LegalPersons",
                keyColumn: "Id",
                keyValue: new Guid("d2db18d2-4e74-4aff-8301-71fca336f961"));

            migrationBuilder.DeleteData(
                table: "NaturalPersons",
                keyColumn: "Id",
                keyValue: new Guid("04c57516-f54f-4dc8-87c1-f46616d9934a"));

            migrationBuilder.DeleteData(
                table: "NaturalPersons",
                keyColumn: "Id",
                keyValue: new Guid("78a0bbbe-85fd-445f-a124-6e88aa059b37"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "NaturalPersons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "LegalPersons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }
    }
}
