using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social.Repositories.Migrations
{
    public partial class AddAcademicInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbEducationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AcademicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    EducationalLevelId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEducationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbEducationInfo_EducationalLevels_EducationalLevelId",
                        column: x => x.EducationalLevelId,
                        principalTable: "EducationalLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DbEducationInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbEducationInfo_EducationalLevelId",
                table: "DbEducationInfo",
                column: "EducationalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DbEducationInfo_UserId",
                table: "DbEducationInfo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbEducationInfo");
        }
    }
}
