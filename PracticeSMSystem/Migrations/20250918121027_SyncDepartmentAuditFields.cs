using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeNewSms.Migrations
{
    /// <inheritdoc />
    public partial class SyncDepartmentAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_examResults_exams_ExamId",
                table: "examResults");

            migrationBuilder.DropForeignKey(
                name: "FK_exams_SchoolClass_ClassId",
                table: "exams");

            migrationBuilder.DropForeignKey(
                name: "FK_exams_sections_SectionId",
                table: "exams");

            migrationBuilder.DropForeignKey(
                name: "FK_examSubjects_exams_ExamId",
                table: "examSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_sections_SchoolClass_ClassId",
                table: "sections");

            migrationBuilder.DropForeignKey(
                name: "FK_sections_Teacher_TeacherId",
                table: "sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_sections_SectionId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_sections_SectionId",
                table: "timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sections",
                table: "sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_exams",
                table: "exams");

            migrationBuilder.RenameTable(
                name: "sections",
                newName: "Section");

            migrationBuilder.RenameTable(
                name: "exams",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_sections_TeacherId",
                table: "Section",
                newName: "IX_Section_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_sections_ClassId",
                table: "Section",
                newName: "IX_Section_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_exams_SectionId",
                table: "Exam",
                newName: "IX_Exam_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_exams_ClassId",
                table: "Exam",
                newName: "IX_Exam_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_SchoolClass_ClassId",
                table: "Exam",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Section_SectionId",
                table: "Exam",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examResults_Exam_ExamId",
                table: "examResults",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examSubjects_Exam_ExamId",
                table: "examSubjects",
                column: "ExamId",
                principalTable: "Exam",
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
                name: "FK_Student_Section_SectionId",
                table: "Student",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_Section_SectionId",
                table: "timetables",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_SchoolClass_ClassId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Section_SectionId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_examResults_Exam_ExamId",
                table: "examResults");

            migrationBuilder.DropForeignKey(
                name: "FK_examSubjects_Exam_ExamId",
                table: "examSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_SchoolClass_ClassId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Teacher_TeacherId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Section_SectionId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_Section_SectionId",
                table: "timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "sections");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "exams");

            migrationBuilder.RenameIndex(
                name: "IX_Section_TeacherId",
                table: "sections",
                newName: "IX_sections_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_ClassId",
                table: "sections",
                newName: "IX_sections_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_SectionId",
                table: "exams",
                newName: "IX_exams_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_ClassId",
                table: "exams",
                newName: "IX_exams_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sections",
                table: "sections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_exams",
                table: "exams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_examResults_exams_ExamId",
                table: "examResults",
                column: "ExamId",
                principalTable: "exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_exams_SchoolClass_ClassId",
                table: "exams",
                column: "ClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_exams_sections_SectionId",
                table: "exams",
                column: "SectionId",
                principalTable: "sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examSubjects_exams_ExamId",
                table: "examSubjects",
                column: "ExamId",
                principalTable: "exams",
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
                name: "FK_Student_sections_SectionId",
                table: "Student",
                column: "SectionId",
                principalTable: "sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_sections_SectionId",
                table: "timetables",
                column: "SectionId",
                principalTable: "sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
