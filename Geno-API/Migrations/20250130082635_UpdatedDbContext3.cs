using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Geno_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDbContext3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 1,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 2,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 3,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 4,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.InsertData(
                table: "FinalGrades",
                columns: new[] { "FinalGradeId", "CourseId", "DenormalizedCourseName", "FinalScore", "StudentId" },
                values: new object[,]
                {
                    { 1, 2, null, 55.0, 3 },
                    { 2, 1, null, 100.0, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: 3,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 8, 26, 34, 269, DateTimeKind.Utc).AddTicks(8651));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinalGrades",
                keyColumn: "FinalGradeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FinalGrades",
                keyColumn: "FinalGradeId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(2722));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 1,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 2,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 3,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 4,
                column: "EnrolmentDate",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: 3,
                column: "DateJoined",
                value: new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(2963));
        }
    }
}
