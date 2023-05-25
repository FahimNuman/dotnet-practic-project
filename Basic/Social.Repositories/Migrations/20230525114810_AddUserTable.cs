using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social.Repositories.Migrations
{
    public partial class AddUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbUser_Roles_RoleId",
                table: "DbUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbUser",
                table: "DbUser");

            migrationBuilder.RenameTable(
                name: "DbUser",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_DbUser_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "DbUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "DbUser",
                newName: "IX_DbUser_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbUser",
                table: "DbUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbUser_Roles_RoleId",
                table: "DbUser",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
