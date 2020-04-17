using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiSample.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("48a103e8-e483-48a2-ae94-7a96af854cdb"), "Victor Hugo", "Hogo" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("56b0a249-d3b9-4e6e-9ada-68c9cd37b427"), "Lev", "Tolstoy" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Name" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("48a103e8-e483-48a2-ae94-7a96af854cdb"), "Notre Dame'ın Kamburu" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("48a103e8-e483-48a2-ae94-7a96af854cdb"), "Sefiller" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new Guid("56b0a249-d3b9-4e6e-9ada-68c9cd37b427"), "İnsan Ne İle Yaşar" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), new Guid("56b0a249-d3b9-4e6e-9ada-68c9cd37b427"), "Savaş ve Barış" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
