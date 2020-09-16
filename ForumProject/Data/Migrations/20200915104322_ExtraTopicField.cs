using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumProject.Data.Migrations
{
    public partial class ExtraTopicField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Discussions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Discussions");
        }
    }
}
