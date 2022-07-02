using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Infrastructure.Migrations
{
    public partial class Separatedataintotables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHistory_Users_UserId",
                table: "LeaveHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ManagerId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserLeavePolicys");

            migrationBuilder.DropIndex(
                name: "IX_Users_ManagerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LeaveHistory",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHistory_UserId",
                table: "LeaveHistory",
                newName: "IX_LeaveHistory_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "StatusDescr",
                table: "LeaveStatus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "LeaveHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLeavePolicys",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    LeavePolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeavePolicys", x => new { x.EmployeeId, x.LeavePolicyId });
                    table.ForeignKey(
                        name: "FK_EmployeeLeavePolicys_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLeavePolicys_LeavePolicys_LeavePolicyId",
                        column: x => x.LeavePolicyId,
                        principalTable: "LeavePolicys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId1 = table.Column<long>(type: "bigint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHistories_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeavePolicys_LeavePolicyId",
                table: "EmployeeLeavePolicys",
                column: "LeavePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_EmployeeId1",
                table: "WorkHistories",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHistory_Employees_EmployeeId",
                table: "LeaveHistory",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHistory_Employees_EmployeeId",
                table: "LeaveHistory");

            migrationBuilder.DropTable(
                name: "EmployeeLeavePolicys");

            migrationBuilder.DropTable(
                name: "WorkHistories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "LeaveHistory",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHistory_EmployeeId",
                table: "LeaveHistory",
                newName: "IX_LeaveHistory_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ManagerId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StatusDescr",
                table: "LeaveStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "LeaveHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "IX_Users_ManagerId",
                table: "Users",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLeavePolicys_LeavePolicyId",
                table: "UserLeavePolicys",
                column: "LeavePolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHistory_Users_UserId",
                table: "LeaveHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ManagerId",
                table: "Users",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
