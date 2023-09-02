using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeStudy_3._1.Migrations
{
    public partial class SeedStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Calssroom", "Email", "Major", "Name" },
                values: new object[] { 1, 0, "123@qq.com", 0, "张三" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
