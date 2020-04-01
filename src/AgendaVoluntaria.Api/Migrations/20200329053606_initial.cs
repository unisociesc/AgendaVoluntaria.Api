using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AgendaVoluntaria.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "Role", "UpdateAt" },
                values: new object[] { new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ghmeyer0@gmail.com", "Gabriel Helko Meyer", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", "admin", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
