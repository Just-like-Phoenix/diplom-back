using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace diplom_back.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedFirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedLastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedMiddleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialIndicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Leverage = table.Column<double>(type: "float", nullable: false),
                    CoverageRatio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialIndicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiquidityIndicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentLiquidity = table.Column<double>(type: "float", nullable: false),
                    FastLiquidity = table.Column<double>(type: "float", nullable: false),
                    FreeCashFlow = table.Column<double>(type: "float", nullable: false),
                    AccountsRecTurnover = table.Column<double>(type: "float", nullable: false),
                    ReservesTurnover = table.Column<double>(type: "float", nullable: false),
                    AccountsPayTurnover = table.Column<double>(type: "float", nullable: false),
                    FinancialCycle = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidityIndicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfitabilityIndicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnOnAssets = table.Column<double>(type: "float", nullable: false),
                    ReturnOnEquity = table.Column<double>(type: "float", nullable: false),
                    ReturnOnInvestment = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfitabilityIndicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Organization",
                columns: table => new
                {
                    RegNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.RegNum);
                    table.ForeignKey(
                        name: "FK_Organization_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationIndicators",
                columns: table => new
                {
                    Year = table.Column<int>(type: "int", nullable: false),
                    RegNum = table.Column<int>(type: "int", nullable: false),
                    LiquidityIndicatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialIndicatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfitabilityIndicatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationIndicators", x => new { x.Year, x.RegNum });
                    table.ForeignKey(
                        name: "FK_OrganizationIndicators_FinancialIndicators_FinancialIndicatorsId",
                        column: x => x.FinancialIndicatorsId,
                        principalTable: "FinancialIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationIndicators_LiquidityIndicators_LiquidityIndicatorsId",
                        column: x => x.LiquidityIndicatorsId,
                        principalTable: "LiquidityIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationIndicators_Organization_RegNum",
                        column: x => x.RegNum,
                        principalTable: "Organization",
                        principalColumn: "RegNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationIndicators_ProfitabilityIndicators_ProfitabilityIndicatorsId",
                        column: x => x.ProfitabilityIndicatorsId,
                        principalTable: "ProfitabilityIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("43fbc09c-8cf8-46e3-976a-1be09d2f0119"), null, "PlusUser", "PLUSUSER" },
                    { new Guid("4f49d075-b5a9-4754-b1f4-22934c48a3d4"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("876905b4-bf2d-4673-9ed0-53d1c35785fd"), null, "FreeUser", "FREEUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ApplicationUserId",
                table: "Organization",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationIndicators_FinancialIndicatorsId",
                table: "OrganizationIndicators",
                column: "FinancialIndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationIndicators_LiquidityIndicatorsId",
                table: "OrganizationIndicators",
                column: "LiquidityIndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationIndicators_ProfitabilityIndicatorsId",
                table: "OrganizationIndicators",
                column: "ProfitabilityIndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationIndicators_RegNum",
                table: "OrganizationIndicators",
                column: "RegNum");
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
                name: "OrganizationIndicators");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FinancialIndicators");

            migrationBuilder.DropTable(
                name: "LiquidityIndicators");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "ProfitabilityIndicators");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
