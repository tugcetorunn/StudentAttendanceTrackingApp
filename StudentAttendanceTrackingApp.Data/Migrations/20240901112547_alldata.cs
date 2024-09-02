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
                    { 1, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6111), false, "Matematik" },
                    { 2, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6119), false, "Fizik" },
                    { 3, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6120), false, "Kimya" },
                    { 4, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6121), false, "Biyoloji" },
                    { 5, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6122), false, "Tarih" },
                    { 6, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6126), false, "Coğrafya" },
                    { 7, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6127), false, "İngilizce" },
                    { 8, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6128), false, "Edebiyat" },
                    { 9, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6129), false, "Bilgisayar Bilimleri" },
                    { 10, new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(6132), false, "Beden Eğitimi" }
                });

            migrationBuilder.InsertData(
                schema: "satapp",
                table: "Students",
                columns: new[] { "Id", "BirthDate", "City", "CreaDate", "Email", "FirstName", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 4, 11, 21, 0, 0, 0, DateTimeKind.Utc), "Iğdır", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9834), "tuğra.yıldız.88@hotmail.com", "Tuğra", false, "Yıldız" },
                    { 2, new DateTime(2005, 3, 23, 22, 0, 0, 0, DateTimeKind.Utc), "Sakarya", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9854), "hande.derici.05@hotmail.com", "Hande", false, "Derici" },
                    { 3, new DateTime(1998, 11, 27, 22, 0, 0, 0, DateTimeKind.Utc), "Şanlıurfa", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9866), "kaan.yurt.98@hotmail.com", "Kaan", false, "Yurt" },
                    { 4, new DateTime(2012, 12, 4, 22, 0, 0, 0, DateTimeKind.Utc), "Bayburt", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9878), "yağmur.kaya.12@hotmail.com", "Yağmur", false, "Kaya" },
                    { 5, new DateTime(1980, 10, 27, 22, 0, 0, 0, DateTimeKind.Utc), "Kilis", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9888), "hande.boz.80@hotmail.com", "Hande", false, "Boz" },
                    { 6, new DateTime(1975, 12, 22, 22, 0, 0, 0, DateTimeKind.Utc), "İzmir", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9902), "yeşim.yüce.75@hotmail.com", "Yeşim", false, "Yüce" },
                    { 7, new DateTime(1973, 5, 31, 21, 0, 0, 0, DateTimeKind.Utc), "Nevşehir", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9911), "cansu.yurt.73@hotmail.com", "Cansu", false, "Yurt" },
                    { 8, new DateTime(1972, 9, 7, 21, 0, 0, 0, DateTimeKind.Utc), "Mardin", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9921), "mehmet.ergen.72@hotmail.com", "Mehmet", false, "Ergen" },
                    { 9, new DateTime(2009, 1, 14, 22, 0, 0, 0, DateTimeKind.Utc), "Nevşehir", new DateTime(2024, 9, 1, 11, 25, 46, 913, DateTimeKind.Utc).AddTicks(9930), "yağmur.sayan.09@hotmail.com", "Yağmur", false, "Sayan" },
                    { 10, new DateTime(1999, 12, 10, 22, 0, 0, 0, DateTimeKind.Utc), "Mardin", new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(92), "kaan.yurt.99@hotmail.com", "Kaan", false, "Yurt" },
                    { 11, new DateTime(1985, 1, 23, 22, 0, 0, 0, DateTimeKind.Utc), "Sakarya", new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(102), "utku.yar.85@hotmail.com", "Utku", false, "Yar" },
                    { 12, new DateTime(1989, 12, 21, 22, 0, 0, 0, DateTimeKind.Utc), "Osmaniye", new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(112), "osman.öztürk.89@hotmail.com", "Osman", false, "Öztürk" },
                    { 13, new DateTime(1978, 5, 30, 21, 0, 0, 0, DateTimeKind.Utc), "Zonguldak", new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(120), "kaan.derici.78@hotmail.com", "Kaan", false, "Derici" },
                    { 14, new DateTime(1982, 9, 12, 21, 0, 0, 0, DateTimeKind.Utc), "Trabzon", new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(129), "buğra.yener.82@hotmail.com", "Buğra", false, "Yener" },
                    { 15, new DateTime(2010, 1, 31, 22, 0, 0, 0, DateTimeKind.Utc), "İzmir", new DateTime(2024, 9, 1, 11, 25, 46, 914, DateTimeKind.Utc).AddTicks(138), "mehmet.yıldız.10@hotmail.com", "Mehmet", false, "Yıldız" }
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
