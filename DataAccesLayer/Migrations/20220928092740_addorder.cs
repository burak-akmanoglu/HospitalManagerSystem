using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    public partial class addorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Storehouses_StorehouseId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StorehouseId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Storehouses_StorehouseId",
                table: "Products",
                column: "StorehouseId",
                principalTable: "Storehouses",
                principalColumn: "StorehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Storehouses_StorehouseId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StorehouseId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Storehouses_StorehouseId",
                table: "Products",
                column: "StorehouseId",
                principalTable: "Storehouses",
                principalColumn: "StorehouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
