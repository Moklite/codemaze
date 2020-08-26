using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartaceEDMS.API.Data.Migrations.EDMSAuditApp
{
    public partial class InitialCreateAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<long>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<long>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(nullable: true),
                    JsonVal = table.Column<string>(nullable: true),
                    TextVal = table.Column<string>(nullable: true),
                    IsJson = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");
        }
    }
}
