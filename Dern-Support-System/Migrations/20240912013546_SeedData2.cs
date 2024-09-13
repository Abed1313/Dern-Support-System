using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support_System.Migrations
{
    /// <inheritdoc />
    public partial class SeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -2074567936, "permission", "create", "individualcustomer" },
                    { -1866112300, "permission", "create", "admin" },
                    { -1132104613, "permission", "read", "admin" },
                    { -1004053481, "permission", "read", "businesscustomer" },
                    { -431592150, "permission", "update", "businesscustomer" },
                    { -131178485, "permission", "read", "individualcustomer" },
                    { 128982535, "permission", "delete", "individualcustomer" },
                    { 283993166, "permission", "update", "admin" },
                    { 424183648, "permission", "update", "individualcustomer" },
                    { 778124974, "permission", "create", "businesscustomer" },
                    { 1600726977, "permission", "delete", "admin" },
                    { 1969426215, "permission", "delete", "businesscustomer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "4f3fd1bf-86a7-4bdc-9a8d-865d12e54b86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer",
                column: "ConcurrencyStamp",
                value: "f2c4eb57-c988-415d-afe9-67e69984a1ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer",
                column: "ConcurrencyStamp",
                value: "c39b4cde-4c80-48fd-bbe4-c274bccef158");

            migrationBuilder.InsertData(
                table: "TechnicianTasks",
                columns: new[] { "TechnicianTaskId", "Description", "Status", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 3, "Inspect wiring in server room for damage.", "Pending", 1, "Check Wiring" },
                    { 4, "Replace faulty light fixture in lobby.", "In Progress", 3, "Repair Light Fixture" },
                    { 5, "Ensure all emergency lighting is operational.", "Completed", 2, "Test Emergency Lighting" },
                    { 6, "Upgrade the electrical panel to handle increased load.", "Pending", 3, "Upgrade Electrical Panel" },
                    { 7, "Check HVAC system for electrical issues.", "In Progress", 1, "Inspect HVAC System" }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Availability", "Name", "Specialization" },
                values: new object[,]
                {
                    { 4, "Available", "John Doe", "Electrical" },
                    { 5, "Busy", "Jane Smith", "HVAC" },
                    { 6, "Available", "Robert Johnson", "Plumbing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2074567936);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1866112300);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1132104613);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1004053481);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -431592150);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -131178485);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 128982535);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 283993166);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 424183648);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 778124974);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1600726977);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1969426215);

            migrationBuilder.DeleteData(
                table: "TechnicianTasks",
                keyColumn: "TechnicianTaskId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TechnicianTasks",
                keyColumn: "TechnicianTaskId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TechnicianTasks",
                keyColumn: "TechnicianTaskId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TechnicianTasks",
                keyColumn: "TechnicianTaskId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TechnicianTasks",
                keyColumn: "TechnicianTaskId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "TechnicianId",
                keyValue: 6);

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
        }
    }
}
