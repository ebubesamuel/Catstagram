using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catstagram.Migrations
{
    /// <inheritdoc />
    public partial class anotherone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "CatPosts",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "authorName",
                table: "CatPosts",
                newName: "AuthorName");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "CatPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CatPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CatPosts",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CatPosts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CatPosts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CatPosts");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "CatPosts",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "CatPosts",
                newName: "authorName");
        }
    }
}
