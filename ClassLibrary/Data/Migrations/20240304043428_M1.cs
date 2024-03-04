using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClassLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Mobile = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Make = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: true),
                    VehicleType = table.Column<string>(type: "TEXT", nullable: true),
                    MemberId = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicle_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Time = table.Column<TimeOnly>(type: "TEXT", nullable: true),
                    DestinationAddress = table.Column<string>(type: "TEXT", nullable: true),
                    MeetingAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => new { x.TripId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_Trip_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manifest",
                columns: table => new
                {
                    ManifestId = table.Column<int>(type: "INTEGER", nullable: false),
                    MemberId = table.Column<string>(type: "TEXT", nullable: false),
                    TripId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifest", x => new { x.ManifestId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_Manifest_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manifest_Trip_TripId_VehicleId",
                        columns: x => new { x.TripId, x.VehicleId },
                        principalTable: "Trip",
                        principalColumns: new[] { "TripId", "VehicleId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manifest_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "Created", "CreatedBy", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Mobile", "Modified", "ModifiedBy", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "14424a4c-b48c-47ca-99f2-d6c0601dec2c", 0, null, "e2644847-9fc0-4056-af8e-5476c2ecaf75", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "c@c.c", true, "Test", "Owner", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C@C.C", "C@C.C", "AQAAAAIAAYagAAAAENLj3GWn3ysyxJnjbLyX+ztaG1ZBR76+8c4QZ1zcBzerEzIWl04TBe/LT8J0+FEycw==", null, false, null, "df080fdf-4789-447d-ac21-8a470e98a7a9", null, false, "c@c.c" },
                    { "f7f77300-444d-459d-abd5-740ac20c885d", 0, null, "925e47ad-8c1d-4308-b3fd-bff387d564b7", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "b@b.b", true, "Test", "User1", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B@B.B", "B@B.B", "AQAAAAIAAYagAAAAEJ4sHiGdiJ7M+ehitwf2V0e6vxtyfkGUYSO7aoM54lZLla7a31Gj/QJkKG6b44lxpw==", null, false, null, "72f74bf2-01f8-476c-b1f2-7e790db8a89a", null, false, "b@b.b" },
                    { "f9626b59-93cd-42f9-bb65-f3d7e752108b", 0, null, "161a534f-560f-425e-a141-1d9e9011fbaa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "d@d.d", true, "Test", "Passenger", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D@D.D", "D@D.D", "AQAAAAIAAYagAAAAEGhgSNE6nXxJbDJyketY5j4qBLpl45G2q85sF1u6iht8jEQ1bPxpI/hRKyf9Eayheg==", null, false, null, "63116cb3-fa6f-4f44-a044-f758ff17fbd6", null, false, "d@d.d" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "Created", "CreatedBy", "Id", "Make", "MemberId", "Model", "Modified", "ModifiedBy", "NumberOfSeats", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7190), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", null, "Tesla", "14424a4c-b48c-47ca-99f2-d6c0601dec2c", "Model 3", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7253), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", 5, "Electric", 2021 },
                    { 2, new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7258), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", null, "Tesla", "14424a4c-b48c-47ca-99f2-d6c0601dec2c", "Model S", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7259), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", 5, "Electric", 2021 },
                    { 3, new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7262), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", null, "Tesla", "14424a4c-b48c-47ca-99f2-d6c0601dec2c", "Model X", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7263), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", 5, "Electric", 2021 }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "TripId", "VehicleId", "Created", "CreatedBy", "Date", "DestinationAddress", "MeetingAddress", "Modified", "ModifiedBy", "Time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7380), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new DateOnly(2021, 12, 25), "123 Main St, Anytown, USA", "456 Elm St, Anytown, USA", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7382), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new TimeOnly(12, 0, 0) },
                    { 2, 2, new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7387), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new DateOnly(2022, 1, 12), "321 Knight St, Anytown, USA", "789 Cambie St, Anytown, USA", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7388), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new TimeOnly(14, 30, 0) },
                    { 3, 3, new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7391), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new DateOnly(2022, 1, 24), "8 Moody St, Anyville, USA", "99 Hastings St, Anytown, USA", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7392), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new TimeOnly(8, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Manifest",
                columns: new[] { "ManifestId", "MemberId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Notes", "TripId", "VehicleId" },
                values: new object[,]
                {
                    { 1, "f9626b59-93cd-42f9-bb65-f3d7e752108b", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7428), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7429), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", "I'm driving", 1, 1 },
                    { 2, "f7f77300-444d-459d-abd5-740ac20c885d", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7433), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7434), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", "I'm driving", 2, 2 },
                    { 3, "f9626b59-93cd-42f9-bb65-f3d7e752108b", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7436), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", new DateTime(2024, 3, 3, 20, 34, 27, 703, DateTimeKind.Local).AddTicks(7438), "14424a4c-b48c-47ca-99f2-d6c0601dec2c", "I'm driving", 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_MemberId",
                table: "Manifest",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_TripId_VehicleId",
                table: "Manifest",
                columns: new[] { "TripId", "VehicleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_VehicleId",
                table: "Manifest",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_VehicleId",
                table: "Trip",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Id",
                table: "Vehicle",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Manifest");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
