﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PinewoodTest.API.Migrations
{
    /// <inheritdoc />
    public partial class MakeEmailUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Email",
                table: "Customers");
        }
    }
}
