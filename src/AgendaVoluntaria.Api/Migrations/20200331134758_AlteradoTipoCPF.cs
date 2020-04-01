using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AgendaVoluntaria.Api.Migrations
{
    public partial class AlteradoTipoCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Volunteers_IdUser",
                table: "Volunteers");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Users",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e9e0000-6d1c-bc1b-eb06-08d7d524408d"),
                column: "CPF",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a480000-248f-9e93-51c3-08d7d5261675"),
                column: "CPF",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"),
                column: "CPF",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                column: "CPF",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IdUser",
                table: "Volunteers",
                column: "IdUser",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Volunteers_IdUser",
                table: "Volunteers");

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e9e0000-6d1c-bc1b-eb06-08d7d524408d"),
                column: "CPF",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a480000-248f-9e93-51c3-08d7d5261675"),
                column: "CPF",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"),
                column: "CPF",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                column: "CPF",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IdUser",
                table: "Volunteers",
                column: "IdUser");
        }
    }
}
