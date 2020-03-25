﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.WalletManagement.MsSqlRepositories.Migrations
{
    public partial class AddLocationIdToBonusEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "location_id",
                schema: "wallet_management",
                table: "bonus_event_data",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location_id",
                schema: "wallet_management",
                table: "bonus_event_data");
        }
    }
}
