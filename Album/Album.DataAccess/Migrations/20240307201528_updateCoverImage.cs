using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Album.DataAccess.Migrations
{
    public partial class updateCoverImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "coverPhoto",
                table: "GalleryAlbums",
                newName: "coverPhotoPath");

            migrationBuilder.AddColumn<string>(
                name: "coverPhotoName",
                table: "GalleryAlbums",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coverPhotoName",
                table: "GalleryAlbums");

            migrationBuilder.RenameColumn(
                name: "coverPhotoPath",
                table: "GalleryAlbums",
                newName: "coverPhoto");
        }
    }
}
