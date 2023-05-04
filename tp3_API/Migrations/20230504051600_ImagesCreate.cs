using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3_API.Migrations
{
    public partial class ImagesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultImage",
                table: "Galery");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Galery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Galery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaleryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Galery_GaleryId",
                        column: x => x.GaleryId,
                        principalTable: "Galery",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ef7cbad-da84-4243-8adc-b402162f5043", "AQAAAAEAACcQAAAAEFvmhv4EM1sTnW/hjtDzDt7ob3icI6TSP7F7Hby1GMuC2/EDLHSU+Bm0CwMFXKj6lA==", "7b7ce327-8e59-46c3-8dbc-38d988df7366" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2372cdc-f6fc-4b4d-80c7-c0d40ca71ec2", "AQAAAAEAACcQAAAAEFWAfAmQ19+FilAG/cW2/4skfgLnqoDpPrL4s1nrf49o0WYrClhX4weMNFI+AoR38Q==", "34f67cac-a078-4c43-bf31-2c85b55d3855" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_GaleryId",
                table: "Images",
                column: "GaleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Galery");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "Galery");

            migrationBuilder.AddColumn<string>(
                name: "DefaultImage",
                table: "Galery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c9724dc-299f-42ec-ad15-cad06239f4b1", "AQAAAAEAACcQAAAAEOGCKbVr0xiIdl2jX/wIxvFmi4PIWxHkHb7oursmrNZOJkcJws0YqFLzDf10zEe33g==", "49e7d854-7437-45e2-a19d-3bfdc9d504bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d3ad7de-6885-4a5a-8708-e345e8fb53a7", "AQAAAAEAACcQAAAAEGaoa2OHyp1RIaaEIJprn693PEa1ri4MeD9pnrSyhPX1kgnvWXwciMpj318eIoOXfQ==", "6a088b3c-bc83-41b3-8ab1-944b1eba210c" });

            migrationBuilder.UpdateData(
                table: "Galery",
                keyColumn: "Id",
                keyValue: 1,
                column: "DefaultImage",
                value: "/assets/images/galleryThumbnail.png");

            migrationBuilder.UpdateData(
                table: "Galery",
                keyColumn: "Id",
                keyValue: 2,
                column: "DefaultImage",
                value: "/assets/images/galleryThumbnail.png");
        }
    }
}
