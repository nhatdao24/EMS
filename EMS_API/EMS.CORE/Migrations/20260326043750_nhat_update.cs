using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class nhat_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "T_MD_UNIT",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "T_MD_UNIT",
                newName: "UPDATE_BY");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "T_MD_UNIT",
                newName: "IS_ACTIVE");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "T_MD_UNIT",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "T_MD_UNIT",
                newName: "CREATE_BY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "T_MD_STATUS",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "T_MD_STATUS",
                newName: "UPDATE_BY");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "T_MD_STATUS",
                newName: "IS_ACTIVE");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "T_MD_STATUS",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "T_MD_STATUS",
                newName: "CREATE_BY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "T_MD_PRIORITY",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "T_MD_PRIORITY",
                newName: "UPDATE_BY");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "T_MD_PRIORITY",
                newName: "IS_ACTIVE");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "T_MD_PRIORITY",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "T_MD_PRIORITY",
                newName: "CREATE_BY");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                table: "T_MD_UNIT",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "T_MD_UNIT",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                table: "T_MD_STATUS",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "T_MD_STATUS",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATE_BY",
                table: "T_MD_PRIORITY",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CREATE_BY",
                table: "T_MD_PRIORITY",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "T_MD_UNIT",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UPDATE_BY",
                table: "T_MD_UNIT",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "IS_ACTIVE",
                table: "T_MD_UNIT",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "T_MD_UNIT",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CREATE_BY",
                table: "T_MD_UNIT",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "T_MD_STATUS",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UPDATE_BY",
                table: "T_MD_STATUS",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "IS_ACTIVE",
                table: "T_MD_STATUS",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "T_MD_STATUS",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CREATE_BY",
                table: "T_MD_STATUS",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "T_MD_PRIORITY",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UPDATE_BY",
                table: "T_MD_PRIORITY",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "IS_ACTIVE",
                table: "T_MD_PRIORITY",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "T_MD_PRIORITY",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CREATE_BY",
                table: "T_MD_PRIORITY",
                newName: "CreateBy");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "T_MD_UNIT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "T_MD_UNIT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "T_MD_STATUS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "T_MD_STATUS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "T_MD_PRIORITY",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "T_MD_PRIORITY",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);
        }
    }
}
