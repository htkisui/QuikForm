using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuikForm.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    { 1, null, null, new DateTime(2024, 1, 2, 17, 57, 25, 551, DateTimeKind.Unspecified).AddTicks(8931), "Adipisci omnis voluptatem cum. Cum nobis cupiditate ad. Vel autem dolorem quisquam at nostrum quis velit architecto rerum. Hic nihil qui id numquam voluptatem laudantium. Similique recusandae dicta et ea impedit. Sequi rerum assumenda ut.", null, "Magnam neque vel culpa sit.", new DateTime(2024, 1, 20, 10, 56, 39, 780, DateTimeKind.Unspecified).AddTicks(3367) },
                    { 2, null, null, new DateTime(2024, 1, 3, 14, 1, 12, 331, DateTimeKind.Unspecified).AddTicks(782), "Possimus voluptatem voluptates ut et unde. Consequatur omnis aperiam facere maxime odio sit modi. Deserunt eius ut.", null, "Vitae voluptatum praesentium nobis pariatur.", new DateTime(2024, 1, 22, 17, 0, 8, 183, DateTimeKind.Unspecified).AddTicks(4787) },
                    { 3, null, null, new DateTime(2024, 1, 1, 4, 36, 50, 21, DateTimeKind.Unspecified).AddTicks(2400), "Id debitis suscipit amet quae distinctio. Voluptatem non enim. Quo inventore vitae et commodi fugiat. Numquam ut fugit voluptates sit explicabo ut et. Necessitatibus aut vitae et. Nobis consectetur possimus ipsa quis.", null, "Incidunt molestias ad quibusdam dolorem.", new DateTime(2024, 1, 15, 1, 41, 14, 665, DateTimeKind.Unspecified).AddTicks(6154) },
                    { 4, null, null, new DateTime(2024, 1, 4, 23, 29, 43, 566, DateTimeKind.Unspecified).AddTicks(9323), "Perferendis voluptas doloribus est aliquid quia nemo dolorem asperiores laudantium. Atque repellendus aut voluptatibus atque iste deserunt sit. Eos in nobis et illum aut. Omnis molestiae officia quis repellat iste id quia dolor. Et doloribus ut deleniti dolores animi. Quidem rem non quis voluptatibus velit quia.", null, "Error eos aut non laudantium.", new DateTime(2024, 1, 30, 3, 13, 36, 172, DateTimeKind.Unspecified).AddTicks(1101) },
                    { 5, null, null, new DateTime(2024, 1, 2, 19, 28, 6, 21, DateTimeKind.Unspecified).AddTicks(396), "Harum esse sit libero quam harum sint. Quas qui beatae similique. Nemo tempore aliquid ea optio. A corporis sit. Eum molestiae beatae ut.", null, "Repellendus dolorum ratione fugiat in.", new DateTime(2024, 1, 10, 10, 21, 55, 937, DateTimeKind.Unspecified).AddTicks(4491) }
                });

            migrationBuilder.InsertData(
                table: "InputTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "text" },
                    { 2, "textarea" },
                    { 3, "checkbox" },
                    { 4, "radio" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "FormId", "InputTypeId", "IsMandatory", "Label" },
                values: new object[,]
                {
                    { 1, 1, 3, false, "Laboriosam officiis quisquam modi voluptatem." },
                    { 2, 2, 3, true, "Consequuntur sint aspernatur tenetur doloribus." },
                    { 3, 4, 2, true, "Perferendis numquam fugiat quidem illum." },
                    { 4, 2, 4, true, "Officia odit in et fugiat." },
                    { 5, 3, 2, false, "Animi veniam earum exercitationem modi." },
                    { 6, 3, 3, true, "Soluta sit et distinctio consectetur." },
                    { 7, 2, 3, true, "Vitae totam at accusantium labore." },
                    { 8, 5, 1, true, "Aliquid fuga omnis perspiciatis eligendi." },
                    { 9, 2, 1, true, "Quia odio aspernatur illo occaecati." },
                    { 10, 5, 2, false, "Voluptate rerum laudantium ipsum impedit." },
                    { 11, 3, 2, true, "Quos iste omnis omnis labore." },
                    { 12, 1, 3, false, "Quo omnis quibusdam illo corporis." },
                    { 13, 1, 3, true, "Ut vel architecto deserunt eum." },
                    { 14, 3, 1, true, "Laboriosam laudantium magnam cumque voluptas." },
                    { 15, 3, 4, false, "Et tempora similique aut perspiciatis." },
                    { 16, 4, 2, true, "Suscipit voluptas eveniet cupiditate quasi." },
                    { 17, 4, 3, false, "Alias vel qui et aut." },
                    { 18, 2, 4, true, "Ea eveniet cupiditate explicabo praesentium." },
                    { 19, 2, 3, false, "Dolores quia provident fuga minima." },
                    { 20, 4, 2, true, "Voluptatem consequatur voluptate rem voluptatem." }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Label", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Porro.", 6 },
                    { 2, "Pariatur.", 5 },
                    { 3, "Eveniet.", 4 },
                    { 4, "Magni.", 5 },
                    { 5, "Ea.", 2 },
                    { 6, "Molestiae.", 20 },
                    { 7, "Unde.", 2 },
                    { 8, "Sed.", 18 },
                    { 9, "Voluptatem.", 9 },
                    { 10, "Consequatur.", 5 },
                    { 11, "Repellendus.", 4 },
                    { 12, "Aliquid.", 6 },
                    { 13, "Quia.", 10 },
                    { 14, "Veritatis.", 8 },
                    { 15, "Eligendi.", 2 },
                    { 16, "Odio.", 12 },
                    { 17, "Odio.", 4 },
                    { 18, "Quia.", 6 },
                    { 19, "Omnis.", 1 },
                    { 20, "Mollitia.", 13 },
                    { 21, "Quis.", 17 },
                    { 22, "Aliquid.", 18 },
                    { 23, "Odio.", 1 },
                    { 24, "Ipsum.", 19 },
                    { 25, "Delectus.", 19 },
                    { 26, "Enim.", 3 },
                    { 27, "Dicta.", 15 },
                    { 28, "Nesciunt.", 2 },
                    { 29, "Inventore.", 19 },
                    { 30, "Ipsum.", 14 },
                    { 31, "Aut.", 10 },
                    { 32, "Ullam.", 4 },
                    { 33, "Deserunt.", 16 },
                    { 34, "Rerum.", 8 },
                    { 35, "Blanditiis.", 12 },
                    { 36, "Dolor.", 19 },
                    { 37, "Reprehenderit.", 2 },
                    { 38, "Qui.", 2 },
                    { 39, "Nobis.", 6 },
                    { 40, "Vel.", 8 },
                    { 41, "Sed.", 11 },
                    { 42, "Occaecati.", 16 },
                    { 43, "Eos.", 9 },
                    { 44, "Iusto.", 2 },
                    { 45, "Eum.", 11 },
                    { 46, "Pariatur.", 3 },
                    { 47, "Maxime.", 16 },
                    { 48, "Saepe.", 1 },
                    { 49, "Necessitatibus.", 6 },
                    { 50, "Molestiae.", 10 }
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
