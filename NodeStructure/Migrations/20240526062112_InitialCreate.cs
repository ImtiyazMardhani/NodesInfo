using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeStructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nodesInfo",
                columns: table => new
                {
                    nodeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nodeName = table.Column<string>(type: "TEXT", nullable: false),
                    parentNodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    startDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodesInfo", x => x.nodeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nodesInfo");
        }
    }
}
