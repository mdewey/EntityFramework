using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFramework.Migrations
{
    public partial class PubslishdateToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Blogs",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Blogs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);
        }
    }
}
