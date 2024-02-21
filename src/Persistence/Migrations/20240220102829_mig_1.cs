﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 887, DateTimeKind.Local).AddTicks(3463)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 888, DateTimeKind.Local).AddTicks(963)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThumbnailImagePath = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 884, DateTimeKind.Local).AddTicks(1095)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 889, DateTimeKind.Local).AddTicks(218)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperations_Operations_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteBlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogPostId = table.Column<int>(type: "int", nullable: false),
                    VoteType = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "None"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2024, 2, 20, 14, 28, 28, 893, DateTimeKind.Local).AddTicks(8380)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteBlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteBlogPosts_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VoteBlogPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CreatedBy",
                table: "BlogPosts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperations_OperationClaimId",
                table: "UserOperations",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperations_UserId",
                table: "UserOperations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteBlogPosts_BlogPostId",
                table: "VoteBlogPosts",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteBlogPosts_UserId",
                table: "VoteBlogPosts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOperations");

            migrationBuilder.DropTable(
                name: "VoteBlogPosts");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
