using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "VoteBlogPosts",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 976, DateTimeKind.Local).AddTicks(7262),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 893, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 970, DateTimeKind.Local).AddTicks(1668),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 888, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserOperations",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 971, DateTimeKind.Local).AddTicks(2713),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 889, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Operations",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 969, DateTimeKind.Local).AddTicks(4046),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 887, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BlogPosts",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 965, DateTimeKind.Local).AddTicks(5839),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 884, DateTimeKind.Local).AddTicks(1095));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "VoteBlogPosts",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 893, DateTimeKind.Local).AddTicks(8380),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 976, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 888, DateTimeKind.Local).AddTicks(963),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 970, DateTimeKind.Local).AddTicks(1668));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserOperations",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 889, DateTimeKind.Local).AddTicks(218),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 971, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Operations",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 887, DateTimeKind.Local).AddTicks(3463),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 969, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BlogPosts",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 884, DateTimeKind.Local).AddTicks(1095),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2024, 2, 20, 15, 48, 30, 965, DateTimeKind.Local).AddTicks(5839));
        }
    }
}
