using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AgendaVoluntaria.Api.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"), new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ricardo.pfitscher@unisociesc.com.br", "Ricardo Pfitscher", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "admin", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e9e0000-6d1c-bc1b-eb06-08d7d524408d"), new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "eslin@eslin.com", "Éslin Makicine Martins", "abad878fb17fb8710d8ac8c4612f379ee0ff9a0ad530bbe9729b7256f178f7bd", "admin", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3a480000-248f-9e93-51c3-08d7d5261675"), new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnnyrtrentin@gmail.com", "johnny", "98bb0701a145990b4f0e0880398010d97c3d24eb189e8c80f818f6bc062a86d0", "admin", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "Course", "CreateAt", "IdUser", "NeedPsico", "Ra", "UpdateAt" },
                values: new object[] { new Guid("60180000-5e87-f520-b74d-08d7d52122bd"), "Engenharia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"), false, 121815278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e9e0000-6d1c-bc1b-eb06-08d7d524408d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a480000-248f-9e93-51c3-08d7d5261675"));

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("60180000-5e87-f520-b74d-08d7d52122bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"));
        }
    }
}
