using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class remove_prioritylever : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_MD_PRIORITY_LEVEL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_MD_PRIORITY_LEVEL",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_PRIORITY_LEVEL", x => x.Code);
                });
        }
    }
}
