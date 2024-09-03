
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
                    CreaDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                    CreaDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                    CreaDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                    { 1, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6638), false, "Matematik" },
                    { 2, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6648), false, "Fizik" },
                    { 3, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6650), false, "Kimya" },
                    { 4, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6651), false, "Biyoloji" },
                    { 5, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6652), false, "Tarih" },
                    { 6, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6657), false, "Coğrafya" },
                    { 7, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6658), false, "İngilizce" },
                    { 8, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6659), false, "Edebiyat" },
                    { 9, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6660), false, "Bilgisayar Bilimleri" },
                    { 10, new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(6663), false, "Beden Eğitimi" }
                });

            migrationBuilder.InsertData(
                schema: "satapp",
                table: "Students",
                columns: new[] { "Id", "BirthDate", "City", "CreaDate", "Email", "FirstName", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1981, 2, 16, 22, 0, 0, 0, DateTimeKind.Utc), "Eskişehir", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(4899), "yağmur.tilbe.81@hotmail.com", "Yağmur", false, "Tilbe" },
                    { 2, new DateTime(1980, 11, 1, 22, 0, 0, 0, DateTimeKind.Utc), "Yalova", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(4927), "kaan.tilbe.80@hotmail.com", "Kaan", false, "Tilbe" },
                    { 3, new DateTime(2000, 12, 30, 22, 0, 0, 0, DateTimeKind.Utc), "Edirne", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(4939), "hasan.yıldız.00@hotmail.com", "Hasan", false, "Yıldız" },
                    { 4, new DateTime(2005, 9, 28, 21, 0, 0, 0, DateTimeKind.Utc), "Zonguldak", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(4949), "utku.yurt.05@hotmail.com", "Utku", false, "Yurt" },
                    { 5, new DateTime(2000, 12, 24, 22, 0, 0, 0, DateTimeKind.Utc), "Kilis", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(4959), "buğra.aksu.00@hotmail.com", "Buğra", false, "Aksu" },
                    { 6, new DateTime(1970, 12, 2, 22, 0, 0, 0, DateTimeKind.Utc), "Bilecik", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(4973), "veli.aksu.70@hotmail.com", "Veli", false, "Aksu" },
                    { 7, new DateTime(1999, 3, 9, 22, 0, 0, 0, DateTimeKind.Utc), "Muş", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(4984), "hakan.derici.99@hotmail.com", "Hakan", false, "Derici" },
                    { 8, new DateTime(1984, 11, 6, 22, 0, 0, 0, DateTimeKind.Utc), "Bartın", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(4993), "osman.kaya.84@hotmail.com", "Osman", false, "Kaya" },
                    { 9, new DateTime(2000, 7, 21, 21, 0, 0, 0, DateTimeKind.Utc), "Burdur", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(5003), "buğra.aslan.00@hotmail.com", "Buğra", false, "Aslan" },
                    { 10, new DateTime(1975, 6, 21, 21, 0, 0, 0, DateTimeKind.Utc), "Ankara", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(5081), "sedef.yurt.75@hotmail.com", "Sedef", false, "Yurt" },
                    { 11, new DateTime(2010, 1, 21, 22, 0, 0, 0, DateTimeKind.Utc), "Samsun", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(5091), "osman.derici.10@hotmail.com", "Osman", false, "Derici" },
                    { 12, new DateTime(2006, 6, 26, 21, 0, 0, 0, DateTimeKind.Utc), "Kilis", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(5102), "yeşim.deniz.06@hotmail.com", "Yeşim", false, "Deniz" },
                    { 13, new DateTime(1978, 8, 18, 21, 0, 0, 0, DateTimeKind.Utc), "Bitlis", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(5111), "barış.yar.78@hotmail.com", "Barış", false, "Yar" },
                    { 14, new DateTime(1987, 11, 19, 22, 0, 0, 0, DateTimeKind.Utc), "Adıyaman", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(5120), "hakan.yıldız.87@hotmail.com", "Hakan", false, "Yıldız" },
                    { 15, new DateTime(1994, 11, 4, 22, 0, 0, 0, DateTimeKind.Utc), "Eskişehir", new DateTime(2024, 9, 2, 19, 53, 30, 455, DateTimeKind.Utc).AddTicks(5130), "kaan.soy.94@hotmail.com", "Kaan", false, "Soy" }
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
