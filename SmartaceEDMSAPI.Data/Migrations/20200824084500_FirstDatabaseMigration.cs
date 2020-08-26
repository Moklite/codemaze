using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartaceEDMS.API.Data.Migrations
{
    public partial class FirstDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessMode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessMode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentFileAuthors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentFileId = table.Column<long>(nullable: false),
                    VersionNo = table.Column<int>(nullable: false),
                    AuthorId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFileAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentFileLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentFileId = table.Column<long>(nullable: false),
                    AccessModeId = table.Column<long>(nullable: false),
                    ActorId = table.Column<long>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    VersionNo = table.Column<int>(nullable: false),
                    OtherInfo = table.Column<string>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFileLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraryFiles",
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
                    DocumentLibraryId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileExt = table.Column<string>(nullable: true),
                    FileSize = table.Column<decimal>(nullable: false),
                    StorageTypeId = table.Column<long>(nullable: false),
                    StorageURLPath = table.Column<string>(nullable: true),
                    FileStatusId = table.Column<int>(nullable: false),
                    VersionNo = table.Column<int>(nullable: false),
                    SerialNo = table.Column<string>(nullable: true),
                    DocumentLibraryPolicyId = table.Column<long>(nullable: false),
                    OwnerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraryFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraryMetadatas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentFileId = table.Column<long>(nullable: false),
                    MetadataList = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraryMetadatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraryRelationships",
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
                    IsFile = table.Column<bool>(nullable: false),
                    SourceId = table.Column<long>(nullable: false),
                    DestinationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraryRelationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraryTypes",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraryVersions",
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
                    DocumentFileId = table.Column<long>(nullable: false),
                    FileExt = table.Column<string>(nullable: true),
                    FileSize = table.Column<decimal>(nullable: false),
                    StorageTypeId = table.Column<long>(nullable: false),
                    StorageURLPath = table.Column<string>(nullable: true),
                    VersionNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraryVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLinks",
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
                    DocumentFileId = table.Column<long>(nullable: false),
                    GeneratedById = table.Column<long>(nullable: false),
                    GeneratedForId = table.Column<long>(nullable: false),
                    IsGeneratedForExternalUser = table.Column<bool>(nullable: false),
                    ExternalUserEmail = table.Column<string>(nullable: true),
                    ExternalUserPhone = table.Column<string>(nullable: true),
                    AccessCode = table.Column<string>(nullable: true),
                    MainURL = table.Column<string>(nullable: true),
                    ShortURL = table.Column<string>(nullable: true),
                    UseCount = table.Column<int>(nullable: false),
                    MaxUseCount = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentObservers",
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
                    DocumentFileId = table.Column<long>(nullable: false),
                    DocumentLibraryId = table.Column<long>(nullable: false),
                    Metadata = table.Column<string>(nullable: true),
                    ObserverId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentObservers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentPolicies",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalOptions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaDataDictionaries",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDataDictionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageTypes",
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
                    Name = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraries",
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
                    DocumentLibraryTypeId = table.Column<long>(nullable: false),
                    Code = table.Column<long>(nullable: false),
                    Name = table.Column<long>(nullable: false),
                    Description = table.Column<long>(nullable: false),
                    ParentDocumentLibraryId = table.Column<long>(nullable: false),
                    DocumentLibraryPolicyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentLibraries_DocumentLibraryTypes_DocumentLibraryTypeId",
                        column: x => x.DocumentLibraryTypeId,
                        principalTable: "DocumentLibraryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraryAccessRequests",
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
                    DocumentLibraryId = table.Column<long>(nullable: false),
                    RequestById = table.Column<long>(nullable: false),
                    Log_Status = table.Column<long>(nullable: false),
                    AccessModeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraryAccessRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentLibraryAccessRequests_AccessMode_AccessModeId",
                        column: x => x.AccessModeId,
                        principalTable: "AccessMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentLibraryAccessRequests_DocumentLibraries_DocumentLibraryId",
                        column: x => x.DocumentLibraryId,
                        principalTable: "DocumentLibraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraryPermissions",
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
                    DocumentLibraryId = table.Column<long>(nullable: false),
                    AccessModeId = table.Column<int>(nullable: false),
                    IsUser = table.Column<bool>(nullable: false),
                    PermissionId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraryPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentLibraryPermissions_AccessMode_AccessModeId",
                        column: x => x.AccessModeId,
                        principalTable: "AccessMode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentLibraryPermissions_DocumentLibraries_DocumentLibraryId",
                        column: x => x.DocumentLibraryId,
                        principalTable: "DocumentLibraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLibraryWorkflows",
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
                    DocumentLibraryId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsUserDefined = table.Column<bool>(nullable: false),
                    UseOTP = table.Column<bool>(nullable: false),
                    BPM_WorkflowCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLibraryWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentLibraryWorkflows_DocumentLibraries_DocumentLibraryId",
                        column: x => x.DocumentLibraryId,
                        principalTable: "DocumentLibraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLibraries_DocumentLibraryTypeId",
                table: "DocumentLibraries",
                column: "DocumentLibraryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLibraryAccessRequests_AccessModeId",
                table: "DocumentLibraryAccessRequests",
                column: "AccessModeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLibraryAccessRequests_DocumentLibraryId",
                table: "DocumentLibraryAccessRequests",
                column: "DocumentLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLibraryPermissions_AccessModeId",
                table: "DocumentLibraryPermissions",
                column: "AccessModeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLibraryPermissions_DocumentLibraryId",
                table: "DocumentLibraryPermissions",
                column: "DocumentLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLibraryWorkflows_DocumentLibraryId",
                table: "DocumentLibraryWorkflows",
                column: "DocumentLibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentFileAuthors");

            migrationBuilder.DropTable(
                name: "DocumentFileLogs");

            migrationBuilder.DropTable(
                name: "DocumentLibraryAccessRequests");

            migrationBuilder.DropTable(
                name: "DocumentLibraryFiles");

            migrationBuilder.DropTable(
                name: "DocumentLibraryMetadatas");

            migrationBuilder.DropTable(
                name: "DocumentLibraryPermissions");

            migrationBuilder.DropTable(
                name: "DocumentLibraryRelationships");

            migrationBuilder.DropTable(
                name: "DocumentLibraryVersions");

            migrationBuilder.DropTable(
                name: "DocumentLibraryWorkflows");

            migrationBuilder.DropTable(
                name: "DocumentLinks");

            migrationBuilder.DropTable(
                name: "DocumentObservers");

            migrationBuilder.DropTable(
                name: "DocumentPolicies");

            migrationBuilder.DropTable(
                name: "GlobalOptions");

            migrationBuilder.DropTable(
                name: "MetaDataDictionaries");

            migrationBuilder.DropTable(
                name: "StorageTypes");

            migrationBuilder.DropTable(
                name: "AccessMode");

            migrationBuilder.DropTable(
                name: "DocumentLibraries");

            migrationBuilder.DropTable(
                name: "DocumentLibraryTypes");
        }
    }
}
