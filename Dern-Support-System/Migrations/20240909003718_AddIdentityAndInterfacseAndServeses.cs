using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support_System.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityAndInterfacseAndServeses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" },
                    { "businesscustomer", "00000000-0000-0000-0000-000000000000", "BusinessCustomer", "BUSINESSCUSTOMER" },
                    { "individualcustomer", "00000000-0000-0000-0000-000000000000", "IndividualCustomer", "INDIVIDUALCUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -1868219705, "permission", "create", "admin" },
                    { -183095656, "permission", "update", "individualcustomer" },
                    { -41162732, "permission", "delete", "individualcustomer" },
                    { 778143606, "permission", "update", "businesscustomer" },
                    { 1475997296, "permission", "delete", "businesscustomer" },
                    { 1502810946, "permission", "update", "admin" },
                    { 1507721664, "permission", "read", "businesscustomer" },
                    { 1609879409, "permission", "read", "admin" },
                    { 1708036195, "permission", "create", "individualcustomer" },
                    { 1769301566, "permission", "delete", "admin" },
                    { 1884285527, "permission", "read", "individualcustomer" },
                    { 2108116023, "permission", "create", "businesscustomer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1868219705);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -183095656);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -41162732);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 778143606);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1475997296);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1502810946);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1507721664);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1609879409);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1708036195);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1769301566);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1884285527);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2108116023);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer");
        }
    }
}
