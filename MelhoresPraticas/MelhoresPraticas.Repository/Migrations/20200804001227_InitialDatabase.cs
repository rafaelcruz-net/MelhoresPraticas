using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MelhoresPraticas.Repository.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    DtBirthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Complement = table.Column<string>(nullable: false),
                    Neiborhood = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    UserAccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddress_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPhone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    UserAccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhone_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserAccountId",
                table: "UserAddress",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhone_UserAccountId",
                table: "UserPhone",
                column: "UserAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "UserPhone");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}
