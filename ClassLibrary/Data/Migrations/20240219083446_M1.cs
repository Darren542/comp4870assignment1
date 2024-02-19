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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "228081ac-b597-42fd-9909-9a2f37992cb0", null, "Passenger", null },
                    { "22b02731-259f-460f-8e92-c94e66bde416", null, "Owner", null },
                    { "d0d149e5-2fb5-474a-9436-6d39ad5383a5", null, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "Created", "CreatedBy", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Mobile", "Modified", "ModifiedBy", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "64668c71-5ca2-4c85-b355-ceefb5c43fbb", 0, null, "7ef46936-2955-443b-a103-598b6d327541", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "p@p.p", true, "Passenger", "User", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "P@P.P", "P@P.P", "AQAAAAIAAYagAAAAEMkJc2J8cJUPMNa4ovhc79JLFYZqDWhVyl2+UEMqss0xuxAGyMqIqkdJLwiB/yHTwA==", null, false, null, "e314db29-1475-4818-8920-17c7be8b3cbe", null, false, "p@p.p" },
                    { "701887f9-de31-4dee-ae86-4b05cf2624cd", 0, null, "79d53100-238a-4302-85f0-9e2271fd5b1d", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "o@o.o", true, "Owner", "User", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "O@O.O", "O@O.O", "AQAAAAIAAYagAAAAENB2LFoITz3FcCiK+qKePKLXOJbxv7HW36c/7km3Ha+15t1bDBb+ZfG/CgExsl9Lsg==", null, false, null, "d9e7ac24-ab0e-4134-9800-4f62d6a6ffae", null, false, "o@o.o" },
                    { "f6d8010d-7af6-4d37-9dc8-f6c3f087527a", 0, null, "9be9aca7-ea17-4305-af37-441e2491ba04", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "a@a.a", true, "Admin", "User", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A@A.A", "A@A.A", "AQAAAAIAAYagAAAAEEtydD5EWcxOPblfGSFNjztELOOmhCzpPoZNWhTqf6mguEcnNO4mjmwIKykWXOV61A==", null, false, null, "e523cd9d-ae12-4bfb-bd74-efe0b042a611", null, false, "a@a.a" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "Created", "CreatedBy", "Id", "Make", "MemberId", "Model", "Modified", "ModifiedBy", "NumberOfSeats", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(7886), "701887f9-de31-4dee-ae86-4b05cf2624cd", null, "Tesla", "701887f9-de31-4dee-ae86-4b05cf2624cd", "Model 3", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(7954), "701887f9-de31-4dee-ae86-4b05cf2624cd", 5, "Electric", 2021 },
                    { 2, new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(7961), "701887f9-de31-4dee-ae86-4b05cf2624cd", null, "Tesla", "701887f9-de31-4dee-ae86-4b05cf2624cd", "Model S", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(7962), "701887f9-de31-4dee-ae86-4b05cf2624cd", 5, "Electric", 2021 },
                    { 3, new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(7979), "701887f9-de31-4dee-ae86-4b05cf2624cd", null, "Tesla", "701887f9-de31-4dee-ae86-4b05cf2624cd", "Model X", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(7980), "701887f9-de31-4dee-ae86-4b05cf2624cd", 5, "Electric", 2021 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "228081ac-b597-42fd-9909-9a2f37992cb0", "64668c71-5ca2-4c85-b355-ceefb5c43fbb" },
                    { "22b02731-259f-460f-8e92-c94e66bde416", "701887f9-de31-4dee-ae86-4b05cf2624cd" },
                    { "d0d149e5-2fb5-474a-9436-6d39ad5383a5", "f6d8010d-7af6-4d37-9dc8-f6c3f087527a" }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "TripId", "VehicleId", "Created", "CreatedBy", "Date", "DestinationAddress", "MeetingAddress", "Modified", "ModifiedBy", "Time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8051), "701887f9-de31-4dee-ae86-4b05cf2624cd", new DateOnly(2021, 12, 25), "123 Main St, Anytown, USA", "456 Elm St, Anytown, USA", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8053), "701887f9-de31-4dee-ae86-4b05cf2624cd", new TimeOnly(12, 0, 0) },
                    { 2, 2, new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8064), "701887f9-de31-4dee-ae86-4b05cf2624cd", new DateOnly(2022, 1, 12), "321 Knight St, Anytown, USA", "789 Cambie St, Anytown, USA", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8065), "701887f9-de31-4dee-ae86-4b05cf2624cd", new TimeOnly(14, 30, 0) },
                    { 3, 3, new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8078), "701887f9-de31-4dee-ae86-4b05cf2624cd", new DateOnly(2022, 1, 24), "8 Moody St, Anyville, USA", "99 Hastings St, Anytown, USA", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8079), "701887f9-de31-4dee-ae86-4b05cf2624cd", new TimeOnly(8, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Manifest",
                columns: new[] { "ManifestId", "MemberId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Notes", "TripId", "VehicleId" },
                values: new object[,]
                {
                    { 1, "64668c71-5ca2-4c85-b355-ceefb5c43fbb", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8130), "701887f9-de31-4dee-ae86-4b05cf2624cd", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8132), "701887f9-de31-4dee-ae86-4b05cf2624cd", "I'm driving", 1, 1 },
                    { 2, "f6d8010d-7af6-4d37-9dc8-f6c3f087527a", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8136), "701887f9-de31-4dee-ae86-4b05cf2624cd", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8159), "701887f9-de31-4dee-ae86-4b05cf2624cd", "I'm driving", 2, 2 },
                    { 3, "64668c71-5ca2-4c85-b355-ceefb5c43fbb", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8162), "701887f9-de31-4dee-ae86-4b05cf2624cd", new DateTime(2024, 2, 19, 0, 34, 46, 572, DateTimeKind.Local).AddTicks(8163), "701887f9-de31-4dee-ae86-4b05cf2624cd", "I'm driving", 3, 3 }
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
