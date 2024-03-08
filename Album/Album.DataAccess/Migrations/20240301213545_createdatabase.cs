using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Album.DataAccess.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GalleryAlbums",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coverPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isEnabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryAlbums", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AlbumAttachment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pathUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    galleryAlbumId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isEnabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumAttachment", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlbumAttachment_GalleryAlbums_galleryAlbumId",
                        column: x => x.galleryAlbumId,
                        principalTable: "GalleryAlbums",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumAttachment_galleryAlbumId",
                table: "AlbumAttachment",
                column: "galleryAlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumAttachment");

            migrationBuilder.DropTable(
                name: "GalleryAlbums");
        }
    }
}
