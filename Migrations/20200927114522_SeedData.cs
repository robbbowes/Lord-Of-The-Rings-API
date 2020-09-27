using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_rpg.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Damage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    UserRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    HitPoints = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Class = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Damage = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 1, 10, "Trimming the verge" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 2, 20, "Flurry" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 3, 45, "Blow the Horn of Gondor" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 4, 10, "Look pained" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 5, 300, "Be the best character" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserRole", "Username" },
                values: new object[] { 1, new byte[] { 125, 91, 148, 89, 35, 162, 170, 132, 237, 207, 161, 191, 238, 22, 43, 175, 187, 60, 235, 89, 115, 69, 86, 182, 245, 187, 201, 44, 111, 186, 68, 169, 220, 34, 172, 140, 60, 250, 157, 236, 183, 164, 229, 117, 115, 22, 69, 246, 253, 28, 19, 103, 61, 155, 188, 75, 41, 105, 139, 26, 87, 210, 92, 96 }, new byte[] { 54, 23, 58, 171, 12, 169, 232, 68, 220, 48, 223, 68, 247, 11, 134, 82, 176, 119, 195, 35, 74, 177, 97, 16, 220, 46, 139, 43, 145, 144, 232, 118, 179, 27, 254, 195, 26, 3, 83, 40, 74, 132, 9, 170, 142, 57, 19, 77, 122, 55, 8, 121, 1, 163, 159, 53, 97, 27, 85, 152, 5, 86, 61, 34, 39, 49, 179, 172, 119, 102, 16, 57, 179, 115, 212, 197, 170, 89, 179, 210, 228, 174, 239, 231, 255, 1, 6, 181, 25, 57, 240, 228, 76, 171, 82, 153, 186, 48, 213, 7, 215, 174, 135, 178, 170, 150, 197, 240, 20, 60, 13, 224, 168, 133, 144, 153, 179, 55, 41, 49, 97, 174, 28, 126, 8, 54, 73, 180 }, 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserRole", "Username" },
                values: new object[] { 2, new byte[] { 125, 91, 148, 89, 35, 162, 170, 132, 237, 207, 161, 191, 238, 22, 43, 175, 187, 60, 235, 89, 115, 69, 86, 182, 245, 187, 201, 44, 111, 186, 68, 169, 220, 34, 172, 140, 60, 250, 157, 236, 183, 164, 229, 117, 115, 22, 69, 246, 253, 28, 19, 103, 61, 155, 188, 75, 41, 105, 139, 26, 87, 210, 92, 96 }, new byte[] { 54, 23, 58, 171, 12, 169, 232, 68, 220, 48, 223, 68, 247, 11, 134, 82, 176, 119, 195, 35, 74, 177, 97, 16, 220, 46, 139, 43, 145, 144, 232, 118, 179, 27, 254, 195, 26, 3, 83, 40, 74, 132, 9, 170, 142, 57, 19, 77, 122, 55, 8, 121, 1, 163, 159, 53, 97, 27, 85, 152, 5, 86, 61, 34, 39, 49, 179, 172, 119, 102, 16, 57, 179, 115, 212, 197, 170, 89, 179, 210, 228, 174, 239, 231, 255, 1, 6, 181, 25, 57, 240, 228, 76, 171, 82, 153, 186, 48, 213, 7, 215, 174, 135, 178, 170, 150, 197, 240, 20, 60, 13, 224, 168, 133, 144, 153, 179, 55, 41, 49, 97, 174, 28, 126, 8, 54, 73, 180 }, 2, "Penny" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserRole", "Username" },
                values: new object[] { 3, new byte[] { 125, 91, 148, 89, 35, 162, 170, 132, 237, 207, 161, 191, 238, 22, 43, 175, 187, 60, 235, 89, 115, 69, 86, 182, 245, 187, 201, 44, 111, 186, 68, 169, 220, 34, 172, 140, 60, 250, 157, 236, 183, 164, 229, 117, 115, 22, 69, 246, 253, 28, 19, 103, 61, 155, 188, 75, 41, 105, 139, 26, 87, 210, 92, 96 }, new byte[] { 54, 23, 58, 171, 12, 169, 232, 68, 220, 48, 223, 68, 247, 11, 134, 82, 176, 119, 195, 35, 74, 177, 97, 16, 220, 46, 139, 43, 145, 144, 232, 118, 179, 27, 254, 195, 26, 3, 83, 40, 74, 132, 9, 170, 142, 57, 19, 77, 122, 55, 8, 121, 1, 163, 159, 53, 97, 27, 85, 152, 5, 86, 61, 34, 39, 49, 179, 172, 119, 102, 16, 57, 179, 115, 212, 197, 170, 89, 179, 210, 228, 174, 239, 231, 255, 1, 6, 181, 25, 57, 240, 228, 76, 171, 82, 153, 186, 48, 213, 7, 215, 174, 135, 178, 170, 150, 197, 240, 20, 60, 13, 224, 168, 133, 144, 153, 179, 55, 41, 49, 97, 174, 28, 126, 8, 54, 73, 180 }, 2, "Elise" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defense", "HitPoints", "Intelligence", "Name", "Strength", "UserId" },
                values: new object[] { 1, 1, 10, 100, 15, "Frodo", 10, 2 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defense", "HitPoints", "Intelligence", "Name", "Strength", "UserId" },
                values: new object[] { 2, 1, 10, 100, 13, "Samwise", 12, 3 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defense", "HitPoints", "Intelligence", "Name", "Strength", "UserId" },
                values: new object[] { 3, 1, 20, 200, 10, "Boromir", 25, 3 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 3, 1, 20, "Sting" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 2, 2, 10, "Gardening shears" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 1, 3, 30, "Broadsword" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
