using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeNewSms.Migrations
{
    /// <inheritdoc />
    public partial class SyncDepartmentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exam_Class_ClassId",
                table: "exam");

            migrationBuilder.DropForeignKey(
                name: "FK_section_Class_ClassId",
                table: "section");

            migrationBuilder.DropForeignKey(
                name: "FK_sections_teachers_TeacherId",
                table: "sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Departments_DepartmentId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_ClassId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_Class_ClassId",
                table: "subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_subjects_Departments_DepartmentId",
                table: "subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherAttendances_teachers_TeacherId",
                table: "teacherAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_teachers_Departments_DepartmentId",
                table: "teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_Class_ClassId",
                table: "timetables");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_teachers_TeacherId",
                table: "timetables");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropIndex(
                name: "IX_timetables_ClassId",
                table: "timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teachers",
                table: "teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "SPosition",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "StaffAttendance",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "StaffEmail",
                table: "Staff");

            migrationBuilder.RenameTable(
                name: "teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "Createdby",
                table: "Staff",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Updatedby",
                table: "Staff",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Staff",
                newName: "HireDate");

            migrationBuilder.RenameColumn(
                name: "StaffRole",
                table: "Staff",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "StaffPhone",
                table: "Staff",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "StaffLastName",
                table: "Staff",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "StaffGender",
                table: "Staff",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "StaffFirstName",
                table: "Staff",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "SHireDate",
                table: "Staff",
                newName: "DeletedOn");

            migrationBuilder.RenameColumn(
                name: "SDateOfBirth",
                table: "Staff",
                newName: "Dob");

            migrationBuilder.RenameIndex(
                name: "IX_teachers_DepartmentId",
                table: "Teacher",
                newName: "IX_Teacher_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Department",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Department",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepHeadId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Department",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Department",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_Department_DepHeadId",
                table: "Department",
                column: "DepHeadId",
                unique: true,
                filter: "[DepHeadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClass_DepartmentId",
                table: "SchoolClass",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClass_SessionId",
                table: "SchoolClass",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Staff_DepHeadId",
                table: "Department",
                column: "DepHeadId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_exams_SchoolClass_ClassId",
                table: "exams",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sections_SchoolClass_ClassId",
                table: "sections",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sections_Teacher_TeacherId",
                table: "sections",
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
                name: "FK_Student_SchoolClass_ClassId",
                table: "Student",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_timetables_Teacher_TeacherId",
                table: "timetables",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Staff_DepHeadId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_exams_SchoolClass_ClassId",
                table: "exams");

            migrationBuilder.DropForeignKey(
                name: "FK_sections_SchoolClass_ClassId",
                table: "sections");

            migrationBuilder.DropForeignKey(
                name: "FK_sections_Teacher_TeacherId",
                table: "sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Department_DepartmentId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_SchoolClass_ClassId",
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
                name: "FK_timetables_Teacher_TeacherId",
                table: "timetables");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepHeadId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DepHeadId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "teachers");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Staff",
                newName: "Createdby");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Staff",
                newName: "Updatedby");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Staff",
                newName: "StaffRole");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Staff",
                newName: "StaffPhone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Staff",
                newName: "StaffLastName");

            migrationBuilder.RenameColumn(
                name: "HireDate",
                table: "Staff",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Staff",
                newName: "StaffGender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Staff",
                newName: "StaffFirstName");

            migrationBuilder.RenameColumn(
                name: "Dob",
                table: "Staff",
                newName: "SDateOfBirth");

            migrationBuilder.RenameColumn(
                name: "DeletedOn",
                table: "Staff",
                newName: "SHireDate");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_DepartmentId",
                table: "teachers",
                newName: "IX_teachers_DepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "SPosition",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StaffAttendance",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StaffEmail",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teachers",
                table: "teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_timetables_ClassId",
                table: "timetables",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_DepartmentId",
                table: "Class",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_exams_Class_ClassId",
                table: "exams",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sections_Class_ClassId",
                table: "sections",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sections_teachers_TeacherId",
                table: "sections",
                column: "TeacherId",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Departments_DepartmentId",
                table: "Staff",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_ClassId",
                table: "Student",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_Class_ClassId",
                table: "subjects",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_Departments_DepartmentId",
                table: "subjects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherAttendances_teachers_TeacherId",
                table: "teacherAttendances",
                column: "TeacherId",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_Departments_DepartmentId",
                table: "teachers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_Class_ClassId",
                table: "timetables",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_teachers_TeacherId",
                table: "timetables",
                column: "TeacherId",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
