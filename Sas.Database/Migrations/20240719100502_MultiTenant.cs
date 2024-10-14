using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sas.Database.Migrations
{
    /// <inheritdoc />
    public partial class MultiTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tenants_TenantName_Id",
                table: "Tenants");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 19, 10, 5, 0, 847, DateTimeKind.Utc).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 19, 10, 5, 0, 847, DateTimeKind.Utc).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "TenantID" },
                values: new object[] { new DateTime(2024, 7, 19, 10, 5, 0, 847, DateTimeKind.Utc).AddTicks(650), new Guid("4381f40a-52b3-4ff6-9fe4-37552a158bcc") });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "TenantID" },
                values: new object[] { new DateTime(2024, 7, 19, 10, 5, 0, 847, DateTimeKind.Utc).AddTicks(708), new Guid("5b374cfc-de75-4b6b-b1d2-cb924edc98e0") });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "TenantID" },
                values: new object[] { new DateTime(2024, 7, 19, 10, 5, 0, 847, DateTimeKind.Utc).AddTicks(720), new Guid("a8dde5ad-ab64-4c40-910a-d9f86064fcd8") });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "TenantID" },
                values: new object[] { new DateTime(2024, 7, 19, 10, 5, 0, 847, DateTimeKind.Utc).AddTicks(732), new Guid("04e3c84b-34b1-4557-9143-2f747abe631d") });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantName_Id_TenantID",
                table: "Tenants",
                columns: new[] { "TenantName", "Id", "TenantID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tenants_TenantName_Id_TenantID",
                table: "Tenants");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "TenantID" },
                values: new object[] { new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(661), new Guid("cfdc8429-3806-4914-9057-c5fb371c94cd") });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "TenantID" },
                values: new object[] { new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(720), new Guid("71c2908a-3074-48a4-bdc4-bac348398487") });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "TenantID" },
                values: new object[] { new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(732), new Guid("2bede55d-86a6-4b03-91c6-155e4c30c093") });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "TenantID" },
                values: new object[] { new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(743), new Guid("a0df0f17-e5ad-4bfc-a3bb-2c15b302e3f3") });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantName_Id",
                table: "Tenants",
                columns: new[] { "TenantName", "Id" });
        }
    }
}
