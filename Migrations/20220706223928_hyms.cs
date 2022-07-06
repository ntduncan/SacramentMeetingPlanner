using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    public partial class hyms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HymnNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    HymnTitle = table.Column<string>(type: "TEXT", nullable: false),
                    HymnType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnID);
                });

            migrationBuilder.CreateTable(
                name: "SacramentMeetingProgram",
                columns: table => new
                {
                    SacramentMeetingProgramID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConductingLeader = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    OpeningPrayer = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ClosingPrayer = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    OpeningHymnID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClosingHymnID = table.Column<int>(type: "INTEGER", nullable: false),
                    SacramentHymnID = table.Column<int>(type: "INTEGER", nullable: false),
                    IntermediateHymnID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentMeetingProgram", x => x.SacramentMeetingProgramID);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingProgram_Hymn_ClosingHymnID",
                        column: x => x.ClosingHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingProgram_Hymn_IntermediateHymnID",
                        column: x => x.IntermediateHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID");
                    table.ForeignKey(
                        name: "FK_SacramentMeetingProgram_Hymn_OpeningHymnID",
                        column: x => x.OpeningHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingProgram_Hymn_SacramentHymnID",
                        column: x => x.SacramentHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Topic = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SacramentMeetingProgramID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speaker_SacramentMeetingProgram_SacramentMeetingProgramID",
                        column: x => x.SacramentMeetingProgramID,
                        principalTable: "SacramentMeetingProgram",
                        principalColumn: "SacramentMeetingProgramID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingProgram_ClosingHymnID",
                table: "SacramentMeetingProgram",
                column: "ClosingHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingProgram_IntermediateHymnID",
                table: "SacramentMeetingProgram",
                column: "IntermediateHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingProgram_OpeningHymnID",
                table: "SacramentMeetingProgram",
                column: "OpeningHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingProgram_SacramentHymnID",
                table: "SacramentMeetingProgram",
                column: "SacramentHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SacramentMeetingProgramID",
                table: "Speaker",
                column: "SacramentMeetingProgramID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "SacramentMeetingProgram");

            migrationBuilder.DropTable(
                name: "Hymn");
        }
    }
}
