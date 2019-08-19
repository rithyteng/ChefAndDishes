using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace chefanddishes.Migrations
{
    public partial class idkMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_myChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_myChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "myChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Dishes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Dishes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Did",
                table: "Chefs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_Id",
                table: "Dishes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_Id",
                table: "Dishes",
                column: "Id",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_Id",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Did",
                table: "Chefs");

            migrationBuilder.AddColumn<int>(
                name: "myChefId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_myChefId",
                table: "Dishes",
                column: "myChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_myChefId",
                table: "Dishes",
                column: "myChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
