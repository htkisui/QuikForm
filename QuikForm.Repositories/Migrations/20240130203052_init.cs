using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuikForm.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: true),
                    FormId = table.Column<int>(type: "int", nullable: true),
                    InputTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_InputTypes_InputTypeId",
                        column: x => x.InputTypeId,
                        principalTable: "InputTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FieldRecords",
                columns: table => new
                {
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    CustomAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldRecords", x => new { x.FieldId, x.RecordId });
                    table.ForeignKey(
                        name: "FK_FieldRecords_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldRecords_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "ApplicationUserId", "ClosedAt", "CreatedAt", "Description", "PublishedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 1, 4, 19, 51, 53, 793, DateTimeKind.Unspecified).AddTicks(606), "Dolore id molestias atque et dolorem. Facilis corrupti magni beatae eos voluptatem dignissimos consequatur. Officiis tenetur et eveniet et. Vel blanditiis quibusdam ea.", null, "Commodi voluptate dignissimos animi nobis.", new DateTime(2024, 1, 28, 9, 39, 20, 328, DateTimeKind.Unspecified).AddTicks(4753) },
                    { 2, null, null, new DateTime(2024, 1, 4, 14, 10, 23, 262, DateTimeKind.Unspecified).AddTicks(8380), "Rerum asperiores ut laudantium quod. Modi repudiandae architecto qui doloremque dolores laborum. Et est qui expedita et. Necessitatibus illum omnis autem repellendus totam quibusdam sed. Nihil eum sapiente eos facilis consectetur modi delectus.", null, "Ea sapiente aut illo culpa.", new DateTime(2024, 1, 28, 17, 0, 42, 387, DateTimeKind.Unspecified).AddTicks(2628) },
                    { 3, null, null, new DateTime(2024, 1, 1, 14, 36, 7, 945, DateTimeKind.Unspecified).AddTicks(9315), "Quis inventore fugiat alias atque non. Qui tempora tempora hic iure quia. Amet modi rerum dolorum quis.", null, "Aliquid et ipsam nulla quam.", new DateTime(2024, 1, 25, 8, 38, 59, 792, DateTimeKind.Unspecified).AddTicks(46) },
                    { 4, null, null, new DateTime(2024, 1, 2, 4, 56, 14, 922, DateTimeKind.Unspecified).AddTicks(9470), "Magnam neque quasi architecto asperiores est. Et placeat aut sed aut dolor doloribus aut exercitationem. Eos explicabo animi amet earum amet. Aut eum rerum. Nobis consequatur quas aspernatur nostrum omnis ullam sunt quibusdam. Occaecati doloribus sunt dignissimos.", null, "Alias consequatur assumenda reiciendis nisi.", new DateTime(2024, 1, 25, 15, 10, 39, 557, DateTimeKind.Unspecified).AddTicks(4555) },
                    { 5, null, null, new DateTime(2024, 1, 1, 17, 15, 0, 930, DateTimeKind.Unspecified).AddTicks(6311), "Praesentium id ut consequatur ut non labore voluptas. Nam omnis repellendus omnis officiis asperiores sit non. Quae eos reprehenderit fugiat reiciendis amet molestiae in quasi.", null, "Quis iste dolor dolor voluptatem.", new DateTime(2024, 1, 14, 7, 25, 16, 57, DateTimeKind.Unspecified).AddTicks(6740) }
                });

            migrationBuilder.InsertData(
                table: "InputTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Text" },
                    { 2, "Textarea" },
                    { 3, "Checkbox" },
                    { 4, "Radio" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "FormId", "InputTypeId", "IsMandatory", "Label" },
                values: new object[,]
                {
                    { 1, 5, 4, false, "Reprehenderit sit rem consectetur vel." },
                    { 2, 1, 1, true, "Nihil quae autem quisquam minus." },
                    { 3, 3, 4, true, "Enim tenetur quasi occaecati quam." },
                    { 4, 2, 4, true, "Facere odio autem iusto quis." },
                    { 5, 4, 2, true, "Amet illo perspiciatis aliquid mollitia." },
                    { 6, 3, 2, true, "Voluptatem dolore repellendus iure ad." },
                    { 7, 4, 2, true, "Cumque tempore maxime sit officia." },
                    { 8, 1, 1, true, "Dolorum enim cupiditate ut consequatur." },
                    { 9, 3, 1, false, "Sint iste voluptatem veritatis esse." },
                    { 10, 5, 3, false, "Quis ab aut assumenda perspiciatis." },
                    { 11, 4, 3, false, "Quis dolore aspernatur provident voluptatem." },
                    { 12, 1, 1, false, "Aut nihil quasi earum id." },
                    { 13, 2, 1, false, "Consequuntur laudantium temporibus suscipit inventore." },
                    { 14, 5, 1, false, "Nihil in libero quae consectetur." },
                    { 15, 5, 4, false, "Inventore qui veritatis id quo." },
                    { 16, 2, 2, true, "Quia cumque at eos occaecati." },
                    { 17, 1, 2, true, "Voluptate quisquam asperiores illo accusamus." },
                    { 18, 2, 3, false, "Perferendis qui vel pariatur sint." },
                    { 19, 5, 4, false, "Reprehenderit saepe velit deleniti at." },
                    { 20, 1, 3, true, "Fugit labore aut facilis error." }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Label", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Doloribus.", 13 },
                    { 2, "Culpa.", 19 },
                    { 3, "Illo.", 18 },
                    { 4, "Ea.", 12 },
                    { 5, "Et.", 16 },
                    { 6, "Incidunt.", 11 },
                    { 7, "Et.", 14 },
                    { 8, "Voluptates.", 13 },
                    { 9, "Sint.", 2 },
                    { 10, "Maiores.", 18 },
                    { 11, "Commodi.", 12 },
                    { 12, "Fugiat.", 3 },
                    { 13, "Voluptatem.", 1 },
                    { 14, "Sit.", 3 },
                    { 15, "Ipsum.", 15 },
                    { 16, "Et.", 18 },
                    { 17, "Temporibus.", 16 },
                    { 18, "Quis.", 15 },
                    { 19, "Asperiores.", 3 },
                    { 20, "Exercitationem.", 2 },
                    { 21, "Deserunt.", 8 },
                    { 22, "Et.", 2 },
                    { 23, "Qui.", 17 },
                    { 24, "Soluta.", 2 },
                    { 25, "Aspernatur.", 6 },
                    { 26, "Quia.", 10 },
                    { 27, "Recusandae.", 11 },
                    { 28, "Veritatis.", 16 },
                    { 29, "Commodi.", 7 },
                    { 30, "Perferendis.", 19 },
                    { 31, "Dolore.", 9 },
                    { 32, "Facere.", 4 },
                    { 33, "Voluptatem.", 4 },
                    { 34, "Voluptas.", 20 },
                    { 35, "Necessitatibus.", 10 },
                    { 36, "Accusantium.", 8 },
                    { 37, "Labore.", 1 },
                    { 38, "Optio.", 17 },
                    { 39, "Non.", 16 },
                    { 40, "Et.", 15 },
                    { 41, "Hic.", 17 },
                    { 42, "Iste.", 12 },
                    { 43, "Dolorem.", 19 },
                    { 44, "Sed.", 7 },
                    { 45, "Voluptatum.", 5 },
                    { 46, "Consequuntur.", 15 },
                    { 47, "Aut.", 5 },
                    { 48, "Et.", 3 },
                    { 49, "Expedita.", 1 },
                    { 50, "Libero.", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FieldRecords_RecordId",
                table: "FieldRecords",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_QuestionId",
                table: "Fields",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ApplicationUserId",
                table: "Forms",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FormId",
                table: "Questions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_InputTypeId",
                table: "Questions",
                column: "InputTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_ApplicationUserId",
                table: "Records",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FieldRecords");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "InputTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
