using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Infrastructure.Migrations
{
    public partial class Fixedforeignkeyissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistories_Employees_EmployeeId1",
                table: "WorkHistories");

            migrationBuilder.DropIndex(
                name: "IX_WorkHistories_EmployeeId1",
                table: "WorkHistories");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "WorkHistories");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "WorkHistories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_EmployeeId",
                table: "WorkHistories",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistories_Employees_EmployeeId",
                table: "WorkHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistories_Employees_EmployeeId",
                table: "WorkHistories");

            migrationBuilder.DropIndex(
                name: "IX_WorkHistories_EmployeeId",
                table: "WorkHistories");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "WorkHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeId1",
                table: "WorkHistories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_EmployeeId1",
                table: "WorkHistories",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistories_Employees_EmployeeId1",
                table: "WorkHistories",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
