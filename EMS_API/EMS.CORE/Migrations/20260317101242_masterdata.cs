using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class masterdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_MD_STORE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    PHONE = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    ADDRESS = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    AREA = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true),
                    DELETE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DELETE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_STORE", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_ACCOUNT_STORE",
                columns: table => new
                {
                    USER_NAME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TblMdStoreCode = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AD_ACCOUNT_STORE", x => x.USER_NAME);
                    table.ForeignKey(
                        name: "FK_T_AD_ACCOUNT_STORE_T_MD_STORE_TblMdStoreCode",
                        column: x => x.TblMdStoreCode,
                        principalTable: "T_MD_STORE",
                        principalColumn: "CODE");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_AD_ACCOUNT_STORE_TblMdStoreCode",
                table: "T_AD_ACCOUNT_STORE",
                column: "TblMdStoreCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_AD_ACCOUNT_STORE");

            migrationBuilder.DropTable(
                name: "T_MD_STORE");
        }
    }
}
