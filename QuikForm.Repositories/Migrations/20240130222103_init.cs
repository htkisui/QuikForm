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
                    { 1, null, null, new DateTime(2024, 1, 4, 15, 28, 43, 581, DateTimeKind.Unspecified).AddTicks(599), "Odit a vel quo autem rerum. Voluptatum velit minus unde. Rerum a perferendis sed et quas repellendus sapiente.", null, "Aut qui veniam error corporis.", new DateTime(2024, 1, 19, 9, 58, 55, 207, DateTimeKind.Unspecified).AddTicks(8455) },
                    { 2, null, null, new DateTime(2024, 1, 3, 5, 1, 19, 289, DateTimeKind.Unspecified).AddTicks(1787), "Quod voluptatem qui. Sunt mollitia vel velit natus ullam non alias fugit ut. Quaerat nesciunt ad non et dolorem.", null, "Mollitia eaque molestias sit libero.", new DateTime(2024, 1, 24, 18, 24, 48, 791, DateTimeKind.Unspecified).AddTicks(4885) },
                    { 3, null, null, new DateTime(2024, 1, 1, 17, 2, 18, 350, DateTimeKind.Unspecified).AddTicks(567), "Est eum qui modi repudiandae magni fugit. Recusandae reprehenderit quas aut aspernatur eum ipsam. Incidunt adipisci maiores sunt quos qui quasi fugit. Officiis veniam consectetur ea aliquid esse.", null, "Dolor alias molestiae voluptatum temporibus.", new DateTime(2024, 1, 28, 9, 47, 15, 655, DateTimeKind.Unspecified).AddTicks(1722) },
                    { 4, null, null, new DateTime(2024, 1, 3, 6, 33, 44, 267, DateTimeKind.Unspecified).AddTicks(8513), "Quibusdam sed illo reprehenderit tempora. Quas repellat nulla autem nobis nobis in ab. Itaque possimus quidem amet consequatur molestias veritatis tempora facere ducimus.", null, "Et ut impedit beatae quaerat.", new DateTime(2024, 1, 17, 8, 15, 54, 757, DateTimeKind.Unspecified).AddTicks(1521) },
                    { 5, null, null, new DateTime(2024, 1, 1, 11, 57, 27, 491, DateTimeKind.Unspecified).AddTicks(1749), "Magni consequatur est odit sed eligendi nulla nostrum enim. Maiores quasi tempora reprehenderit asperiores. Quisquam pariatur aut et voluptas et et aut fugit. Corporis pariatur sed ut doloribus autem incidunt ducimus est.", null, "Facere itaque illum non explicabo.", new DateTime(2024, 1, 10, 3, 2, 29, 677, DateTimeKind.Unspecified).AddTicks(1118) }
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
                    { 1, 2, 3, false, "Nihil eos facere consequatur facere." },
                    { 2, 5, 2, true, "Ut fuga molestias harum ad." },
                    { 3, 3, 4, true, "Quod non ex quisquam minus." },
                    { 4, 1, 4, true, "Beatae perferendis voluptatum voluptas tenetur." },
                    { 5, 3, 4, true, "Iste magnam excepturi accusantium autem." },
                    { 6, 4, 4, true, "Omnis rerum illo inventore dolorem." },
                    { 7, 2, 4, false, "Fuga dolores reprehenderit ut numquam." },
                    { 8, 5, 1, false, "Labore dolores fugit eum aliquam." },
                    { 9, 5, 4, false, "Est cumque vel deserunt quo." },
                    { 10, 2, 4, true, "At eligendi et consequatur aut." },
                    { 11, 2, 3, true, "Porro dolorem ut vel doloremque." },
                    { 12, 2, 3, true, "Vitae rerum et labore provident." },
                    { 13, 4, 4, true, "Dolores similique vel saepe inventore." },
                    { 14, 4, 4, true, "Nobis dolorum quidem cupiditate molestiae." },
                    { 15, 2, 3, true, "Ipsam quis quo debitis facere." },
                    { 16, 5, 2, true, "Consequatur est modi voluptates delectus." },
                    { 17, 1, 2, false, "Quis blanditiis quasi quia numquam." },
                    { 18, 1, 4, false, "Odit ipsam velit quisquam voluptas." },
                    { 19, 4, 3, true, "Aut amet sit minima in." },
                    { 20, 3, 2, false, "Natus et ex soluta asperiores." }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Label", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Illo.", 13 },
                    { 2, "Qui.", 3 },
                    { 3, "Nobis.", 8 },
                    { 4, "Natus.", 10 },
                    { 5, "Est.", 1 },
                    { 6, "Rem.", 6 },
                    { 7, "Rerum.", 15 },
                    { 8, "Ea.", 20 },
                    { 9, "Omnis.", 10 },
                    { 10, "Ipsum.", 17 },
                    { 11, "Est.", 14 },
                    { 12, "Mollitia.", 11 },
                    { 13, "Molestias.", 10 },
                    { 14, "Quia.", 6 },
                    { 15, "Impedit.", 13 },
                    { 16, "Voluptas.", 11 },
                    { 17, "Est.", 9 },
                    { 18, "Adipisci.", 19 },
                    { 19, "Explicabo.", 12 },
                    { 20, "Unde.", 20 },
                    { 21, "Dolorem.", 4 },
                    { 22, "Repellat.", 13 },
                    { 23, "Nisi.", 5 },
                    { 24, "Magnam.", 2 },
                    { 25, "Rerum.", 9 },
                    { 26, "Optio.", 12 },
                    { 27, "Aut.", 19 },
                    { 28, "At.", 8 },
                    { 29, "Assumenda.", 1 },
                    { 30, "Perferendis.", 13 },
                    { 31, "Velit.", 18 },
                    { 32, "Quia.", 19 },
                    { 33, "Qui.", 7 },
                    { 34, "Ullam.", 10 },
                    { 35, "Maiores.", 9 },
                    { 36, "Eum.", 3 },
                    { 37, "Nobis.", 20 },
                    { 38, "Occaecati.", 8 },
                    { 39, "Amet.", 2 },
                    { 40, "Velit.", 12 },
                    { 41, "Necessitatibus.", 9 },
                    { 42, "Aperiam.", 2 },
                    { 43, "Quod.", 15 },
                    { 44, "Voluptatem.", 16 },
                    { 45, "Alias.", 18 },
                    { 46, "Deserunt.", 1 },
                    { 47, "Dolor.", 12 },
                    { 48, "Perspiciatis.", 1 },
                    { 49, "Sint.", 17 },
                    { 50, "Ab.", 16 }
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
