using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pisofinderapi.Migrations
{
    /// <inheritdoc />
    public partial class SyncSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Properties_PropertyId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PropertyId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_AddressId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PropertyId",
                table: "Addresses",
                column: "PropertyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Properties_PropertyId",
                table: "Addresses",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
