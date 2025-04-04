using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimplyBooksBEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    firebaseKey = table.Column<string>(type: "text", nullable: false),
                    UserUid = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    favorite = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.firebaseKey);
                    table.ForeignKey(
                        name: "FK_Authors_Users_UserUid",
                        column: x => x.UserUid,
                        principalTable: "Users",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    firebaseKey = table.Column<string>(type: "text", nullable: false),
                    UserUid = table.Column<string>(type: "text", nullable: false),
                    AuthorFirebaseKey = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: true),
                    sale = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.firebaseKey);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorFirebaseKey",
                        column: x => x.AuthorFirebaseKey,
                        principalTable: "Authors",
                        principalColumn: "firebaseKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserUid",
                        column: x => x.UserUid,
                        principalTable: "Users",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                column: "uid",
                values: new object[]
                {
                    "user1",
                    "user2"
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "firebaseKey", "UserUid", "email", "favorite", "first_name", "last_name" },
                values: new object[,]
                {
                    { "author1", "user1", "maxlucado@example.com", true, "Max", "Lucado" },
                    { "author2", "user2", "francinerivers@example.com", true, "Francine", "Rivers" },
                    { "author3", "user1", "karenkingsbury@example.com", false, "Karen", "Kingsbury" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "firebaseKey", "AuthorFirebaseKey", "UserUid", "description", "image", "price", "sale", "title" },
                values: new object[,]
                {
                    { "book1", "author1", "user1", "A devotional book filled with insights and reflections for daily living.", "image_url1", 12.99m, true, "Grace for the Moment" },
                    { "book2", "author2", "user2", "A Christian retelling of the biblical story of Hosea and Gomer.", "image_url2", 14.99m, false, "Redeeming Love" },
                    { "book3", "author3", "user1", "A novel that explores faith, love, and the healing power of relationships.", "image_url3", 10.99m, true, "The Bridge" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UserUid",
                table: "Authors",
                column: "UserUid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorFirebaseKey",
                table: "Books",
                column: "AuthorFirebaseKey");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserUid",
                table: "Books",
                column: "UserUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
