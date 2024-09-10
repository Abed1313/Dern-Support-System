using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support_System.Migrations
{
    /// <inheritdoc />
    public partial class testUptodate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2104815488);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1781985664);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1708468834);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1116452279);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -845637696);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -812413140);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -771394173);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 587736595);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1100723984);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1180731845);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1370459705);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1910725503);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -2047670301, "permission", "read", "admin" },
                    { -1912651251, "permission", "read", "businesscustomer" },
                    { -1492081800, "permission", "read", "individualcustomer" },
                    { -991494723, "permission", "update", "businesscustomer" },
                    { -641507610, "permission", "create", "admin" },
                    { -279686423, "permission", "delete", "admin" },
                    { 55940501, "permission", "create", "individualcustomer" },
                    { 232718584, "permission", "delete", "individualcustomer" },
                    { 250136153, "permission", "update", "admin" },
                    { 441198366, "permission", "delete", "businesscustomer" },
                    { 1552062043, "permission", "update", "individualcustomer" },
                    { 2074163533, "permission", "create", "businesscustomer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "7d88d1c4-87dd-4e5e-aef5-a51dfb7dae77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer",
                column: "ConcurrencyStamp",
                value: "4b699389-3781-4f2f-a57d-663062b703bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer",
                column: "ConcurrencyStamp",
                value: "7fad279c-56cd-41fb-b053-d9680a541166");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2047670301);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1912651251);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1492081800);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -991494723);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -641507610);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -279686423);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 55940501);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 232718584);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 250136153);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 441198366);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1552062043);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2074163533);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -2104815488, "permission", "create", "admin" },
                    { -1781985664, "permission", "update", "individualcustomer" },
                    { -1708468834, "permission", "delete", "individualcustomer" },
                    { -1116452279, "permission", "update", "businesscustomer" },
                    { -845637696, "permission", "update", "admin" },
                    { -812413140, "permission", "create", "businesscustomer" },
                    { -771394173, "permission", "read", "businesscustomer" },
                    { 587736595, "permission", "read", "individualcustomer" },
                    { 1100723984, "permission", "create", "individualcustomer" },
                    { 1180731845, "permission", "read", "admin" },
                    { 1370459705, "permission", "delete", "businesscustomer" },
                    { 1910725503, "permission", "delete", "admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "79ae6478-3b03-4afb-a282-c46a26980813");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer",
                column: "ConcurrencyStamp",
                value: "33b5fd40-be11-47df-afc2-d963d6e064ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer",
                column: "ConcurrencyStamp",
                value: "f6e534f4-c754-4839-b260-f689aa9495f3");
        }
    }
}
