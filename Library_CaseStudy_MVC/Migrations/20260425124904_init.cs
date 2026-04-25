using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_CaseStudy_MVC.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    boodid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    availablecopiesnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.boodid);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    memberid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.memberid);
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    borrowid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    borroedate = table.Column<DateOnly>(type: "date", nullable: false),
                    returndate = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookid = table.Column<int>(type: "int", nullable: false),
                    memberid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => x.borrowid);
                    table.ForeignKey(
                        name: "FK_Borrows_Books_bookid",
                        column: x => x.bookid,
                        principalTable: "Books",
                        principalColumn: "boodid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_Members_memberid",
                        column: x => x.memberid,
                        principalTable: "Members",
                        principalColumn: "memberid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_bookid",
                table: "Borrows",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_memberid",
                table: "Borrows",
                column: "memberid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
