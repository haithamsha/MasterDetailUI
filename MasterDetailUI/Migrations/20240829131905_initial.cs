﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterDetailUI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMediaAccounts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalWebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    TeachingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccreditedHours = table.Column<int>(type: "int", nullable: false),
                    SchoolLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolSocialMediaAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Masters_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_MasterId",
                table: "Details",
                column: "MasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Masters");
        }
    }
}
