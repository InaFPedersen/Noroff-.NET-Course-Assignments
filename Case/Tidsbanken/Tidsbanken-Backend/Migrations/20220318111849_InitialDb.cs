using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tidsbanken_Backend.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    ApprovalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IneligiblePeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IneligiblePeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IneligiblePeriods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VacationStatusId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationRequests_VacationStatuses_VacationStatusId",
                        column: x => x.VacationStatusId,
                        principalTable: "VacationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastTimeEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VacationRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_VacationRequests_VacationRequestId",
                        column: x => x.VacationRequestId,
                        principalTable: "VacationRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "LastName", "PhoneNumber", "ProfilePicture" },
                values: new object[,]
                {
                    { "1", "Sindre@test.no", "Sindre", true, "Nygård", 98765434, "https://bobleesays.com/wp-content/uploads/2012/07/beautiful-tuxedo-cat-wide-high-resolution-wallpaper-for-desktop-background-download-tuxedo-cat-images-free-300x240.jpg" },
                    { "2", "Signe@test.no", "Signe", false, "Nygård", 98765433, "https://torange.biz/photofxnew/66/HD/very-vivid-colours-fragment-view-cat-66325.jpg" },
                    { "3", "Sondre@test.no", "Sondre", false, "Nygård", 98765432, "https://mcdn.wallpapersafari.com/medium/36/8/RmU0Au.jpg" },
                    { "KdsQcW5Vb575sLEfIaX3mR01HKDTEqbg@clients", "Admin@test.no", "Test", true, "Admin", 98765434, "https://bobleesays.com/wp-content/uploads/2012/07/beautiful-tuxedo-cat-wide-high-resolution-wallpaper-for-desktop-background-download-tuxedo-cat-images-free-300x240.jpg" }
                });

            migrationBuilder.InsertData(
                table: "VacationStatuses",
                columns: new[] { "Id", "AdminId", "ApprovalTime", "Status" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved" }
                });

            migrationBuilder.InsertData(
                table: "IneligiblePeriods",
                columns: new[] { "Id", "EndDate", "StartDate", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forbidden! No cats will rest on this day.", "1" });

            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "Id", "EndDate", "StartDate", "Title", "UserId", "VacationStatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "two days off coz im a cat", "1", 1 },
                    { 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas 4 cats", "2", 2 },
                    { 3, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "cat time (for cat)", "3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "CreationDate", "LastTimeEdited", "Message", "VacationRequestId" },
                values: new object[] { 1, "1", new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hey man ur a cool cat >:)", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VacationRequestId",
                table: "Comments",
                column: "VacationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_IneligiblePeriods_UserId",
                table: "IneligiblePeriods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_UserId",
                table: "VacationRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_VacationStatusId",
                table: "VacationRequests",
                column: "VacationStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "IneligiblePeriods");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VacationStatuses");
        }
    }
}
