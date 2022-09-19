using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tidsbanken_Backend.Migrations
{
    public partial class fixedtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "VacationStatuses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "VacationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdminId",
                value: null);

            migrationBuilder.UpdateData(
                table: "VacationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdminId",
                value: null);

            migrationBuilder.UpdateData(
                table: "VacationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdminId",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "VacationStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "VacationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdminId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VacationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdminId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VacationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdminId",
                value: 0);
        }
    }
}
