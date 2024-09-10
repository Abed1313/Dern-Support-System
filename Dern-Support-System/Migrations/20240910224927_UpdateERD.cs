using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support_System.Migrations
{
    /// <inheritdoc />
    public partial class UpdateERD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianTasksDb_Technicians_TechnicianId",
                table: "TechnicianTasksDb");

            migrationBuilder.DropTable(
                name: "TechnicianProjectsDBset");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicianTasksDb",
                table: "TechnicianTasksDb");

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

            migrationBuilder.RenameTable(
                name: "TechnicianTasksDb",
                newName: "TechnicianTasks");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicianTasksDb_TechnicianId",
                table: "TechnicianTasks",
                newName: "IX_TechnicianTasks_TechnicianId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicianTasks",
                table: "TechnicianTasks",
                column: "TechnicianTaskId");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -1938540842, "permission", "create", "admin" },
                    { -1198639488, "permission", "read", "admin" },
                    { -649221411, "permission", "update", "admin" },
                    { -543687501, "permission", "create", "individualcustomer" },
                    { -181544890, "permission", "update", "businesscustomer" },
                    { -117530624, "permission", "delete", "admin" },
                    { -72128960, "permission", "delete", "businesscustomer" },
                    { 591643858, "permission", "delete", "individualcustomer" },
                    { 962905653, "permission", "create", "businesscustomer" },
                    { 1168280259, "permission", "read", "individualcustomer" },
                    { 1648588795, "permission", "read", "businesscustomer" },
                    { 2004112610, "permission", "update", "individualcustomer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "df0d375c-e441-4c4c-ba10-ea93d9068957");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer",
                column: "ConcurrencyStamp",
                value: "bf7d4489-f9f0-4a08-8990-8693b6331a6a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer",
                column: "ConcurrencyStamp",
                value: "8f9c0c64-ff19-49a0-afa8-543fdc92deeb");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianTasks_Technicians_TechnicianId",
                table: "TechnicianTasks",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "TechnicianId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianTasks_Technicians_TechnicianId",
                table: "TechnicianTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicianTasks",
                table: "TechnicianTasks");

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1938540842);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1198639488);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -649221411);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -543687501);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -181544890);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -117530624);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -72128960);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 591643858);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 962905653);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1168280259);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1648588795);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2004112610);

            migrationBuilder.RenameTable(
                name: "TechnicianTasks",
                newName: "TechnicianTasksDb");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicianTasks_TechnicianId",
                table: "TechnicianTasksDb",
                newName: "IX_TechnicianTasksDb_TechnicianId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicianTasksDb",
                table: "TechnicianTasksDb",
                column: "TechnicianTaskId");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TechnicianProjectsDBset",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianTasksDb_Technicians_TechnicianId",
                table: "TechnicianTasksDb",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "TechnicianId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
