using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAttendanceTrackingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class alldata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "satapp");

            migrationBuilder.CreateTable(
                name: "ApiUsers",
                schema: "satapp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreaDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                schema: "satapp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreaDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "satapp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreaDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "satapp",
                table: "ApiUsers",
                columns: new[] { "Id", "Company", "CreaDate", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "UserName" },
                values: new object[,]
                {
                    { 1, "Tech Solutions", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "johndoe@example.com", "John", false, "Doe", "password123", "+1234567890", "jdoe" },
                    { 2, "Innovatech", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), "alicesmith@example.com", "Alice", false, "Smith", "securepass456", "+0987654321", "asmith" },
                    { 3, "Future Tech", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "bobmiller@example.com", "Bob", false, "Miller", "mypassword789", "+1122334455", "bmiller" },
                    { 4, "Tech Innovators", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "charliejohnson@example.com", "Charlie", false, "Johnson", "pass1234", "+6677889900", "cjohnson" },
                    { 5, "NextGen Tech", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "dianadavis@example.com", "Diana", false, "Davis", "password321", "+4455667788", "ddavis" }
                });

            migrationBuilder.InsertData(
                schema: "satapp",
                table: "Lesson",
                columns: new[] { "Id", "CreaDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Matematik" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Fizik" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kimya" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Biyoloji" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tarih" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Coğrafya" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "İngilizce" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Edebiyat" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bilgisayar Bilimleri" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Beden Eğitimi" }
                });

            migrationBuilder.InsertData(
                schema: "satapp",
                table: "Students",
                columns: new[] { "Id", "BirthDate", "City", "CreaDate", "Email", "FirstName", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Istanbul", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), "ali.yilmaz@hotmail.com", "Ali", false, "Yılmaz" },
                    { 2, new DateTime(2001, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Ankara", new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc), "ayse.kaya@hotmail.com", "Ayşe", false, "Kaya" },
                    { 3, new DateTime(1999, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Izmir", new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "mehmet.demir@hotmail.com", "Mehmet", false, "Demir" },
                    { 4, new DateTime(2002, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Bursa", new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "fatma.celik@hotmail.com", "Fatma", false, "Çelik" },
                    { 5, new DateTime(2000, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Antalya", new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Utc), "ahmet.yildiz@hotmail.com", "Ahmet", false, "Yıldız" },
                    { 6, new DateTime(2003, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Adana", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "elif.arslan@hotmail.com", "Elif", false, "Arslan" },
                    { 7, new DateTime(1998, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Konya", new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), "murat.koc@hotmail.com", "Murat", false, "Koç" },
                    { 8, new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Samsun", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "zeynep.aydin@hotmail.com", "Zeynep", false, "Aydın" },
                    { 9, new DateTime(1997, 6, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Kayseri", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "hasan.ozturk@hotmail.com", "Hasan", false, "Öztürk" },
                    { 10, new DateTime(2004, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Eskişehir", new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), "emine.cakir@hotmail.com", "Emine", false, "Çakır" },
                    { 11, new DateTime(2002, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Trabzon", new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), "berk.polat@hotmail.com", "Berk", false, "Polat" },
                    { 12, new DateTime(2000, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Mersin", new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc), "deniz.sahin@hotmail.com", "Deniz", false, "Şahin" },
                    { 13, new DateTime(2001, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Gaziantep", new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc), "seda.kurt@hotmail.com", "Seda", false, "Kurt" },
                    { 14, new DateTime(1999, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Şanlıurfa", new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), "merve.erdogan@hotmail.com", "Merve", false, "Erdoğan" },
                    { 15, new DateTime(2003, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Diyarbakır", new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc), "huseyin.bozkurt@hotmail.com", "Hüseyin", false, "Bozkurt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiUsers",
                schema: "satapp");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "satapp");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "satapp");
        }
    }
}
