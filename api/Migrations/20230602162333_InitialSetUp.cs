using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyingTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParentCommantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "FirstName", "LastName", "UserName" },
                values: new object[,]
                {
                    { new Guid("1cd9e503-4a83-492a-afc6-35a9d182cdc1"), new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3697), null, null, "vader" },
                    { new Guid("21e9638c-2dd9-4c43-b4a6-4c2f5fcb3f59"), new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3699), null, null, "yoda" },
                    { new Guid("c8de10e9-7268-4dd1-ae2b-2f897d7f0a58"), new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3694), null, null, "leiaskywalker" },
                    { new Guid("cb4e3ea5-9264-40a9-ae28-24a782b5ffd4"), new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3446), null, null, "lukesksywalker" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentContent", "CreatedAt", "ParentCommantId", "ReplyingTo", "Score", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Impressive! Though it seems the drag feature could be improved. But overall it looks incredible. You've nailed the design and the responsiveness at various breakpoints works really well.", new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3829), null, null, 12, new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3832), new Guid("c8de10e9-7268-4dd1-ae2b-2f897d7f0a58") },
                    { 2, "Woah, your project looks awesome! How long have you been coding for? I'm still new, but think I want to dive into Angular as well soon. Perhaps you can give me an insight on where I can learn Angular? Thanks!", new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3835), null, null, 5, new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3837), new Guid("cb4e3ea5-9264-40a9-ae28-24a782b5ffd4") },
                    { 3, "If you're looking to kick start your career, search no further. React is all you need. Welcome to the Dark Side.", new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3839), 2, "lukeskywalker", 4, new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3840), new Guid("1cd9e503-4a83-492a-afc6-35a9d182cdc1") },
                    { 4, "Chillax, my Padawans. Much to learn, you have. The fundamentals of HTML, CSS, and JS,  I'd recommend focusing on. It's very tempting to jump ahead but lay a solid foundation first. Everything moves so fast and it always seems like everyone knows the newest library/framework. But the fundamentals are what stays constant.", new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3843), 2, "vader", 2, new DateTime(2023, 6, 3, 2, 23, 33, 143, DateTimeKind.Local).AddTicks(3844), new Guid("21e9638c-2dd9-4c43-b4a6-4c2f5fcb3f59") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
