using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class NHAT_STATUS_UNIT_PRIORITY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_T_AD_ACCOUNT_STORE_T_MD_STORE_TblMdStoreCode",
            //    table: "T_AD_ACCOUNT_STORE");

            //migrationBuilder.DropTable(
            //    name: "T_MD_ACCOUNT_TPYE");

            //migrationBuilder.DropIndex(
            //    name: "IX_T_AD_ACCOUNT_STORE_TblMdStoreCode",
            //    table: "T_AD_ACCOUNT_STORE");

            //migrationBuilder.DropColumn(
            //    name: "TblMdStoreCode",
            //    table: "T_AD_ACCOUNT_STORE");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NAME",
            //    table: "T_MD_STORE",
            //    type: "NVARCHAR(255)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "VARCHAR(255)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "AREA",
            //    table: "T_MD_STORE",
            //    type: "NVARCHAR(100)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "VARCHAR(100)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ADDRESS",
            //    table: "T_MD_STORE",
            //    type: "NVARCHAR(500)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "VARCHAR(500)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "STORE_CODE",
            //    table: "T_AD_ACCOUNT_STORE",
            //    type: "VARCHAR(50)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "USER_NAME",
            //    table: "T_AD_ACCOUNT_STORE",
            //    type: "VARCHAR(50)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.CreateTable(
            //    name: "T_MD_ACCOUNT_TYPE",
            //    columns: table => new
            //    {
            //        CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
            //        NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
            //        IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
            //        CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
            //        UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
            //        CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_T_MD_ACCOUNT_TYPE", x => x.CODE);
            //    });

            migrationBuilder.CreateTable(
                name: "T_MD_PRIORITY",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_PRIORITY", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "T_MD_STATUS",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_STATUS", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "T_MD_UNIT",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_UNIT", x => x.CODE);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_T_AD_ACCOUNT_STORE_STORE_CODE",
            //    table: "T_AD_ACCOUNT_STORE",
            //    column: "STORE_CODE");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_T_AD_ACCOUNT_STORE_T_AD_ACCOUNT_USER_NAME",
            //    table: "T_AD_ACCOUNT_STORE",
            //    column: "USER_NAME",
            //    principalTable: "T_AD_ACCOUNT",
            //    principalColumn: "USER_NAME",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_T_AD_ACCOUNT_STORE_T_MD_STORE_STORE_CODE",
            //    table: "T_AD_ACCOUNT_STORE",
            //    column: "STORE_CODE",
            //    principalTable: "T_MD_STORE",
            //    principalColumn: "CODE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AD_ACCOUNT_STORE_T_AD_ACCOUNT_USER_NAME",
                table: "T_AD_ACCOUNT_STORE");

            migrationBuilder.DropForeignKey(
                name: "FK_T_AD_ACCOUNT_STORE_T_MD_STORE_STORE_CODE",
                table: "T_AD_ACCOUNT_STORE");

            migrationBuilder.DropTable(
                name: "T_MD_ACCOUNT_TYPE");

            migrationBuilder.DropTable(
                name: "T_MD_PRIORITY");

            migrationBuilder.DropTable(
                name: "T_MD_STATUS");

            migrationBuilder.DropTable(
                name: "T_MD_UNIT");

            migrationBuilder.DropIndex(
                name: "IX_T_AD_ACCOUNT_STORE_STORE_CODE",
                table: "T_AD_ACCOUNT_STORE");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "T_MD_STORE",
                type: "VARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "AREA",
                table: "T_MD_STORE",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "T_MD_STORE",
                type: "VARCHAR(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)");

            migrationBuilder.AlterColumn<string>(
                name: "STORE_CODE",
                table: "T_AD_ACCOUNT_STORE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USER_NAME",
                table: "T_AD_ACCOUNT_STORE",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AddColumn<string>(
                name: "TblMdStoreCode",
                table: "T_AD_ACCOUNT_STORE",
                type: "VARCHAR(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T_MD_ACCOUNT_TPYE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MD_ACCOUNT_TPYE", x => x.CODE);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_AD_ACCOUNT_STORE_TblMdStoreCode",
                table: "T_AD_ACCOUNT_STORE",
                column: "TblMdStoreCode");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AD_ACCOUNT_STORE_T_MD_STORE_TblMdStoreCode",
                table: "T_AD_ACCOUNT_STORE",
                column: "TblMdStoreCode",
                principalTable: "T_MD_STORE",
                principalColumn: "CODE");
        }
    }
}
