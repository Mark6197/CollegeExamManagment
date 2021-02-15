using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedAssignedExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_Exams_ExamId",
                table: "StudentExam");

            migrationBuilder.DropIndex(
                name: "IX_StudentExam_ExamId",
                table: "StudentExam");

            migrationBuilder.AddColumn<long>(
                name: "AssignedExamId",
                table: "StudentExam",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Exams",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDate",
                table: "Exams",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<int>(
                name: "ExamType",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_AssignedExamId",
                table: "StudentExam",
                column: "AssignedExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_Exams_AssignedExamId",
                table: "StudentExam",
                column: "AssignedExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_Exams_AssignedExamId",
                table: "StudentExam");

            migrationBuilder.DropIndex(
                name: "IX_StudentExam_AssignedExamId",
                table: "StudentExam");

            migrationBuilder.DropColumn(
                name: "AssignedExamId",
                table: "StudentExam");

            migrationBuilder.DropColumn(
                name: "ExamType",
                table: "Exams");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Exams",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDate",
                table: "Exams",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ExamId",
                table: "StudentExam",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_Exams_ExamId",
                table: "StudentExam",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
