using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3_API.Migrations
{
    public partial class SecondSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c9724dc-299f-42ec-ad15-cad06239f4b1", "USER1@GMAIL.COM", "USER1", "AQAAAAEAACcQAAAAEOGCKbVr0xiIdl2jX/wIxvFmi4PIWxHkHb7oursmrNZOJkcJws0YqFLzDf10zEe33g==", "49e7d854-7437-45e2-a19d-3bfdc9d504bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111112",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d3ad7de-6885-4a5a-8708-e345e8fb53a7", "USER2@GMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEGaoa2OHyp1RIaaEIJprn693PEa1ri4MeD9pnrSyhPX1kgnvWXwciMpj318eIoOXfQ==", "6a088b3c-bc83-41b3-8ab1-944b1eba210c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d54710fe-5c67-44a4-a096-40bac9ca87ee", null, null, "AQAAAAEAACcQAAAAEGf8jgFC32L7/m0nwujZLR0HAFSRlR/ZBTPtBwvfVen/JF7bFAJ6LbNlImtIFbxiyQ==", "8c8fcb39-eddd-4893-a433-b5fd7c2f2a31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111112",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9df46c02-e2a4-4299-813b-22b391968069", null, null, "AQAAAAEAACcQAAAAEJ9TNUkOTfQF4I7BHVks+U5Cxi4kI+ssIa8OZ3s6S1zYcaWdHsb7R9a5ekM4Y285sQ==", "57862691-01af-43ed-9b21-3a285868beb0" });
        }
    }
}
