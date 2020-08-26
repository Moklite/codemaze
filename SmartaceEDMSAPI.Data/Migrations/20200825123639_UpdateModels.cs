using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartaceEDMS.API.Data.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DocumentLibraries",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DocumentLibraries",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DocumentLibraries",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Name",
                table: "DocumentLibraries",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Description",
                table: "DocumentLibraries",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Code",
                table: "DocumentLibraries",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
