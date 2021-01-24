using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BACWebsite.Migrations
{
    public partial class EventChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "EquipmentNeeds");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_EquipmentInventory_ItemTitle",
                table: "EquipmentInventory");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "PrepTime",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "TearDown",
                table: "Event");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Event",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Event",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_MenuItemId",
                table: "Event",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_MenuItem_MenuItemId",
                table: "Event",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_MenuItem_MenuItemId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Room_RoomId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_MenuItemId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Event",
                newName: "RoomID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Event",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Event_RoomId",
                table: "Event",
                newName: "IX_Event_RoomID");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Event",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Event",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventNotes",
                table: "Event",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Event",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Event",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Event",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Event",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrepTime",
                table: "Event",
                type: "decimal(19, 4)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Event",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TearDown",
                table: "Event",
                type: "decimal(19, 4)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_EquipmentInventory_ItemTitle",
                table: "EquipmentInventory",
                column: "ItemTitle");

            migrationBuilder.CreateTable(
                name: "EquipmentNeeds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: true),
                    ItemTitle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentNeeds", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Equipment__Event__68487DD7",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Equipment__ItemT__693CA210",
                        column: x => x.ItemTitle,
                        principalTable: "EquipmentInventory",
                        principalColumn: "ItemTitle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentNeeds_EventID",
                table: "EquipmentNeeds",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentNeeds_ItemTitle",
                table: "EquipmentNeeds",
                column: "ItemTitle");

            migrationBuilder.AddForeignKey(
                name: "FK__Event__RoomID__6477ECF3",
                table: "Event",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
