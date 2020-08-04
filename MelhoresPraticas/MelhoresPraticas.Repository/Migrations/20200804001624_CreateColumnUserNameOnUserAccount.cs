using Microsoft.EntityFrameworkCore.Migrations;

namespace MelhoresPraticas.Repository.Migrations
{
    public partial class CreateColumnUserNameOnUserAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserAccount",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserAccount");
        }
    }
}
