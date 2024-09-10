using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support_System.Migrations
{
    /// <inheritdoc />
    public partial class AddTechnicianEntitis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TechnicianTasksDb",
                columns: table => new
                {
                    TechnicianTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianTasksDb", x => x.TechnicianTaskId);
                    table.ForeignKey(
                        name: "FK_TechnicianTasksDb_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicianProjectsDBset",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianProjectsDBset", x => new { x.ProjectId, x.TechnicianId });
                    table.ForeignKey(
                        name: "FK_TechnicianProjectsDBset_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicianProjectsDBset_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -1978668109, "permission", "delete", "individualcustomer" },
                    { -1696538370, "permission", "update", "businesscustomer" },
                    { -1484337071, "permission", "update", "admin" },
                    { -1279780953, "permission", "read", "businesscustomer" },
                    { -1196254373, "permission", "update", "individualcustomer" },
                    { -535965236, "permission", "delete", "businesscustomer" },
                    { -253033343, "permission", "create", "admin" },
                    { 990450268, "permission", "create", "businesscustomer" },
                    { 1070533899, "permission", "read", "admin" },
                    { 1108134684, "permission", "delete", "admin" },
                    { 1517415356, "permission", "create", "individualcustomer" },
                    { 1864683447, "permission", "read", "individualcustomer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "0d74c39a-c388-49cc-b157-1842d1088980");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer",
                column: "ConcurrencyStamp",
                value: "ef7af166-7467-40ee-8635-2cdaa2d9c419");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer",
                column: "ConcurrencyStamp",
                value: "8e31fa9a-429e-4dd9-8b53-00fdce63d33e");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianProjectsDBset_TechnicianId",
                table: "TechnicianProjectsDBset",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianTasksDb_TechnicianId",
                table: "TechnicianTasksDb",
                column: "TechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicianProjectsDBset");

            migrationBuilder.DropTable(
                name: "TechnicianTasksDb");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1978668109);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1696538370);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1484337071);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1279780953);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1196254373);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -535965236);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -253033343);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 990450268);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1070533899);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1108134684);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1517415356);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1864683447);

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
    }
}
