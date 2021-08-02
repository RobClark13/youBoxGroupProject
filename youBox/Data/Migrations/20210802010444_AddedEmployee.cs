using Microsoft.EntityFrameworkCore.Migrations;

namespace youBox.Data.Migrations
{
    public partial class AddedEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e84a49a-1735-48c0-981a-31ce052f4dad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75d77d80-f82e-47af-98a3-36c12b9760fe");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Package = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5cdab9e7-dbdb-4690-beb8-6e6a3aa9df6e", "082e64d8-d15f-46fa-9923-d905f9214dc4", "Subscriber", "SUBSCRIBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44d9dca6-c70d-484b-8613-fe97f4e154bd", "5c7cd2ae-ce2c-4d9c-8440-d3af975d95d7", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentityUserId",
                table: "Employees",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_IdentityUserId",
                table: "Subscribers",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44d9dca6-c70d-484b-8613-fe97f4e154bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cdab9e7-dbdb-4690-beb8-6e6a3aa9df6e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e84a49a-1735-48c0-981a-31ce052f4dad", "bea0c6d0-4a6f-4c6e-b986-84a054da6cf9", "Subscriber", "SUBSCRIBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75d77d80-f82e-47af-98a3-36c12b9760fe", "73d8cc22-b06d-4faf-bb05-c63b9a6cc58c", "Employee", "EMPLOYEE" });
        }
    }
}
