using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sas.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationDescriptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ConfigDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceFaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFaults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceFaults_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HubConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DetectedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HubConfigurations_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "CreatedAt", "Subscription", "TenantID", "TenantName" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(661), "Standard", new Guid("cfdc8429-3806-4914-9057-c5fb371c94cd"), "CloudSphere" },
                    { 101, new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(720), "Standard", new Guid("71c2908a-3074-48a4-bdc4-bac348398487"), "Datastream" },
                    { 102, new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(732), "Premium", new Guid("2bede55d-86a6-4b03-91c6-155e4c30c093"), "Bluewave" },
                    { 103, new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(743), "Premium", new Guid("a0df0f17-e5ad-4bfc-a3bb-2c15b302e3f3"), "AscendTech" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "BatteryStatus", "CreatedAt", "DeviceID", "DeviceName", "LocationDescriptor", "Status", "TenantId" },
                values: new object[,]
                {
                    { 100, "Status1", new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(470), new Guid("164332cc-30ae-4d4d-8297-9c6d056ebdad"), "Curo 2 staff Fob", "Device Descriptor 1", "Live", 100 },
                    { 101, "Status2", new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(488), new Guid("348477a4-9933-42c1-9cc0-4deca317c62c"), "Curo 2 Nurse Fob", "Device Descriptor 2", "Live", 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_AlertType_Id",
                table: "Alerts",
                columns: new[] { "AlertType", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_DeviceId",
                table: "Alerts",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceFaults_DeviceId",
                table: "DeviceFaults",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceFaults_UpdatedAt_Id",
                table: "DeviceFaults",
                columns: new[] { "UpdatedAt", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_TenantId_DeviceID_Id",
                table: "Devices",
                columns: new[] { "TenantId", "DeviceID", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_DeviceId",
                table: "Events",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventType_Id",
                table: "Events",
                columns: new[] { "EventType", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_HubConfigurations_DeviceId",
                table: "HubConfigurations",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_HubConfigurations_ResolvedAt_Id",
                table: "HubConfigurations",
                columns: new[] { "ResolvedAt", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantName_Id",
                table: "Tenants",
                columns: new[] { "TenantName", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastName_FirstName_Email",
                table: "Users",
                columns: new[] { "LastName", "FirstName", "Email" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "DeviceFaults");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "HubConfigurations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
