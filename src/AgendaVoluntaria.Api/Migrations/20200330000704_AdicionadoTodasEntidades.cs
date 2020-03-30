using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaVoluntaria.Api.Migrations
{
    public partial class AdicionadoTodasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:shifts_description", "morning,afternoon,night,dawn");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Shifts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Psicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psicos_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    Ra = table.Column<int>(nullable: false),
                    Course = table.Column<string>(maxLength: 128, nullable: false),
                    NeedPsico = table.Column<bool>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volunteers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    Begin = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    IdVolunteer = table.Column<Guid>(nullable: false),
                    IdShift = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Shifts_IdShift",
                        column: x => x.IdShift,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Volunteers_IdVolunteer",
                        column: x => x.IdVolunteer,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerShifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    Idvolunteer = table.Column<Guid>(nullable: false),
                    IdVolunteer = table.Column<Guid>(nullable: false),
                    IdShift = table.Column<Guid>(nullable: false)
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
                name: "IX_Attendances_IdShift",
                table: "Attendances",
                column: "IdShift");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdVolunteer",
                table: "Attendances",
                column: "IdVolunteer");

            migrationBuilder.CreateIndex(
                name: "IX_Psicos_IdUser",
                table: "Psicos",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IdUser",
                table: "Volunteers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerShifts_IdShift",
                table: "VolunteerShifts",
                column: "IdShift");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerShifts_IdVolunteer",
                table: "VolunteerShifts",
                column: "IdVolunteer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Psicos");

            migrationBuilder.DropTable(
                name: "VolunteerShifts");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shifts");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:shifts_description", "morning,afternoon,night,dawn");
        }
    }
}
