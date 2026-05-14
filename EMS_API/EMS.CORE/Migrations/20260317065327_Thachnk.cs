using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.CORE.Migrations
{
    /// <inheritdoc />
    public partial class Thachnk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ORDER_SEQUENCE");

            migrationBuilder.CreateTable(
                name: "T_AD_ACCOUNT",
                columns: table => new
                {
                    USER_NAME = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    FULL_NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    USER_ID = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    PASSWORD = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    EMAIL = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    ADDRESS = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    ACCOUNT_TYPE = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    ORG_CODE = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    URL_IMAGE = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    FACE_ID = table.Column<string>(type: "VARCHAR(100)", nullable: true),
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
                    table.PrimaryKey("PK_T_AD_ACCOUNT", x => x.USER_NAME);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_ACCOUNTGROUP",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    NOTES = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                    ROLE_CODE = table.Column<string>(type: "VARCHAR(255)", nullable: true),
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
                    table.PrimaryKey("PK_T_AD_ACCOUNTGROUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_ACTIONLOG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ACTION_URL = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    REQUEST_DATA = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    REQUEST_TIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RESPONSE_DATA = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    RESPONSE_TIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STATUS_CODE = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AD_ACTIONLOG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_APP_VERSION",
                columns: table => new
                {
                    VERSION_CODE = table.Column<int>(type: "int", nullable: false),
                    VERSION_NAME = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IS_REQUIRED_UPDATE = table.Column<bool>(type: "bit", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AD_APP_VERSION", x => x.VERSION_CODE);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_MENU",
                columns: table => new
                {
                    ID = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    P_ID = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ORDER_NUMBER = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    ICON = table.Column<string>(type: "VARCHAR(255)", nullable: true),
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
                    table.PrimaryKey("PK_T_AD_MENU", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_MESSAGE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    LANG = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    VALUE = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
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
                    table.PrimaryKey("PK_T_AD_MESSAGE", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_ORGANIZE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    PId = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ORDER_NUMBER = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_T_AD_ORGANIZE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_RIGHT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    PId = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ORDER_NUMBER = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_T_AD_RIGHT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_SYSTEM_TRACE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "varchar(50)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TYPE = table.Column<string>(type: "varchar(50)", nullable: false),
                    ADDRESS = table.Column<string>(type: "varchar(255)", nullable: false),
                    INTERVAL = table.Column<int>(type: "int", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true),
                    LOG = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    LAST_CHECK_TIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AD_SYSTEM_TRACE", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "T_CM_FILE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    REFRENCE_FILE_ID = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    FILE_NAME = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    FILE_TYPE = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    FILE_SIZE = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: true),
                    PATH = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    FILE_PATH = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    FILE_NAME_KHONG_DAU = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    IS_ALLOW_DELETE = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_T_CM_FILE", x => x.ID);
                });

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
                    PHONENUMBER = table.Column<string>(type: "VARCHAR(20)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "T_AD_REFRESH_TOKEN",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_NAME = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    REFRESH_TOKEN = table.Column<string>(type: "NVARCHAR(2000)", nullable: false),
                    EXPIRE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AD_REFRESH_TOKEN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_AD_REFRESH_TOKEN_T_AD_ACCOUNT_USER_NAME",
                        column: x => x.USER_NAME,
                        principalTable: "T_AD_ACCOUNT",
                        principalColumn: "USER_NAME",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_ACCOUNT_ACCOUNTGROUP",
                columns: table => new
                {
                    USER_NAME = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    GROUP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AD_ACCOUNT_ACCOUNTGROUP", x => new { x.USER_NAME, x.GROUP_ID });
                    table.ForeignKey(
                        name: "FK_T_AD_ACCOUNT_ACCOUNTGROUP_T_AD_ACCOUNTGROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "T_AD_ACCOUNTGROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_AD_ACCOUNT_ACCOUNTGROUP_T_AD_ACCOUNT_USER_NAME",
                        column: x => x.USER_NAME,
                        principalTable: "T_AD_ACCOUNT",
                        principalColumn: "USER_NAME",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_ACCOUNT_RIGHT",
                columns: table => new
                {
                    USER_NAME = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    RIGHT_ID = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IS_ADDED = table.Column<bool>(type: "bit", nullable: true),
                    IS_REMOVED = table.Column<bool>(type: "bit", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AD_ACCOUNT_RIGHT", x => new { x.USER_NAME, x.RIGHT_ID });
                    table.ForeignKey(
                        name: "FK_T_AD_ACCOUNT_RIGHT_T_AD_ACCOUNT_USER_NAME",
                        column: x => x.USER_NAME,
                        principalTable: "T_AD_ACCOUNT",
                        principalColumn: "USER_NAME",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_AD_ACCOUNT_RIGHT_T_AD_RIGHT_RIGHT_ID",
                        column: x => x.RIGHT_ID,
                        principalTable: "T_AD_RIGHT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_ACCOUNTGROUP_RIGHT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GROUP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RIGHT_ID = table.Column<string>(type: "VARCHAR(50)", nullable: false),
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
                    table.PrimaryKey("PK_T_AD_ACCOUNTGROUP_RIGHT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_AD_ACCOUNTGROUP_RIGHT_T_AD_ACCOUNTGROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "T_AD_ACCOUNTGROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_AD_ACCOUNTGROUP_RIGHT_T_AD_RIGHT_RIGHT_ID",
                        column: x => x.RIGHT_ID,
                        principalTable: "T_AD_RIGHT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_AD_MENU_RIGHT",
                columns: table => new
                {
                    MenuId = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    RightId = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AD_MENU_RIGHT", x => new { x.MenuId, x.RightId });
                    table.ForeignKey(
                        name: "FK_T_AD_MENU_RIGHT_T_AD_MENU_MenuId",
                        column: x => x.MenuId,
                        principalTable: "T_AD_MENU",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_AD_MENU_RIGHT_T_AD_RIGHT_RightId",
                        column: x => x.RightId,
                        principalTable: "T_AD_RIGHT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_AD_ACCOUNT_ACCOUNTGROUP_GROUP_ID",
                table: "T_AD_ACCOUNT_ACCOUNTGROUP",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_AD_ACCOUNT_RIGHT_RIGHT_ID",
                table: "T_AD_ACCOUNT_RIGHT",
                column: "RIGHT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_AD_ACCOUNTGROUP_RIGHT_GROUP_ID",
                table: "T_AD_ACCOUNTGROUP_RIGHT",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_AD_ACCOUNTGROUP_RIGHT_RIGHT_ID",
                table: "T_AD_ACCOUNTGROUP_RIGHT",
                column: "RIGHT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_AD_MENU_RIGHT_RightId",
                table: "T_AD_MENU_RIGHT",
                column: "RightId");

            migrationBuilder.CreateIndex(
                name: "IX_T_AD_REFRESH_TOKEN_USER_NAME",
                table: "T_AD_REFRESH_TOKEN",
                column: "USER_NAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_AD_ACCOUNT_ACCOUNTGROUP");

            migrationBuilder.DropTable(
                name: "T_AD_ACCOUNT_RIGHT");

            migrationBuilder.DropTable(
                name: "T_AD_ACCOUNTGROUP_RIGHT");

            migrationBuilder.DropTable(
                name: "T_AD_ACTIONLOG");

            migrationBuilder.DropTable(
                name: "T_AD_APP_VERSION");

            migrationBuilder.DropTable(
                name: "T_AD_MENU_RIGHT");

            migrationBuilder.DropTable(
                name: "T_AD_MESSAGE");

            migrationBuilder.DropTable(
                name: "T_AD_ORGANIZE");

            migrationBuilder.DropTable(
                name: "T_AD_REFRESH_TOKEN");

            migrationBuilder.DropTable(
                name: "T_AD_SYSTEM_TRACE");

            migrationBuilder.DropTable(
                name: "T_CM_FILE");

            migrationBuilder.DropTable(
                name: "T_MD_ACCOUNT_TPYE");

            migrationBuilder.DropTable(
                name: "T_MD_EMPLOYEES");

            migrationBuilder.DropTable(
                name: "T_AD_ACCOUNTGROUP");

            migrationBuilder.DropTable(
                name: "T_AD_MENU");

            migrationBuilder.DropTable(
                name: "T_AD_RIGHT");

            migrationBuilder.DropTable(
                name: "T_AD_ACCOUNT");

            migrationBuilder.DropSequence(
                name: "ORDER_SEQUENCE");
        }
    }
}
