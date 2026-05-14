using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class MasterdataThachnkV11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_MD_PRIORITY_LEVEL",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_PRIORITY_LEVEL", x => x.Code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_MD_PRIORITY_LEVEL");
        }
    }
}
