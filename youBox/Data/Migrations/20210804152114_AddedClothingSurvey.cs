using Microsoft.EntityFrameworkCore.Migrations;

namespace youBox.Data.Migrations
{
    public partial class AddedClothingSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44d9dca6-c70d-484b-8613-fe97f4e154bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cdab9e7-dbdb-4690-beb8-6e6a3aa9df6e");

            migrationBuilder.CreateTable(
                name: "ClothingSurveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question1 = table.Column<int>(nullable: false),
                    Question2 = table.Column<int>(nullable: false),
                    Question3 = table.Column<int>(nullable: false),
                    Question4 = table.Column<int>(nullable: false),
                    Question5 = table.Column<int>(nullable: false),
                    Question6 = table.Column<int>(nullable: false),
                    Question7 = table.Column<int>(nullable: false),
                    SubscriberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingSurveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingSurveys_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97407ce3-076c-4c24-9967-f0e529ad40ae", "80b7045b-eff8-438a-b9c3-2ee3950e7be8", "Subscriber", "SUBSCRIBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69fe1de2-c763-4849-8aa0-14749c0ef57c", "3b1cc473-de90-438b-806a-ca5718db3a17", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingSurveys_SubscriberId",
                table: "ClothingSurveys",
                column: "SubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingSurveys");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69fe1de2-c763-4849-8aa0-14749c0ef57c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97407ce3-076c-4c24-9967-f0e529ad40ae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5cdab9e7-dbdb-4690-beb8-6e6a3aa9df6e", "082e64d8-d15f-46fa-9923-d905f9214dc4", "Subscriber", "SUBSCRIBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44d9dca6-c70d-484b-8613-fe97f4e154bd", "5c7cd2ae-ce2c-4d9c-8440-d3af975d95d7", "Employee", "EMPLOYEE" });
        }
    }
}
