using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaVoluntaria.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    Begin = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    MaxVolunteer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    Begin = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
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
                        name: "FK_Attendances_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreateAt", "Email", "Name", "Password", "Phone", "Role", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), null, new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ghmeyer0@gmail.com", "Gabriel Helko Meyer", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", null, "admin", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"), null, new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ricardo.pfitscher@unisociesc.com.br", "Ricardo Pfitscher", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, "admin", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e9e0000-6d1c-bc1b-eb06-08d7d524408d"), null, new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "eslin@eslin.com", "Éslin Makicine Martins", "abad878fb17fb8710d8ac8c4612f379ee0ff9a0ad530bbe9729b7256f178f7bd", null, "admin", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3a480000-248f-9e93-51c3-08d7d5261675"), null, new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnnyrtrentin@gmail.com", "johnny", "98bb0701a145990b4f0e0880398010d97c3d24eb189e8c80f818f6bc062a86d0", null, "admin", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "Course", "CreateAt", "IdUser", "NeedPsico", "Ra", "UpdateAt" },
                values: new object[] { new Guid("60180000-5e87-f520-b74d-08d7d52122bd"), "Engenharia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"), false, 121815278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdShift",
                table: "Attendances",
                column: "IdShift");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdUser",
                table: "Attendances",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Psicos_IdUser",
                table: "Psicos",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserShifts_IdShift",
                table: "UserShifts",
                column: "IdShift");

            migrationBuilder.CreateIndex(
                name: "IX_UserShifts_IdUser",
                table: "UserShifts",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IdUser",
                table: "Volunteers",
                column: "IdUser",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Psicos");

            migrationBuilder.DropTable(
                name: "UserShifts");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
