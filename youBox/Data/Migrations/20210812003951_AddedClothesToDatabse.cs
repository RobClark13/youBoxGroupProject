using Microsoft.EntityFrameworkCore.Migrations;

namespace youBox.Data.Migrations
{
    public partial class AddedClothesToDatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69fe1de2-c763-4849-8aa0-14749c0ef57c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97407ce3-076c-4c24-9967-f0e529ad40ae");

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12ea0260-abd7-48c1-8c1c-47c87d940c16", "a872dedf-6047-41b5-b86d-187c9a7d04f8", "Subscriber", "SUBSCRIBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac8e30df-3f41-40af-9e11-caef10694cf7", "ccb57974-e81f-4fa8-9b24-5518c06d53ff", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12ea0260-abd7-48c1-8c1c-47c87d940c16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac8e30df-3f41-40af-9e11-caef10694cf7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97407ce3-076c-4c24-9967-f0e529ad40ae", "80b7045b-eff8-438a-b9c3-2ee3950e7be8", "Subscriber", "SUBSCRIBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69fe1de2-c763-4849-8aa0-14749c0ef57c", "3b1cc473-de90-438b-806a-ca5718db3a17", "Employee", "EMPLOYEE" });
        }
    }
}
