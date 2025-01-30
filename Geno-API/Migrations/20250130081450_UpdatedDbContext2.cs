using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geno_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDbContext2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Enrolments",
                columns: new[] { "EnrolmentId", "CourseId", "EnrolmentDate", "StudentId" },
                values: new object[] { 4, 1, new DateTime(2025, 1, 30, 8, 14, 48, 927, DateTimeKind.Utc).AddTicks(3040), 3 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrolments",
                keyColumn: "EnrolmentId",
                keyValue: 4);

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
        }
    }
}
