﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABDALLAH.Migrations
{
    /// <inheritdoc />
    public partial class phoneAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberRT",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberTG",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberRT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberTG",
                table: "AspNetUsers");
        }
    }
}
