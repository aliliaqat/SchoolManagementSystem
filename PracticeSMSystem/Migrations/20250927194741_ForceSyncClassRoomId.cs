using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeNewSms.Migrations
{
    /// <inheritdoc />
    public partial class ForceSyncClassRoomId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_SchoolClass_ClassId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_examResults_subjects_SubjectId",
                table: "examResults");

            migrationBuilder.DropForeignKey(
                name: "FK_examSubjects_subjects_SubjectId",
                table: "examSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_SchoolClass_ClassId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Teacher_TeacherId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Department_DepartmentId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Guardians_guardianId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_SchoolClass_ClassId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Section_SectionId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Student_StudentId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_Department_DepartmentId",
                table: "subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_SchoolClass_ClassId",
                table: "subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Department_DepartmentId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherAttendances_Teacher_TeacherId",
                table: "teacherAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_Section_SectionId",
                table: "timetables");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_Teacher_TeacherId",
                table: "timetables");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_subjects_SubjectId",
                table: "timetables");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropIndex(
                name: "IX_Student_ClassId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_SectionId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudentId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Section_ClassId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_TeacherId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepHeadId",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_timetables",
                table: "timetables");

            migrationBuilder.DropIndex(
                name: "IX_timetables_SectionId",
                table: "timetables");

            migrationBuilder.DropIndex(
                name: "IX_timetables_SubjectId",
                table: "timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teacherAttendances",
                table: "teacherAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjects",
                table: "subjects");

            migrationBuilder.DropIndex(
                name: "IX_subjects_ClassId",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GuardiandID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "subjects");

            migrationBuilder.RenameTable(
                name: "timetables",
                newName: "Timetable");

            migrationBuilder.RenameTable(
                name: "teacherAttendances",
                newName: "TeacherAttendance");

            migrationBuilder.RenameTable(
                name: "subjects",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "guardianId",
                table: "Student",
                newName: "ClassRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_guardianId",
                table: "Student",
                newName: "IX_Student_ClassRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_timetables_TeacherId",
                table: "Timetable",
                newName: "IX_Timetable_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_teacherAttendances_TeacherId",
                table: "TeacherAttendance",
                newName: "IX_TeacherAttendance_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_subjects_DepartmentId",
                table: "Subject",
                newName: "IX_Subject_DepartmentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Teacher",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Teacher",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Teacher",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Teacher",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teacher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Teacher",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Student",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddmissionDate",
                table: "Student",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Student",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Special Instruction",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Staff",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Staff",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Staff",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DeletedBy",
                table: "Staff",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Staff",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Staff",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Staff",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Staff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Session",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Session",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MainSessionId",
                table: "Session",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "Section",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Section",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Timetable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Timetable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Timetable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeek",
                table: "Timetable",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Timetable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TeacherAttendanceDate",
                table: "TeacherAttendance",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Subject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Subject",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Subject",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Subject",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Subject",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timetable",
                table: "Timetable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherAttendance",
                table: "TeacherAttendance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoom_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoom_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Session_MainSessionId",
                table: "Session",
                column: "MainSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ClassRoomId",
                table: "Section",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepHeadId",
                table: "Department",
                column: "DepHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_ClassRoomId",
                table: "Subject",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoom_DepartmentId",
                table: "ClassRoom",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoom_SessionId",
                table: "ClassRoom",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_ClassRoom_ClassId",
                table: "Exam",
                column: "ClassId",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examResults_Subject_SubjectId",
                table: "examResults",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examSubjects_Subject_SubjectId",
                table: "examSubjects",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_ClassRoom_ClassRoomId",
                table: "Section",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Session_MainSessionId",
                table: "Session",
                column: "MainSessionId",
                principalTable: "Session",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Department_DepartmentId",
                table: "Staff",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassRoom_ClassRoomId",
                table: "Student",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_ClassRoom_ClassRoomId",
                table: "Subject",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Department_DepartmentId",
                table: "Subject",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Department_DepartmentId",
                table: "Teacher",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherAttendance_Teacher_TeacherId",
                table: "TeacherAttendance",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Teacher_TeacherId",
                table: "Timetable",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_ClassRoom_ClassId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_examResults_Subject_SubjectId",
                table: "examResults");

            migrationBuilder.DropForeignKey(
                name: "FK_examSubjects_Subject_SubjectId",
                table: "examSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_ClassRoom_ClassRoomId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Session_MainSessionId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Department_DepartmentId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassRoom_ClassRoomId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_ClassRoom_ClassRoomId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Department_DepartmentId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Department_DepartmentId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherAttendance_Teacher_TeacherId",
                table: "TeacherAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Teacher_TeacherId",
                table: "Timetable");

            migrationBuilder.DropTable(
                name: "ClassRoom");

            migrationBuilder.DropIndex(
                name: "IX_Session_MainSessionId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Section_ClassRoomId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepHeadId",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timetable",
                table: "Timetable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherAttendance",
                table: "TeacherAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_ClassRoomId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Special Instruction",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "MainSessionId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Subject");

            migrationBuilder.RenameTable(
                name: "Timetable",
                newName: "timetables");

            migrationBuilder.RenameTable(
                name: "TeacherAttendance",
                newName: "teacherAttendances");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "subjects");

            migrationBuilder.RenameColumn(
                name: "ClassRoomId",
                table: "Student",
                newName: "guardianId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ClassRoomId",
                table: "Student",
                newName: "IX_Student_guardianId");

            migrationBuilder.RenameIndex(
                name: "IX_Timetable_TeacherId",
                table: "timetables",
                newName: "IX_timetables_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherAttendance_TeacherId",
                table: "teacherAttendances",
                newName: "IX_teacherAttendances_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_DepartmentId",
                table: "subjects",
                newName: "IX_subjects_DepartmentId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "HireDate",
                table: "Teacher",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Teacher",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Student",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AddmissionDate",
                table: "Student",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuardiandID",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Staff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeletedBy",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Staff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Session",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Section",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Section",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Department",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "timetables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "timetables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "timetables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeek",
                table: "timetables",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "timetables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "TeacherAttendanceDate",
                table: "teacherAttendances",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_timetables",
                table: "timetables",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teacherAttendances",
                table: "teacherAttendances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjects",
                table: "subjects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClass_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClass_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SectionId",
                table: "Student",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentId",
                table: "Student",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ClassId",
                table: "Section",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_TeacherId",
                table: "Section",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepHeadId",
                table: "Department",
                column: "DepHeadId",
                unique: true,
                filter: "[DepHeadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_timetables_SectionId",
                table: "timetables",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_timetables_SubjectId",
                table: "timetables",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_ClassId",
                table: "subjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClass_DepartmentId",
                table: "SchoolClass",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClass_SessionId",
                table: "SchoolClass",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_SchoolClass_ClassId",
                table: "Exam",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examResults_subjects_SubjectId",
                table: "examResults",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examSubjects_subjects_SubjectId",
                table: "examSubjects",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_SchoolClass_ClassId",
                table: "Section",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Teacher_TeacherId",
                table: "Section",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Department_DepartmentId",
                table: "Staff",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Guardians_guardianId",
                table: "Student",
                column: "guardianId",
                principalTable: "Guardians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_SchoolClass_ClassId",
                table: "Student",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Section_SectionId",
                table: "Student",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Student_StudentId",
                table: "Student",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_Department_DepartmentId",
                table: "subjects",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_SchoolClass_ClassId",
                table: "subjects",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Department_DepartmentId",
                table: "Teacher",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherAttendances_Teacher_TeacherId",
                table: "teacherAttendances",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_Section_SectionId",
                table: "timetables",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_Teacher_TeacherId",
                table: "timetables",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_subjects_SubjectId",
                table: "timetables",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
