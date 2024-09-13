using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support_System.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2052143153);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1695175372);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -504630008);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 138156407);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 325277889);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 525508456);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 638874027);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 759287380);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1130473135);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1540902489);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1571957260);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2111330062);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -2093852423, "permission", "read", "businesscustomer" },
                    { -651211210, "permission", "read", "admin" },
                    { -576382775, "permission", "create", "businesscustomer" },
                    { 237156214, "permission", "update", "admin" },
                    { 394852162, "permission", "create", "individualcustomer" },
                    { 593798803, "permission", "update", "individualcustomer" },
                    { 1142204328, "permission", "delete", "individualcustomer" },
                    { 1279504267, "permission", "delete", "admin" },
                    { 1482293740, "permission", "delete", "businesscustomer" },
                    { 1497793244, "permission", "read", "individualcustomer" },
                    { 1827254477, "permission", "create", "admin" },
                    { 1937948768, "permission", "update", "businesscustomer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "7317e49b-1f47-483f-9693-609b2869e21e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer",
                column: "ConcurrencyStamp",
                value: "a4bc50c6-621d-4aed-b379-dbdbfbec7b05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer",
                column: "ConcurrencyStamp",
                value: "565eb0bd-3752-4d73-ac00-f0bd4ceb533f");

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Availability", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, "Available", "John Doe", "Electrical" },
                    { 2, "Not Available", "Jane Smith", "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "TechnicianTasks",
                columns: new[] { "TechnicianTaskId", "Description", "Status", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 1, "Fix the power outage in the main office.", "In Progress", 1, "Power Outage Repair" },
                    { 2, "Repair the broken circuit in server room.", "Pending", 2, "Broken Circuit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2093852423);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -651211210);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -576382775);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 237156214);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 394852162);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 593798803);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1142204328);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1279504267);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1482293740);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1497793244);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1827254477);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1937948768);

            migrationBuilder.DeleteData(
                table: "TechnicianTasks",
                keyColumn: "TechnicianTaskId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TechnicianTasks",
                keyColumn: "TechnicianTaskId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -2052143153, "permission", "delete", "individualcustomer" },
                    { -1695175372, "permission", "read", "individualcustomer" },
                    { -504630008, "permission", "create", "admin" },
                    { 138156407, "permission", "update", "businesscustomer" },
                    { 325277889, "permission", "update", "individualcustomer" },
                    { 525508456, "permission", "create", "individualcustomer" },
                    { 638874027, "permission", "read", "businesscustomer" },
                    { 759287380, "permission", "create", "businesscustomer" },
                    { 1130473135, "permission", "read", "admin" },
                    { 1540902489, "permission", "delete", "admin" },
                    { 1571957260, "permission", "update", "admin" },
                    { 2111330062, "permission", "delete", "businesscustomer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "6f6011a2-98ea-40cd-b59a-e077c625ef8f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer",
                column: "ConcurrencyStamp",
                value: "5b0e7e9b-857d-40e5-8bb8-3b1a10a450dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer",
                column: "ConcurrencyStamp",
                value: "76a7dddc-f37b-44fc-a02f-bcab2c03bd58");
        }
    }
}
