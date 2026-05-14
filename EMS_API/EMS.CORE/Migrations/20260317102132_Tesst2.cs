using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class Tesst2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_MD_TEST_2",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_TEST_2", x => x.CODE);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_MD_TEST_2");
        }
    }
}
