using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    public partial class SpeakerSacramentMeetingID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_SacramentMeetingProgram_SacramentMeetingProgramID",
                table: "Speaker");

            migrationBuilder.AlterColumn<int>(
                name: "SacramentMeetingProgramID",
                table: "Speaker",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_SacramentMeetingProgram_SacramentMeetingProgramID",
                table: "Speaker",
                column: "SacramentMeetingProgramID",
                principalTable: "SacramentMeetingProgram",
                principalColumn: "SacramentMeetingProgramID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_SacramentMeetingProgram_SacramentMeetingProgramID",
                table: "Speaker");

            migrationBuilder.AlterColumn<int>(
                name: "SacramentMeetingProgramID",
                table: "Speaker",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_SacramentMeetingProgram_SacramentMeetingProgramID",
                table: "Speaker",
                column: "SacramentMeetingProgramID",
                principalTable: "SacramentMeetingProgram",
                principalColumn: "SacramentMeetingProgramID");
        }
    }
}
