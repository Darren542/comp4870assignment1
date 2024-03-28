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
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
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
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Make = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: true),
                    VehicleType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MemberId = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicle_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    table.PrimaryKey("PK_Trip", x => x.TripId);
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
                        name: "FK_Manifest_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "Created", "CreatedBy", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Mobile", "Modified", "ModifiedBy", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7b11e753-3505-4d3a-bc04-481e9d61d80c", 0, null, "46abad4c-5205-482d-b61c-4e4d6be8104b", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "d@d.d", true, "Test", "Passenger", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D@D.D", "D@D.D", "AQAAAAIAAYagAAAAEBWjBIIOmSU+FnWbrDV69NEk5pqYPCfmuV6wuUUwQZK8vwwxRxTWaqt+sDWrnU2nYQ==", null, false, null, "cca7b61c-d068-42d8-93b6-d658a3276a4d", null, false, "d@d.d" },
                    { "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", 0, null, "607c273a-1187-41d4-a0aa-830919a582a4", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "c@c.c", true, "Test", "Owner", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C@C.C", "C@C.C", "AQAAAAIAAYagAAAAENd6zaSmrpgphUX+dqBfVplqAcDzl8dwaivUmViz3vlSIP0r55ytk8Z/VUSOubmMyQ==", null, false, null, "78209a1b-352d-437d-967f-6193e20cf904", null, false, "c@c.c" },
                    { "f1117577-f11c-4b13-bec0-c66a5d0eb46c", 0, null, "34db438c-5290-4ca2-8770-f22ff1a14301", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "b@b.b", true, "Test", "User1", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B@B.B", "B@B.B", "AQAAAAIAAYagAAAAENGljqXuEdBCa7q41I75scTzt/AwDBi8Vo/ToeVOoK67L0D6btyzvCBQyiWGcWwXvA==", null, false, null, "d68af4d8-f533-4864-a629-8a0853abc5f1", null, false, "b@b.b" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "Created", "CreatedBy", "Make", "MemberId", "Model", "Modified", "ModifiedBy", "NumberOfSeats", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7145), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "Tesla", "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "Model 3", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7222), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", 5, "Electric", 2021 },
                    { 2, new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7229), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "Tesla", "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "Model S", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7231), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", 5, "Electric", 2021 },
                    { 3, new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7237), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "Tesla", "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "Model X", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7292), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", 5, "Electric", 2021 }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "TripId", "Created", "CreatedBy", "Date", "DestinationAddress", "MeetingAddress", "Modified", "ModifiedBy", "Time", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7396), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new DateOnly(2021, 12, 25), "123 Main St, Anytown, USA", "456 Elm St, Anytown, USA", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7399), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new TimeOnly(12, 0, 0), 1 },
                    { 2, new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7406), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new DateOnly(2022, 1, 12), "321 Knight St, Anytown, USA", "789 Cambie St, Anytown, USA", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7408), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new TimeOnly(14, 30, 0), 2 },
                    { 3, new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7416), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new DateOnly(2022, 1, 24), "8 Moody St, Anyville, USA", "99 Hastings St, Anytown, USA", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7418), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new TimeOnly(8, 0, 0), 3 }
                });

            migrationBuilder.InsertData(
                table: "Manifest",
                columns: new[] { "ManifestId", "MemberId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Notes", "TripId" },
                values: new object[,]
                {
                    { 1, "7b11e753-3505-4d3a-bc04-481e9d61d80c", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7471), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7474), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "I'm driving", 1 },
                    { 2, "f1117577-f11c-4b13-bec0-c66a5d0eb46c", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7485), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7501), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "I'm driving", 2 },
                    { 3, "7b11e753-3505-4d3a-bc04-481e9d61d80c", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7504), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", new DateTime(2024, 3, 28, 16, 9, 53, 65, DateTimeKind.Local).AddTicks(7506), "c9b4b12a-5470-409b-acfd-550e3a3ab2a5", "I'm driving", 3 }
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
                name: "IX_Manifest_TripId",
                table: "Manifest",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_VehicleId",
                table: "Trip",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MemberId",
                table: "Vehicle",
                column: "MemberId");
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
