using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Medical.data.EF.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specializes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSpecialize",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    SpecializeId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSpecialize", x => new { x.UserId, x.SpecializeId });
                    table.ForeignKey(
                        name: "FK_UserSpecialize_Specializes_SpecializeId",
                        column: x => x.SpecializeId,
                        principalTable: "Specializes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSpecialize_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSpecialize_SpecializeId",
                table: "UserSpecialize",
                column: "SpecializeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSpecialize");

            migrationBuilder.DropTable(
                name: "Specializes");
        }
    }
}
