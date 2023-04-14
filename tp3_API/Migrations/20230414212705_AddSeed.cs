using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3_API.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-11111111", 0, "d54710fe-5c67-44a4-a096-40bac9ca87ee", "user1@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGf8jgFC32L7/m0nwujZLR0HAFSRlR/ZBTPtBwvfVen/JF7bFAJ6LbNlImtIFbxiyQ==", null, false, "8c8fcb39-eddd-4893-a433-b5fd7c2f2a31", false, "user1" },
                    { "11111111-1111-1111-1111-11111112", 0, "9df46c02-e2a4-4299-813b-22b391968069", "user2@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJ9TNUkOTfQF4I7BHVks+U5Cxi4kI+ssIa8OZ3s6S1zYcaWdHsb7R9a5ekM4Y285sQ==", null, false, "57862691-01af-43ed-9b21-3a285868beb0", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Galery",
                columns: new[] { "Id", "DefaultImage", "IsPublic", "Name" },
                values: new object[,]
                {
                    { 1, "/assets/images/galleryThumbnail.png", true, "Test Publique" },
                    { 2, "/assets/images/galleryThumbnail.png", false, "Test Privée" }
                });

            migrationBuilder.InsertData(
                table: "GaleryUser",
                columns: new[] { "AllowedUserId", "GaleryId" },
                values: new object[] { "11111111-1111-1111-1111-11111111", 1 });

            migrationBuilder.InsertData(
                table: "GaleryUser",
                columns: new[] { "AllowedUserId", "GaleryId" },
                values: new object[] { "11111111-1111-1111-1111-11111112", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GaleryUser",
                keyColumns: new[] { "AllowedUserId", "GaleryId" },
                keyValues: new object[] { "11111111-1111-1111-1111-11111111", 1 });

            migrationBuilder.DeleteData(
                table: "GaleryUser",
                keyColumns: new[] { "AllowedUserId", "GaleryId" },
                keyValues: new object[] { "11111111-1111-1111-1111-11111112", 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-11111112");

            migrationBuilder.DeleteData(
                table: "Galery",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Galery",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
