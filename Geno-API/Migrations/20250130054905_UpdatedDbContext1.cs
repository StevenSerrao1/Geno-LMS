using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geno_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDbContext1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolments_Students_StudentId",
                table: "Enrolments");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 5, 49, 4, 242, DateTimeKind.Utc).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 5, 49, 4, 242, DateTimeKind.Utc).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 5, 49, 4, 242, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 1,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 5, 49, 4, 242, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 2,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 5, 49, 4, 242, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 3,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 5, 49, 4, 242, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 5, 49, 4, 242, DateTimeKind.Utc).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: 3,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 5, 49, 4, 242, DateTimeKind.Utc).AddTicks(6478));

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolments_Students_StudentId",
                table: "Enrolments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolments_Students_StudentId",
                table: "Enrolments");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 5, 28, 19, 751, DateTimeKind.Utc).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 5, 28, 19, 751, DateTimeKind.Utc).AddTicks(6799));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 5, 28, 19, 751, DateTimeKind.Utc).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 1,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 5, 28, 19, 751, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 2,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 5, 28, 19, 751, DateTimeKind.Utc).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 3,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 5, 28, 19, 751, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 5, 28, 19, 751, DateTimeKind.Utc).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: 3,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 5, 28, 19, 751, DateTimeKind.Utc).AddTicks(6616));

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolments_Students_StudentId",
                table: "Enrolments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
