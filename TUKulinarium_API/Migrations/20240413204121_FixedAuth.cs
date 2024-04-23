using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TUKulinarium_API.Migrations
{
    /// <inheritdoc />
    public partial class FixedAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_UserProfiles_UserProfileProfileId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserProfileProfileId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserProfileProfileId",
                table: "Payments");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ProfileId",
                table: "Payments",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_UserProfiles_ProfileId",
                table: "Payments",
                column: "ProfileId",
                principalTable: "UserProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_UserProfiles_ProfileId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ProfileId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileProfileId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserProfileProfileId",
                table: "Payments",
                column: "UserProfileProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_UserProfiles_UserProfileProfileId",
                table: "Payments",
                column: "UserProfileProfileId",
                principalTable: "UserProfiles",
                principalColumn: "ProfileId");
        }
    }
}
