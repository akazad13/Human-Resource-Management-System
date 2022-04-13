using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Infrastructure.Migrations
{
    public partial class AddedLeavePolicytables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeavePolicys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TotalNoOfLeave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeavePolicys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLeavePolicys",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LeavePolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLeavePolicys", x => new { x.UserId, x.LeavePolicyId });
                    table.ForeignKey(
                        name: "FK_UserLeavePolicys_LeavePolicys_LeavePolicyId",
                        column: x => x.LeavePolicyId,
                        principalTable: "LeavePolicys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLeavePolicys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLeavePolicys_LeavePolicyId",
                table: "UserLeavePolicys",
                column: "LeavePolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLeavePolicys");

            migrationBuilder.DropTable(
                name: "LeavePolicys");
        }
    }
}
