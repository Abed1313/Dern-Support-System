using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support_System.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataKnowledgeBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -1870649806, "permission", "create", "admin" },
                    { -1863342208, "permission", "update", "individualcustomer" },
                    { -1862407115, "permission", "delete", "admin" },
                    { -1343740615, "permission", "delete", "individualcustomer" },
                    { -1289150110, "permission", "read", "individualcustomer" },
                    { 467305327, "permission", "update", "businesscustomer" },
                    { 750832786, "permission", "read", "admin" },
                    { 971440829, "permission", "delete", "businesscustomer" },
                    { 1517946740, "permission", "create", "individualcustomer" },
                    { 1642459346, "permission", "read", "businesscustomer" },
                    { 1730885888, "permission", "create", "businesscustomer" },
                    { 2055279588, "permission", "update", "admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "66abc4ff-34ce-4a70-82a6-b07c5b9f7fae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "businesscustomer",
                column: "ConcurrencyStamp",
                value: "4072a0a6-0d0e-4c74-bfc7-e4949d5bf1f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "individualcustomer",
                column: "ConcurrencyStamp",
                value: "dcc451cb-f662-4af2-a47e-2458977af000");

            migrationBuilder.InsertData(
                table: "KnowledgeBases",
                columns: new[] { "KnowledgeBaseId", "HardwareOrSoftware", "ProblemDescription", "SolutionSteps", "Title" },
                values: new object[,]
                {
                    { 1, "Hardware", "The printer is not responding when trying to print.", "1. Check if the printer is powered on.\n2. Ensure the printer is connected to the computer.\n3. Restart the printer and try again.", "Printer Not Working" },
                    { 2, "Software", "Error occurs during the installation of software X.", "1. Ensure that the installation package is not corrupted.\n2. Check for sufficient disk space.\n3. Run the installer as an administrator.", "Software Installation Error" },
                    { 3, "Hardware", "Computer is running slower than usual.", "1. Check for any background programs consuming too many resources.\n2. Run a disk cleanup and defragmentation.\n3. Consider upgrading the RAM if necessary.", "Slow Computer Performance" },
                    { 4, "Software", "Unable to connect to the internet.", "1. Restart the modem and router.\n2. Check if the network cables are properly connected.\n3. Verify the network adapter settings.", "Internet Connectivity Issue" },
                    { 5, "Hardware", "The computer crashes with a blue screen displaying an error message.", "1. Check if any recent hardware changes or driver installations have been made.\n2. Ensure all drivers are up to date.\n3. Run a memory diagnostic test to check for faulty RAM.\n4. Perform a system restore to a previous stable state.", "Blue Screen of Death (BSOD)" },
                    { 6, "Software", "Emails are not syncing in the mail client (e.g., Outlook, Thunderbird).", "1. Check if the internet connection is stable.\n2. Verify email account settings (server details, port numbers, and authentication).\n3. Restart the email client or reboot the device.\n4. Reconfigure the email account if necessary.", "Email Not Syncing" },
                    { 7, "Hardware", "The computer fails to load the operating system during startup.", "1. Check for any loose or disconnected cables inside the computer.\n2. Ensure the boot order is correctly configured in the BIOS.\n3. Use the OS recovery tool to repair the bootloader.\n4. If the issue persists, reinstall the operating system.", "Operating System Won't Boot" },
                    { 8, "Software", "The application crashes unexpectedly when trying to perform a specific action.", "1. Check if the application is up to date with the latest version.\n2. Review the application logs for any error messages or exceptions.\n3. Uninstall and reinstall the application.\n4. If the issue persists, contact the application's support team.", "Application Crashing" },
                    { 9, "Hardware", "The computer is unable to read from or write to the hard drive, and data is inaccessible.", "1. Check if the hard drive is properly connected to the motherboard.\n2. Use disk repair tools (e.g., chkdsk) to scan for bad sectors.\n3. If the hard drive is beyond repair, replace it and restore data from backups.", "Hard Drive Failure" },
                    { 10, "Hardware", "The network printer shows as offline and cannot receive print jobs.", "1. Restart the printer and check if it's properly connected to the network.\n2. Verify the printer's IP address and ensure it's correct in the printer settings.\n3. Remove and re-add the printer on the computer.\n4. Check firewall settings to ensure the printer is not being blocked.", "Network Printer Offline" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1870649806);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1863342208);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1862407115);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1343740615);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1289150110);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 467305327);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 750832786);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 971440829);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1517946740);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1642459346);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1730885888);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2055279588);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "KnowledgeBases",
                keyColumn: "KnowledgeBaseId",
                keyValue: 10);

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
        }
    }
}
