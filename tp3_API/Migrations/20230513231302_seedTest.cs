using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3_API.Migrations
{
    public partial class seedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0aed697d-36c3-44bb-86b4-cd2cb5b3cec6", "AQAAAAEAACcQAAAAEAa3czd+Q4W3yWosM55HbtKVXb+GMKyZyI7iQsE8JVIcdhT0E0GUfthYQSiNtG696A==", "8805e8d6-9786-4b7c-8f2c-d4a066c3fa38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9c92eca-0996-4fad-8570-8f6ca282f4e3", "AQAAAAEAACcQAAAAECnPk415/3zRS931AAV4xLrxMmVhgh3ROy9y7I5ZMFDRJXqgJlXRXae95KLdbQGUBQ==", "def9895b-aa92-4685-8916-0fccc1e17c3d" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FileName", "GaleryId", "MimeType" },
                values: new object[] { 1, "11111111-1111-1111-1111-111111111111.jpg", 1, "image/jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "244f72e6-2807-4f5d-b2c8-9f98a9af756e", "AQAAAAEAACcQAAAAEBBxG97ob9sSXUMI9ZYrAyG1F+j/jNaDph5h0JPXYBfhe3MbFpkVYy2XXwFEKF7jCQ==", "b3d522cc-0ec1-4c5f-853b-a21937d2ea81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8305ac18-cbe4-426d-91b1-7e51bb206ac2", "AQAAAAEAACcQAAAAEMJE8o0uqWKfIX5cqbZlbd90qU7ximKfXHhDIYC2PvFQHZeIm2y9JTk1S+LmXq6Yfw==", "57cca29e-c5b1-4c70-837c-5720843062f4" });
        }
    }
}
