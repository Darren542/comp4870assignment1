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
                    { "6c136e26-2431-4b04-acb7-6d354abe5e8e", 0, null, "14fdb97c-da13-44f8-b752-8b052d5fa4b8", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "d@d.d", true, "Test", "Passenger", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D@D.D", "D@D.D", "AQAAAAIAAYagAAAAEMsZZwM1d545OEz6ZweOoSEmLmBpljFa0OXmRLPo42ms10FTQ0dC2bjMmVMPpFeFIQ==", null, false, null, "680e0775-d00e-48d0-9726-042a296ad4ab", null, false, "d@d.d" },
                    { "b874ec6d-884c-4694-b092-66a03029e8c7", 0, null, "36ce9530-e315-4061-8991-e4d006751d0a", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "c@c.c", true, "Test", "Owner", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C@C.C", "C@C.C", "AQAAAAIAAYagAAAAEFTLVHN7e+7yL2jWoRoi7hsqq81Xf2xp1QUqhDzsG4r0NtB48WNwfWLT3xM+7nafQw==", null, false, null, "0c157a1a-3242-4091-8d94-0a57c5cae89f", null, false, "c@c.c" },
                    { "dbe2cc4b-27c2-44aa-af5d-a4289cefaef3", 0, null, "ab95c4e4-8fb9-499a-ad4e-10425fb3690e", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "b@b.b", true, "Test", "User1", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B@B.B", "B@B.B", "AQAAAAIAAYagAAAAEJA76L/+8NIJvQcHVofMRPjUJ+hhM4kUUkJ0btPrjK33PlGDXpQpQSoq+xWrIrSeIQ==", null, false, null, "76f9d4fc-fe84-4b9a-93eb-b1fbd2c271ad", null, false, "b@b.b" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "Created", "CreatedBy", "Id", "Make", "MemberId", "Model", "Modified", "ModifiedBy", "NumberOfSeats", "VehicleType", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6885), "b874ec6d-884c-4694-b092-66a03029e8c7", null, "Tesla", "b874ec6d-884c-4694-b092-66a03029e8c7", "Model 3", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6966), "b874ec6d-884c-4694-b092-66a03029e8c7", 5, "Electric", 2021 },
                    { 2, new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6982), "b874ec6d-884c-4694-b092-66a03029e8c7", null, "Tesla", "b874ec6d-884c-4694-b092-66a03029e8c7", "Model S", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6985), "b874ec6d-884c-4694-b092-66a03029e8c7", 5, "Electric", 2021 },
                    { 3, new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(6991), "b874ec6d-884c-4694-b092-66a03029e8c7", null, "Tesla", "b874ec6d-884c-4694-b092-66a03029e8c7", "Model X", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7000), "b874ec6d-884c-4694-b092-66a03029e8c7", 5, "Electric", 2021 }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "TripId", "Created", "CreatedBy", "Date", "DestinationAddress", "MeetingAddress", "Modified", "ModifiedBy", "Time", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7117), "b874ec6d-884c-4694-b092-66a03029e8c7", new DateOnly(2021, 12, 25), "123 Main St, Anytown, USA", "456 Elm St, Anytown, USA", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7121), "b874ec6d-884c-4694-b092-66a03029e8c7", new TimeOnly(12, 0, 0), 1 },
                    { 2, new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7136), "b874ec6d-884c-4694-b092-66a03029e8c7", new DateOnly(2022, 1, 12), "321 Knight St, Anytown, USA", "789 Cambie St, Anytown, USA", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7139), "b874ec6d-884c-4694-b092-66a03029e8c7", new TimeOnly(14, 30, 0), 2 },
                    { 3, new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7152), "b874ec6d-884c-4694-b092-66a03029e8c7", new DateOnly(2022, 1, 24), "8 Moody St, Anyville, USA", "99 Hastings St, Anytown, USA", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7155), "b874ec6d-884c-4694-b092-66a03029e8c7", new TimeOnly(8, 0, 0), 3 }
                });

            migrationBuilder.InsertData(
                table: "Manifest",
                columns: new[] { "ManifestId", "MemberId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Notes", "TripId" },
                values: new object[,]
                {
                    { 1, "6c136e26-2431-4b04-acb7-6d354abe5e8e", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7235), "b874ec6d-884c-4694-b092-66a03029e8c7", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7238), "b874ec6d-884c-4694-b092-66a03029e8c7", "I'm driving", 1 },
                    { 2, "dbe2cc4b-27c2-44aa-af5d-a4289cefaef3", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7251), "b874ec6d-884c-4694-b092-66a03029e8c7", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7268), "b874ec6d-884c-4694-b092-66a03029e8c7", "I'm driving", 2 },
                    { 3, "6c136e26-2431-4b04-acb7-6d354abe5e8e", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7272), "b874ec6d-884c-4694-b092-66a03029e8c7", new DateTime(2024, 3, 26, 0, 58, 37, 845, DateTimeKind.Local).AddTicks(7275), "b874ec6d-884c-4694-b092-66a03029e8c7", "I'm driving", 3 }
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
