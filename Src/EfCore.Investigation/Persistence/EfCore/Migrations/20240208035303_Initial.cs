﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCore.Investigation.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BudgetSharing");

            migrationBuilder.CreateTable(
                name: "BudgetPermissions",
                schema: "BudgetSharing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "BudgetSharing",
                columns: table => new
                {
                    BudgetPermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParticipantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => new { x.BudgetPermissionId, x.Id });
                    table.ForeignKey(
                        name: "FK_Permission_BudgetPermissions_BudgetPermissionId",
                        column: x => x.BudgetPermissionId,
                        principalSchema: "BudgetSharing",
                        principalTable: "BudgetPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPermissions_BudgetId",
                schema: "BudgetSharing",
                table: "BudgetPermissions",
                column: "BudgetId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission",
                schema: "BudgetSharing");

            migrationBuilder.DropTable(
                name: "BudgetPermissions",
                schema: "BudgetSharing");
        }
    }
}
