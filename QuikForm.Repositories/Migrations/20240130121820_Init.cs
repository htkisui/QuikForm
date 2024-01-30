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
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
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
                    { 1, null, null, new DateTime(2024, 1, 3, 15, 51, 19, 312, DateTimeKind.Unspecified).AddTicks(9198), "Iure dolorem qui inventore cum blanditiis fugiat rerum aliquid aliquid. Est excepturi quasi nesciunt omnis in asperiores non iusto. Est voluptatem est eveniet aut eum. Voluptatem ea voluptates est accusamus sunt commodi.", null, "Nesciunt commodi in delectus tempore.", new DateTime(2024, 1, 21, 12, 33, 53, 266, DateTimeKind.Unspecified).AddTicks(5039) },
                    { 2, null, null, new DateTime(2024, 1, 4, 12, 9, 16, 868, DateTimeKind.Unspecified).AddTicks(3934), "Ut sunt incidunt harum modi tempore officiis optio. Ratione voluptas ut aspernatur occaecati dolor architecto soluta. Est est dicta ad quo ipsa illum aspernatur. Et totam culpa dicta aliquam sapiente inventore in.", null, "Corrupti facilis dolor aut tenetur.", new DateTime(2024, 1, 30, 4, 31, 6, 647, DateTimeKind.Unspecified).AddTicks(6542) },
                    { 3, null, null, new DateTime(2024, 1, 1, 5, 1, 28, 562, DateTimeKind.Unspecified).AddTicks(5683), "Enim vel quia ratione earum ipsum quidem velit et. Quisquam nihil cupiditate. Ipsum quasi explicabo beatae possimus culpa occaecati perspiciatis et. Quia eos quasi. Non delectus ut voluptates dolor temporibus reprehenderit sit quasi.", null, "Eum suscipit officiis voluptatem molestiae.", new DateTime(2024, 1, 15, 11, 45, 59, 323, DateTimeKind.Unspecified).AddTicks(886) },
                    { 4, null, null, new DateTime(2024, 1, 1, 19, 7, 31, 145, DateTimeKind.Unspecified).AddTicks(8966), "Aliquam quod consequatur quia consequatur sed aliquam molestias nulla. Et quidem sequi maxime voluptatum reprehenderit laborum nihil sunt repellendus. Molestiae dolor qui et architecto et cum perferendis.", null, "Provident ipsum ex in voluptatem.", new DateTime(2024, 1, 28, 2, 25, 35, 493, DateTimeKind.Unspecified).AddTicks(2675) },
                    { 5, null, null, new DateTime(2024, 1, 1, 23, 56, 55, 882, DateTimeKind.Unspecified).AddTicks(4869), "Consectetur aut possimus. Aliquid voluptatem quisquam alias et exercitationem voluptatem commodi dolor. Sunt quibusdam ipsam sint perspiciatis sunt explicabo dolorem tempora. Debitis nihil et eaque et. Et dicta nesciunt eligendi libero amet. Illo nihil odit voluptas labore natus at amet.", null, "Cumque itaque ipsa illum ipsum.", new DateTime(2024, 1, 19, 17, 19, 13, 357, DateTimeKind.Unspecified).AddTicks(8229) }
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
                    { 1, 3, 4, false, "Impedit numquam vero ratione ipsa." },
                    { 2, 3, 2, false, "Odio modi quia ut distinctio." },
                    { 3, 2, 3, false, "Qui exercitationem tempore nostrum nobis." },
                    { 4, 1, 1, true, "Quae aspernatur tenetur reiciendis quaerat." },
                    { 5, 4, 2, false, "Quibusdam ut voluptatem consectetur accusamus." },
                    { 6, 4, 4, true, "Nihil et sunt aut exercitationem." },
                    { 7, 4, 2, true, "Numquam sapiente quia vel temporibus." },
                    { 8, 4, 4, true, "Iure id earum aut est." },
                    { 9, 5, 3, false, "Et fuga suscipit aliquid tenetur." },
                    { 10, 1, 1, true, "Non ut sint pariatur exercitationem." },
                    { 11, 3, 4, false, "Rerum omnis quaerat sed dolorem." },
                    { 12, 4, 1, true, "Consequuntur quia harum rerum omnis." },
                    { 13, 1, 1, true, "Dolorem provident eos iure minima." },
                    { 14, 5, 4, false, "Culpa ut eaque voluptates eius." },
                    { 15, 3, 4, false, "Debitis et ut omnis cumque." },
                    { 16, 5, 2, false, "Consequatur debitis et ipsum rerum." },
                    { 17, 3, 1, false, "Non quis similique est consequatur." },
                    { 18, 2, 4, false, "Labore voluptatibus quidem voluptatum voluptatum." },
                    { 19, 4, 2, false, "Aut et facere quisquam magni." },
                    { 20, 2, 2, false, "Nihil reiciendis voluptatibus nobis voluptatum." }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Label", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Et.", 7 },
                    { 2, "Exercitationem.", 16 },
                    { 3, "Accusamus.", 16 },
                    { 4, "Quasi.", 2 },
                    { 5, "Vel.", 4 },
                    { 6, "Quia.", 19 },
                    { 7, "Nihil.", 6 },
                    { 8, "Est.", 7 },
                    { 9, "Dicta.", 13 },
                    { 10, "Voluptatum.", 9 },
                    { 11, "Aut.", 12 },
                    { 12, "Non.", 4 },
                    { 13, "Hic.", 12 },
                    { 14, "In.", 4 },
                    { 15, "Eos.", 3 },
                    { 16, "Laborum.", 2 },
                    { 17, "Dolores.", 1 },
                    { 18, "Ut.", 15 },
                    { 19, "Cupiditate.", 9 },
                    { 20, "Aperiam.", 4 },
                    { 21, "Porro.", 5 },
                    { 22, "Recusandae.", 20 },
                    { 23, "Tenetur.", 16 },
                    { 24, "Eos.", 8 },
                    { 25, "Modi.", 3 },
                    { 26, "Impedit.", 18 },
                    { 27, "Quam.", 13 },
                    { 28, "Ut.", 7 },
                    { 29, "Excepturi.", 5 },
                    { 30, "Dolores.", 15 },
                    { 31, "Est.", 7 },
                    { 32, "Id.", 7 },
                    { 33, "Consequatur.", 9 },
                    { 34, "Veniam.", 9 },
                    { 35, "Aliquam.", 10 },
                    { 36, "Veritatis.", 19 },
                    { 37, "Nam.", 13 },
                    { 38, "Ducimus.", 18 },
                    { 39, "Aliquid.", 10 },
                    { 40, "Enim.", 20 },
                    { 41, "Enim.", 13 },
                    { 42, "Alias.", 3 },
                    { 43, "Incidunt.", 14 },
                    { 44, "Rerum.", 7 },
                    { 45, "Vitae.", 17 },
                    { 46, "Sit.", 1 },
                    { 47, "Quidem.", 1 },
                    { 48, "Neque.", 18 },
                    { 49, "Id.", 2 },
                    { 50, "Consequuntur.", 4 }
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
