using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    IdIcao = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    SunRise = table.Column<string>(nullable: true),
                    SunSet = table.Column<string>(nullable: true),
                    Utc = table.Column<string>(nullable: true),
                    Fir = table.Column<string>(nullable: true),
                    ElevationFeet = table.Column<string>(nullable: true),
                    ElevationMeters = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    TypeOpr = table.Column<string>(nullable: true),
                    TypeUtil = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DarkTheme = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AipSuplements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Serie = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AipSuplements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AipSuplements_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    MessageMetar = table.Column<string>(nullable: true),
                    FlightCategory = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metars_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    NotamId = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notams_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgRotaers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgRotaers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgRotaers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Runways",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RwyWidth = table.Column<string>(nullable: true),
                    RwyLength = table.Column<string>(nullable: true),
                    RwySurface = table.Column<string>(nullable: true),
                    RwyIdent = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runways", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runways_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tafs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    MessageTaf = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tafs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tafs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AipSuplements_LocationId",
                table: "AipSuplements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Metars_LocationId",
                table: "Metars",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notams_LocationId",
                table: "Notams",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgRotaers_LocationId",
                table: "OrgRotaers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Runways_LocationId",
                table: "Runways",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tafs_LocationId",
                table: "Tafs",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AipSuplements");

            migrationBuilder.DropTable(
                name: "Metars");

            migrationBuilder.DropTable(
                name: "Notams");

            migrationBuilder.DropTable(
                name: "OrgRotaers");

            migrationBuilder.DropTable(
                name: "Runways");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Tafs");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
