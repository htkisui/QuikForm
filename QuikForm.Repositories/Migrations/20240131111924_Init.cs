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
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Markup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                    { 1, null, null, new DateTime(2024, 1, 2, 1, 8, 35, 803, DateTimeKind.Unspecified).AddTicks(2559), "Incidunt sit corporis quod. In aliquid pariatur. In voluptas esse asperiores accusantium sit sunt velit est consectetur. Quia magnam pariatur.", null, "Voluptatem omnis magnam totam quis.", new DateTime(2024, 1, 16, 22, 21, 51, 460, DateTimeKind.Unspecified).AddTicks(4619) },
                    { 2, null, null, new DateTime(2024, 1, 1, 16, 47, 4, 188, DateTimeKind.Unspecified).AddTicks(6931), "Maxime et qui ab qui. Laboriosam qui tempore sapiente itaque eius aut. Incidunt autem et dolorum autem nesciunt. Non omnis voluptas ut ex est atque. Minima consequatur aperiam quod enim nesciunt repellat in illum consequatur. Numquam voluptatem quia est asperiores hic.", null, "Ipsa nostrum ab eaque magni.", new DateTime(2024, 1, 25, 4, 24, 54, 785, DateTimeKind.Unspecified).AddTicks(8983) },
                    { 3, null, null, new DateTime(2024, 1, 1, 19, 46, 20, 55, DateTimeKind.Unspecified).AddTicks(1316), "Nesciunt nostrum quaerat quasi hic molestiae magni. In et aut nam sed totam sunt qui. Qui asperiores doloremque cupiditate dolores explicabo aut a. Perspiciatis amet modi magni doloribus vitae molestiae nobis. Et omnis cupiditate sit ut blanditiis perspiciatis blanditiis. Earum vero tenetur eum veritatis quia autem beatae.", null, "Dignissimos quaerat mollitia et sed.", new DateTime(2024, 1, 24, 21, 58, 28, 945, DateTimeKind.Unspecified).AddTicks(5036) },
                    { 4, null, null, new DateTime(2024, 1, 4, 15, 14, 30, 545, DateTimeKind.Unspecified).AddTicks(1839), "Tempore ut voluptas molestias. Est quia repellat excepturi. Blanditiis perferendis sunt. Tenetur eum iste officia ipsa architecto.", null, "Cum odio quo qui consequuntur.", new DateTime(2024, 1, 14, 21, 52, 13, 658, DateTimeKind.Unspecified).AddTicks(860) },
                    { 5, null, null, new DateTime(2024, 1, 1, 18, 39, 13, 297, DateTimeKind.Unspecified).AddTicks(2110), "Voluptatem sunt sint. Vero vero soluta vel ullam. Et id praesentium non sequi qui eos illum omnis.", null, "Distinctio nam illo qui reprehenderit.", new DateTime(2024, 1, 28, 1, 7, 44, 57, DateTimeKind.Unspecified).AddTicks(8581) }
                });

            migrationBuilder.InsertData(
                table: "InputTypes",
                columns: new[] { "Id", "Label", "Markup" },
                values: new object[,]
                {
                    { 1, "Champs texte", "text" },
                    { 2, "Champs paragraphe", "textarea" },
                    { 3, "Choix multiples", "checkbox" },
                    { 4, "Choix unique", "radio" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "FormId", "InputTypeId", "IsMandatory", "Label" },
                values: new object[,]
                {
                    { 1, 4, 3, false, "Quibusdam illo voluptate recusandae eligendi." },
                    { 2, 3, 1, false, "Aperiam eum ullam quis ipsa." },
                    { 3, 3, 3, false, "Voluptatum nihil provident veniam provident." },
                    { 4, 5, 1, true, "Molestiae dolores nulla et minima." },
                    { 5, 3, 2, true, "Sunt veritatis error delectus odio." },
                    { 6, 5, 2, false, "Ducimus adipisci ratione ipsam et." },
                    { 7, 5, 4, false, "Consequatur consequatur consequatur quia et." },
                    { 8, 1, 3, true, "Earum explicabo amet iusto mollitia." },
                    { 9, 2, 4, false, "Et quia et natus natus." },
                    { 10, 4, 1, false, "Illo perspiciatis est molestias omnis." },
                    { 11, 1, 1, true, "Consequatur et ipsa ad consequatur." },
                    { 12, 5, 1, false, "Repellat consequuntur ex sit necessitatibus." },
                    { 13, 5, 2, false, "Soluta odit omnis ratione ut." },
                    { 14, 5, 3, false, "Corporis at voluptatibus rem beatae." },
                    { 15, 5, 4, false, "Debitis minus non voluptatem rerum." },
                    { 16, 1, 4, false, "Sed temporibus quis magni architecto." },
                    { 17, 3, 4, true, "Laudantium rem consequuntur quibusdam ut." },
                    { 18, 1, 4, true, "Quae et ut quia dolorum." },
                    { 19, 1, 1, false, "Dolorem voluptatem quo eum et." },
                    { 20, 5, 3, false, "Occaecati quos sit necessitatibus voluptates." }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Label", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Aut.", 20 },
                    { 2, "Distinctio.", 3 },
                    { 3, "Magni.", 4 },
                    { 4, "Id.", 2 },
                    { 5, "Nobis.", 2 },
                    { 6, "Et.", 15 },
                    { 7, "Commodi.", 12 },
                    { 8, "Aut.", 19 },
                    { 9, "Et.", 12 },
                    { 10, "Iste.", 3 },
                    { 11, "Voluptatem.", 2 },
                    { 12, "Qui.", 16 },
                    { 13, "Porro.", 3 },
                    { 14, "Itaque.", 15 },
                    { 15, "Earum.", 2 },
                    { 16, "Veniam.", 19 },
                    { 17, "Velit.", 18 },
                    { 18, "Dolor.", 8 },
                    { 19, "Qui.", 7 },
                    { 20, "Ut.", 18 },
                    { 21, "Nihil.", 6 },
                    { 22, "Eum.", 8 },
                    { 23, "Blanditiis.", 13 },
                    { 24, "Ratione.", 16 },
                    { 25, "Eaque.", 15 },
                    { 26, "Eveniet.", 2 },
                    { 27, "Sint.", 19 },
                    { 28, "Soluta.", 7 },
                    { 29, "Et.", 9 },
                    { 30, "Eveniet.", 2 },
                    { 31, "Voluptatibus.", 18 },
                    { 32, "Incidunt.", 6 },
                    { 33, "Officia.", 8 },
                    { 34, "Est.", 13 },
                    { 35, "Vitae.", 16 },
                    { 36, "Provident.", 2 },
                    { 37, "Facere.", 10 },
                    { 38, "Et.", 9 },
                    { 39, "In.", 1 },
                    { 40, "Debitis.", 12 },
                    { 41, "Vitae.", 5 },
                    { 42, "At.", 1 },
                    { 43, "Ut.", 8 },
                    { 44, "Sed.", 12 },
                    { 45, "Sit.", 11 },
                    { 46, "Esse.", 17 },
                    { 47, "Est.", 5 },
                    { 48, "Ut.", 5 },
                    { 49, "Quasi.", 19 },
                    { 50, "Nulla.", 8 }
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
