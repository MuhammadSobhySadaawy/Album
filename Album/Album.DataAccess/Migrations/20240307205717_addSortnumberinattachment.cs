using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Album.DataAccess.Migrations
{
    public partial class addSortnumberinattachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sortNumber",
                table: "AlbumAttachment",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sortNumber",
                table: "AlbumAttachment");
        }
    }
}
