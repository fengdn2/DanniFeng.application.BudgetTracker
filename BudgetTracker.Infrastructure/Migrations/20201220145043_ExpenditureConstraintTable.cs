using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracker.Infrastructure.Migrations
{
    public partial class ExpenditureConstraintTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditure_Users_UserId",
                table: "Expenditure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenditure",
                table: "Expenditure");

            migrationBuilder.RenameTable(
                name: "Expenditure",
                newName: "Expenditures");

            migrationBuilder.RenameIndex(
                name: "IX_Expenditure_UserId",
                table: "Expenditures",
                newName: "IX_Expenditures_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Expenditures",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Expenditures",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Expenditures",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenditures",
                table: "Expenditures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Users_UserId",
                table: "Expenditures",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Users_UserId",
                table: "Expenditures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenditures",
                table: "Expenditures");

            migrationBuilder.RenameTable(
                name: "Expenditures",
                newName: "Expenditure");

            migrationBuilder.RenameIndex(
                name: "IX_Expenditures_UserId",
                table: "Expenditure",
                newName: "IX_Expenditure_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Expenditure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Expenditure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Expenditure",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenditure",
                table: "Expenditure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditure_Users_UserId",
                table: "Expenditure",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
