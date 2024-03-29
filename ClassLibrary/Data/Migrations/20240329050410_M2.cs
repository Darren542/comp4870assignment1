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
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57ac0556-65b2-48f4-8605-09445b2f9b50");

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 1, "bde53b31-95bd-4153-a0c1-a71b69515cf7" });

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 2, "d475b154-b2b9-4020-81fe-2291a4071387" });

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 3, "bde53b31-95bd-4153-a0c1-a71b69515cf7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bde53b31-95bd-4153-a0c1-a71b69515cf7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d475b154-b2b9-4020-81fe-2291a4071387");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "Created", "CreatedBy", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Mobile", "Modified", "ModifiedBy", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2e6f7f27-c3d8-455d-bf8b-a69a38d1dfb8", 0, null, "b61571ea-f8a5-4877-8877-d010b7877f4c", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "d@d.d", true, "Test", "Passenger", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D@D.D", "D@D.D", "AQAAAAIAAYagAAAAEDI/PeodylQZ2FDDgVglNlkfSPAqI9RVJOpUtM8y7N8XAR9248T9MtOaPqzdSSppHw==", null, false, null, "fab5bb19-42aa-404c-b24f-b47db8b47855", null, false, "d@d.d" },
                    { "f348b447-7942-445a-85ad-22c3853643ec", 0, null, "504892c3-270b-45b3-baad-6accfa75c64a", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "b@b.b", true, "Test", "User1", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B@B.B", "B@B.B", "AQAAAAIAAYagAAAAEO8N/s6rekNVPeuDzkzvqbuZcjDzpUL9f5ha/VHWxcAc3MbIqF6fIhjgYDtUnv4SGA==", null, false, null, "3064ae3c-6d4a-479b-9321-1b76e7ee3723", null, false, "b@b.b" },
                    { "feaf4c36-6f0a-4354-85f6-da8b3e881502", 0, null, "52f2e3c5-0dfc-4a18-be81-8325ed000ff0", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "c@c.c", true, "Test", "Owner", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C@C.C", "C@C.C", "AQAAAAIAAYagAAAAEF7BbOTL0tW8Yi3i6b0TntAVSspPAajQbCZudNEBAf87PM276MS0qTUHJWdapFtI1w==", null, false, null, "eec16ab4-47fe-4516-b7a3-5c6b99632709", null, false, "c@c.c" }
                });

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "TripId",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2745), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2748), "feaf4c36-6f0a-4354-85f6-da8b3e881502" });

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "TripId",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2752), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2754), "feaf4c36-6f0a-4354-85f6-da8b3e881502" });

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "TripId",
                keyValue: 3,
                columns: new[] { "Created", "CreatedBy", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2759), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2760), "feaf4c36-6f0a-4354-85f6-da8b3e881502" });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "TripId", "Created", "CreatedBy", "Date", "DestinationAddress", "MeetingAddress", "Modified", "ModifiedBy", "Time", "VehicleId" },
                values: new object[] { 4, new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2765), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateOnly(2022, 4, 13), "8 Moody St, Anyville, USA", "99 Hastings St, Anytown, USA", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2766), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new TimeOnly(8, 0, 0), 3 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy", "MemberId", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2559), "feaf4c36-6f0a-4354-85f6-da8b3e881502", "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2616), "feaf4c36-6f0a-4354-85f6-da8b3e881502" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "MemberId", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2622), "feaf4c36-6f0a-4354-85f6-da8b3e881502", "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2624), "feaf4c36-6f0a-4354-85f6-da8b3e881502" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "Created", "CreatedBy", "MemberId", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2627), "feaf4c36-6f0a-4354-85f6-da8b3e881502", "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2677), "feaf4c36-6f0a-4354-85f6-da8b3e881502" });

            migrationBuilder.InsertData(
                table: "Manifest",
                columns: new[] { "ManifestId", "MemberId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Notes", "Rating", "TripId" },
                values: new object[,]
                {
                    { 1, "2e6f7f27-c3d8-455d-bf8b-a69a38d1dfb8", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2818), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2827), "feaf4c36-6f0a-4354-85f6-da8b3e881502", "I'm driving", null, 1 },
                    { 2, "f348b447-7942-445a-85ad-22c3853643ec", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2831), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2833), "feaf4c36-6f0a-4354-85f6-da8b3e881502", "I'm driving", null, 2 },
                    { 3, "2e6f7f27-c3d8-455d-bf8b-a69a38d1dfb8", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2836), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2837), "feaf4c36-6f0a-4354-85f6-da8b3e881502", "I'm driving", null, 3 },
                    { 4, "2e6f7f27-c3d8-455d-bf8b-a69a38d1dfb8", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2840), "feaf4c36-6f0a-4354-85f6-da8b3e881502", new DateTime(2024, 3, 28, 22, 4, 10, 94, DateTimeKind.Local).AddTicks(2841), "feaf4c36-6f0a-4354-85f6-da8b3e881502", "I'm driving", null, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "feaf4c36-6f0a-4354-85f6-da8b3e881502");

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 1, "2e6f7f27-c3d8-455d-bf8b-a69a38d1dfb8" });

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 2, "f348b447-7942-445a-85ad-22c3853643ec" });

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 3, "2e6f7f27-c3d8-455d-bf8b-a69a38d1dfb8" });

            migrationBuilder.DeleteData(
                table: "Manifest",
                keyColumns: new[] { "ManifestId", "MemberId" },
                keyValues: new object[] { 4, "2e6f7f27-c3d8-455d-bf8b-a69a38d1dfb8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e6f7f27-c3d8-455d-bf8b-a69a38d1dfb8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f348b447-7942-445a-85ad-22c3853643ec");

            migrationBuilder.DeleteData(
                table: "Trip",
                keyColumn: "TripId",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "Created", "CreatedBy", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Mobile", "Modified", "ModifiedBy", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "57ac0556-65b2-48f4-8605-09445b2f9b50", 0, null, "577a69f6-2518-4da8-881f-83ecd032debe", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "c@c.c", true, "Test", "Owner", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C@C.C", "C@C.C", "AQAAAAIAAYagAAAAEOHIbbXZaj3wGU1E/1CjfHOrHbgfAI1tVsbJDbsscMZ4usBLbZk6jflVrB8Cr79BtQ==", null, false, null, "a3a62ca0-1937-43e8-b651-b3ebdf96ee6c", null, false, "c@c.c" },
                    { "bde53b31-95bd-4153-a0c1-a71b69515cf7", 0, null, "f80364aa-f17c-4bcb-9648-3bc0adf1e74c", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "d@d.d", true, "Test", "Passenger", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D@D.D", "D@D.D", "AQAAAAIAAYagAAAAECMUysY2mMlyIlxSB44/j0yU9pNi3RIE74xsMJtdg6wiyLrffQYHDwyoShRLpN3uCw==", null, false, null, "643efe03-6e51-40a3-90d5-c5586b31eb18", null, false, "d@d.d" },
                    { "d475b154-b2b9-4020-81fe-2291a4071387", 0, null, "bec9c47c-4f44-45b8-befa-1ded177edb3b", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "b@b.b", true, "Test", "User1", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B@B.B", "B@B.B", "AQAAAAIAAYagAAAAEAg7lBNhGX7kA+v7gEQ/rbBGPh3ZL7GS96zbz+2LT3oG2M6daET6QTL14JLBbcq76Q==", null, false, null, "d8c9a347-af66-4d5e-b68d-186e1e2c3414", null, false, "b@b.b" }
                });

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "TripId",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4544), "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4545), "57ac0556-65b2-48f4-8605-09445b2f9b50" });

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "TripId",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4550), "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4551), "57ac0556-65b2-48f4-8605-09445b2f9b50" });

            migrationBuilder.UpdateData(
                table: "Trip",
                keyColumn: "TripId",
                keyValue: 3,
                columns: new[] { "Created", "CreatedBy", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4555), "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4556), "57ac0556-65b2-48f4-8605-09445b2f9b50" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy", "MemberId", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4396), "57ac0556-65b2-48f4-8605-09445b2f9b50", "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4471), "57ac0556-65b2-48f4-8605-09445b2f9b50" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "MemberId", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4478), "57ac0556-65b2-48f4-8605-09445b2f9b50", "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4479), "57ac0556-65b2-48f4-8605-09445b2f9b50" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "Created", "CreatedBy", "MemberId", "Modified", "ModifiedBy" },
                values: new object[] { new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4482), "57ac0556-65b2-48f4-8605-09445b2f9b50", "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4484), "57ac0556-65b2-48f4-8605-09445b2f9b50" });

            migrationBuilder.InsertData(
                table: "Manifest",
                columns: new[] { "ManifestId", "MemberId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Notes", "Rating", "TripId" },
                values: new object[,]
                {
                    { 1, "bde53b31-95bd-4153-a0c1-a71b69515cf7", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4594), "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4596), "57ac0556-65b2-48f4-8605-09445b2f9b50", "I'm driving", null, 1 },
                    { 2, "d475b154-b2b9-4020-81fe-2291a4071387", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4617), "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4618), "57ac0556-65b2-48f4-8605-09445b2f9b50", "I'm driving", null, 2 },
                    { 3, "bde53b31-95bd-4153-a0c1-a71b69515cf7", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4620), "57ac0556-65b2-48f4-8605-09445b2f9b50", new DateTime(2024, 3, 28, 21, 9, 10, 693, DateTimeKind.Local).AddTicks(4622), "57ac0556-65b2-48f4-8605-09445b2f9b50", "I'm driving", null, 3 }
                });
        }
    }
}
