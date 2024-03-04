using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClassLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "Created", "CreatedBy", "Id", "Make", "MemberId", "Model", "Modified", "ModifiedBy", "NumberOfSeats", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5224), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", null, "Tesla", "ffc343dc-373e-42d6-9460-4a8c2c8b8275", "Model 3", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5283), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", 5, "Electric", 2021 },
                    { 2, new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5289), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", null, "Tesla", "ffc343dc-373e-42d6-9460-4a8c2c8b8275", "Model S", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5290), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", 5, "Electric", 2021 },
                    { 3, new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5293), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", null, "Tesla", "ffc343dc-373e-42d6-9460-4a8c2c8b8275", "Model X", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5294), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", 5, "Electric", 2021 }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "TripId", "VehicleId", "Created", "CreatedBy", "Date", "DestinationAddress", "MeetingAddress", "Modified", "ModifiedBy", "Time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5340), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new DateOnly(2021, 12, 25), "123 Main St, Anytown, USA", "456 Elm St, Anytown, USA", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5342), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new TimeOnly(12, 0, 0) },
                    { 2, 2, new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5346), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new DateOnly(2022, 1, 12), "321 Knight St, Anytown, USA", "789 Cambie St, Anytown, USA", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5348), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new TimeOnly(14, 30, 0) },
                    { 3, 3, new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5351), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new DateOnly(2022, 1, 24), "8 Moody St, Anyville, USA", "99 Hastings St, Anytown, USA", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5352), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new TimeOnly(8, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Manifest",
                columns: new[] { "ManifestId", "MemberId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Notes", "TripId", "VehicleId" },
                values: new object[,]
                {
                    { 1, "36204d2a-d455-4eaf-9613-46826bba2a3b", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5381), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5384), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", "I'm driving", 1, 1 },
                    { 2, "f824f67c-1b68-4c00-b8b8-289de93f2d79", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5388), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5389), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", "I'm driving", 2, 2 },
                    { 3, "36204d2a-d455-4eaf-9613-46826bba2a3b", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5392), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", new DateTime(2024, 3, 3, 17, 12, 18, 574, DateTimeKind.Local).AddTicks(5393), "ffc343dc-373e-42d6-9460-4a8c2c8b8275", "I'm driving", 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 1, "36204d2a-d455-4eaf-9613-46826bba2a3b" });

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 2, "f824f67c-1b68-4c00-b8b8-289de93f2d79" });

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 3, "36204d2a-d455-4eaf-9613-46826bba2a3b" });

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumns: new[] { "TripId", "VehicleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumns: new[] { "TripId", "VehicleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumns: new[] { "TripId", "VehicleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 3);
        }
    }
}
