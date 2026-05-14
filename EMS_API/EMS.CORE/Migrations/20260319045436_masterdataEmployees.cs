using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class masterdataEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_MD_ACCOUNT_TPYE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_ACCOUNT_TPYE", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "T_MD_EMPLOYEES",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    FULL_NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    POSITION = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    PHONENUMBER = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    DIGITALSIG = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    ADDRESS = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_EMPLOYEES", x => x.CODE);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_MD_ACCOUNT_TPYE");

            migrationBuilder.DropTable(
                name: "T_MD_EMPLOYEES");
        }
    }
}
