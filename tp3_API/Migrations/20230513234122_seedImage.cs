using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3_API.Migrations
{
    public partial class seedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ac879a4-603a-487c-8646-27b3edea98d2", "AQAAAAEAACcQAAAAEOqhHVXY+OCrQwtvYXGhZ0JZ7o5yaQ71CJVjIkJsIDiGS8roKpMGG3GDx5/vhuaWWA==", "c1a19a32-5dd6-45fb-85ee-09680f871ec8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9796d95e-ed4f-48e0-a819-f06f89a8b758", "AQAAAAEAACcQAAAAEH+tbzRiWsu9U2aIc5/5lrQxXiI0A2SVUFpUVSeUX3T/LsZ8wIAfF/kc3HDKo1u7ww==", "8889564e-a60e-474d-9ed1-960b73ca4292" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
