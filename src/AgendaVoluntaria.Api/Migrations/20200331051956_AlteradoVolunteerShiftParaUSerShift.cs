using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AgendaVoluntaria.Api.Migrations
{
    public partial class AlteradoVolunteerShiftParaUSerShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Volunteers_IdVolunteer",
                table: "Attendances");

            migrationBuilder.DropTable(
                name: "VolunteerShifts");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_IdVolunteer",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IdVolunteer",
                table: "Attendances");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "Attendances",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserShifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    IdShift = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserShifts_Shifts_IdShift",
                        column: x => x.IdShift,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserShifts_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdUser",
                table: "Attendances",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserShifts_IdShift",
                table: "UserShifts",
                column: "IdShift");

            migrationBuilder.CreateIndex(
                name: "IX_UserShifts_IdUser",
                table: "UserShifts",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Users_IdUser",
                table: "Attendances",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Users_IdUser",
                table: "Attendances");

            migrationBuilder.DropTable(
                name: "UserShifts");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_IdUser",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Attendances");

            migrationBuilder.AddColumn<Guid>(
                name: "IdVolunteer",
                table: "Attendances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VolunteerShifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdShift = table.Column<Guid>(type: "uuid", nullable: false),
                    IdVolunteer = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerShifts_Shifts_IdShift",
                        column: x => x.IdShift,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerShifts_Volunteers_IdVolunteer",
                        column: x => x.IdVolunteer,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdVolunteer",
                table: "Attendances",
                column: "IdVolunteer");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerShifts_IdShift",
                table: "VolunteerShifts",
                column: "IdShift");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerShifts_IdVolunteer",
                table: "VolunteerShifts",
                column: "IdVolunteer");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Volunteers_IdVolunteer",
                table: "Attendances",
                column: "IdVolunteer",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
