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
                        name: "FK_Manifest_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "TripId",
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
                    { "38467ff4-a217-464a-86af-3765d2e6d72c", 0, null, "08f05c04-bccf-484b-9104-907fa662d9f0", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "c@c.c", true, "Test", "Owner", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C@C.C", "C@C.C", "AQAAAAIAAYagAAAAEFaOPyon8ykAVZqcnF3TVGStN+ZYgwRARKgSJhOlBMVA2WkKNnx3CMn9kmBQmXjJTg==", null, false, null, "c74b6e7c-82b3-46af-bc4a-efef8d304346", null, false, "c@c.c" },
                    { "70f4fe06-afca-4127-b286-448d03877729", 0, null, "7d7e3ae7-dfa0-4487-aad8-ae5c7b1a9194", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "b@b.b", true, "Test", "User1", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B@B.B", "B@B.B", "AQAAAAIAAYagAAAAELRNoWCNpPaTEZbTWZgPEd3rFetOY1L3Bra9NNZWtHJ1wnjrVhx/nd0eprnk7J2jzA==", null, false, null, "e79d0e38-4735-4650-83b8-a842f19a86a1", null, false, "b@b.b" },
                    { "7770387e-54f5-40c7-bb7d-aa3d1d3d282f", 0, null, "8602a4cd-72ed-48ef-8d7c-1eb505974ac4", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "d@d.d", true, "Test", "Passenger", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D@D.D", "D@D.D", "AQAAAAIAAYagAAAAELExioDXeC3Njw60ockzI3K5/qzKsj2NepMuVW9T4im0e9CIwbA0wKbMmFYtMcceVg==", null, false, null, "217c4469-9a2d-4a54-9295-66512c1aecd7", null, false, "d@d.d" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "Created", "CreatedBy", "Id", "Make", "MemberId", "Model", "Modified", "ModifiedBy", "NumberOfSeats", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4344), "38467ff4-a217-464a-86af-3765d2e6d72c", null, "Tesla", "38467ff4-a217-464a-86af-3765d2e6d72c", "Model 3", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4598), "38467ff4-a217-464a-86af-3765d2e6d72c", 5, "Electric", 2021 },
                    { 2, new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4603), "38467ff4-a217-464a-86af-3765d2e6d72c", null, "Tesla", "38467ff4-a217-464a-86af-3765d2e6d72c", "Model S", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4605), "38467ff4-a217-464a-86af-3765d2e6d72c", 5, "Electric", 2021 },
                    { 3, new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4607), "38467ff4-a217-464a-86af-3765d2e6d72c", null, "Tesla", "38467ff4-a217-464a-86af-3765d2e6d72c", "Model X", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4609), "38467ff4-a217-464a-86af-3765d2e6d72c", 5, "Electric", 2021 }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "TripId", "Created", "CreatedBy", "Date", "DestinationAddress", "MeetingAddress", "Modified", "ModifiedBy", "Time", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4775), "38467ff4-a217-464a-86af-3765d2e6d72c", new DateOnly(2021, 12, 25), "123 Main St, Anytown, USA", "456 Elm St, Anytown, USA", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4777), "38467ff4-a217-464a-86af-3765d2e6d72c", new TimeOnly(12, 0, 0), 1 },
                    { 2, new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4782), "38467ff4-a217-464a-86af-3765d2e6d72c", new DateOnly(2022, 1, 12), "321 Knight St, Anytown, USA", "789 Cambie St, Anytown, USA", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4784), "38467ff4-a217-464a-86af-3765d2e6d72c", new TimeOnly(14, 30, 0), 2 },
                    { 3, new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4787), "38467ff4-a217-464a-86af-3765d2e6d72c", new DateOnly(2022, 1, 24), "8 Moody St, Anyville, USA", "99 Hastings St, Anytown, USA", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4788), "38467ff4-a217-464a-86af-3765d2e6d72c", new TimeOnly(8, 0, 0), 3 }
                });

            migrationBuilder.InsertData(
                table: "Manifest",
                columns: new[] { "ManifestId", "MemberId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Notes", "TripId", "VehicleId" },
                values: new object[,]
                {
                    { 1, "7770387e-54f5-40c7-bb7d-aa3d1d3d282f", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4822), "38467ff4-a217-464a-86af-3765d2e6d72c", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4825), "38467ff4-a217-464a-86af-3765d2e6d72c", "I'm driving", 1, 1 },
                    { 2, "70f4fe06-afca-4127-b286-448d03877729", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4828), "38467ff4-a217-464a-86af-3765d2e6d72c", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4829), "38467ff4-a217-464a-86af-3765d2e6d72c", "I'm driving", 2, 2 },
                    { 3, "7770387e-54f5-40c7-bb7d-aa3d1d3d282f", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4832), "38467ff4-a217-464a-86af-3765d2e6d72c", new DateTime(2024, 3, 25, 22, 39, 32, 840, DateTimeKind.Local).AddTicks(4833), "38467ff4-a217-464a-86af-3765d2e6d72c", "I'm driving", 3, 3 }
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
