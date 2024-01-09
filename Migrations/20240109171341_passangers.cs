using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dini_m3ak.Migrations
{
    /// <inheritdoc />
    public partial class passangers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TripId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TripId",
                table: "AspNetUsers",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trips_TripId",
                table: "AspNetUsers",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trips_TripId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TripId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "AspNetUsers");
        }
    }
}
