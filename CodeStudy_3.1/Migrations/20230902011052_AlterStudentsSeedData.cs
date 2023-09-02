using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeStudy_3._1.Migrations
{
    public partial class AlterStudentsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Calssroom", "Email", "Major", "Name" },
                values: new object[] { 2, 1, "1234@qq.com", 2, "李四" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
