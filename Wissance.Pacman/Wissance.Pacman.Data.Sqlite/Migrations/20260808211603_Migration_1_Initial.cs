using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wissance.Pacman.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class Migration_1_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "localizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "package_owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    IsOrganization = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    AdditionalInfo = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package_owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeprecatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    AdminUserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 96, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "target_frameworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_target_frameworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "localization_strings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LanguageCode = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Text = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: false),
                    LocalizationId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localization_strings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_localization_strings_localizations_LocalizationId",
                        column: x => x.LocalizationId,
                        principalTable: "localizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Version = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    CommentId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resources_localizations_CommentId",
                        column: x => x.CommentId,
                        principalTable: "localizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "package_versions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackageId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackageVersionStatsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Summary = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    ReleaseNotes = table.Column<string>(type: "text", nullable: false),
                    Authors = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    ProjectUrl = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    LicenseUrl = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    IconUrl = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    RepositoryUrl = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    RepositoryType = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    PackageSize = table.Column<long>(type: "INTEGER", nullable: false),
                    PackageHash = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    PackageHashAlgorithm = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    IsListed = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    PublishedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package_versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_package_versions_packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "packages_package_owners",
                columns: table => new
                {
                    OwnersId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages_package_owners", x => new { x.OwnersId, x.PackageId });
                    table.ForeignKey(
                        name: "FK_packages_package_owners_package_owners_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "package_owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_packages_package_owners_packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "package_dependencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackageRepo = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    PackageId = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    MinVersion = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    MaxVersion = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    TargetFrameworkId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackageVersionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package_dependencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_package_dependencies_package_versions_PackageVersionId",
                        column: x => x.PackageVersionId,
                        principalTable: "package_versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_package_dependencies_target_frameworks_TargetFrameworkId",
                        column: x => x.TargetFrameworkId,
                        principalTable: "target_frameworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "package_version_stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PackageVersionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Downloads = table.Column<long>(type: "INTEGER", nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package_version_stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_package_version_stats_package_versions_PackageVersionId",
                        column: x => x.PackageVersionId,
                        principalTable: "package_versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "package_version_tags",
                columns: table => new
                {
                    PackageVersionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package_version_tags", x => new { x.PackageVersionId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_package_version_tags_package_versions_PackageVersionId",
                        column: x => x.PackageVersionId,
                        principalTable: "package_versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_package_version_tags_tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_localization_strings_LocalizationId",
                table: "localization_strings",
                column: "LocalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_package_dependencies_PackageVersionId",
                table: "package_dependencies",
                column: "PackageVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_package_dependencies_TargetFrameworkId",
                table: "package_dependencies",
                column: "TargetFrameworkId");

            migrationBuilder.CreateIndex(
                name: "IX_package_owners_Name",
                table: "package_owners",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_package_version_stats_PackageVersionId",
                table: "package_version_stats",
                column: "PackageVersionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_package_version_tags_TagsId",
                table: "package_version_tags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "ix_package_versions_is_listed",
                table: "package_versions",
                column: "IsListed");

            migrationBuilder.CreateIndex(
                name: "ix_package_versions_package_id_version",
                table: "package_versions",
                columns: new[] { "PackageId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_packages_deprecated_at",
                table: "packages",
                column: "DeprecatedAt");

            migrationBuilder.CreateIndex(
                name: "ix_packages_is_available",
                table: "packages",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "ix_packages_name",
                table: "packages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_packages_package_owners_PackageId",
                table: "packages_package_owners",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_resources_CommentId",
                table: "resources",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_Name",
                table: "tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_target_frameworks_Name",
                table: "target_frameworks",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "localization_strings");

            migrationBuilder.DropTable(
                name: "package_dependencies");

            migrationBuilder.DropTable(
                name: "package_version_stats");

            migrationBuilder.DropTable(
                name: "package_version_tags");

            migrationBuilder.DropTable(
                name: "packages_package_owners");

            migrationBuilder.DropTable(
                name: "resources");

            migrationBuilder.DropTable(
                name: "target_frameworks");

            migrationBuilder.DropTable(
                name: "package_versions");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "package_owners");

            migrationBuilder.DropTable(
                name: "localizations");

            migrationBuilder.DropTable(
                name: "packages");
        }
    }
}
