using Microsoft.EntityFrameworkCore.Migrations;

namespace BACWebsite.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(nullable: true),
                    Question1 = table.Column<int>(nullable: true),
                    Answer1 = table.Column<string>(nullable: true),
                    Question2 = table.Column<int>(nullable: true),
                    Answer2 = table.Column<string>(nullable: true),
                    IsCurrent = table.Column<bool>(nullable: true),
                    Question1NavigationId = table.Column<int>(nullable: true),
                    Question2NavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityQuestions_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecurityQuestions_SecurityQuestionsOptions_Question1NavigationId",
                        column: x => x.Question1NavigationId,
                        principalTable: "SecurityQuestionsOptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecurityQuestions_SecurityQuestionsOptions_Question2NavigationId",
                        column: x => x.Question2NavigationId,
                        principalTable: "SecurityQuestionsOptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityQuestions_EmployeeId",
                table: "SecurityQuestions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityQuestions_Question1NavigationId",
                table: "SecurityQuestions",
                column: "Question1NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityQuestions_Question2NavigationId",
                table: "SecurityQuestions",
                column: "Question2NavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityQuestions");
        }
    }
}
