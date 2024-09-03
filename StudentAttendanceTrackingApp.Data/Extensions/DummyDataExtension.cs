
namespace StudentAttendanceTrackingApp.Data.Extensions
{
    public static class DummyDataExtension
    {
        static Random random = new Random();
        public static void CreateData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(StudentsData());
            modelBuilder.Entity<Lesson>().HasData(LessonsData());
            modelBuilder.Entity<ApiUser>().HasData(ApiUsersData());
        }

        public static List<Student> StudentsData()
        {
            //var students = new List<Student>();
            //{
            //    new Student { Id = 1, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 2), DateTimeKind.Utc), FirstName = "Ali", LastName = "Yılmaz", BirthDate = DateTime.SpecifyKind(new DateTime(2000, 1, 15), DateTimeKind.Utc), Email = "ali.yilmaz@hotmail.com", City = "Istanbul" },
            //    new Student { Id = 2, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 4), DateTimeKind.Utc), FirstName = "Ayşe", LastName = "Kaya", BirthDate = DateTime.SpecifyKind(new DateTime(2001, 3, 22), DateTimeKind.Utc), Email = "ayse.kaya@hotmail.com", City = "Ankara" },
            //    new Student { Id = 3, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 7), DateTimeKind.Utc), FirstName = "Mehmet", LastName = "Demir", BirthDate = DateTime.SpecifyKind(new DateTime(1999, 11, 30), DateTimeKind.Utc), Email = "mehmet.demir@hotmail.com", City = "Izmir" },
            //    new Student { Id = 4, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 8), DateTimeKind.Utc), FirstName = "Fatma", LastName = "Çelik", BirthDate = DateTime.SpecifyKind(new DateTime(2002, 5, 5), DateTimeKind.Utc), Email = "fatma.celik@hotmail.com", City = "Bursa" },
            //    new Student { Id = 5, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 9), DateTimeKind.Utc), FirstName = "Ahmet", LastName = "Yıldız", BirthDate = DateTime.SpecifyKind(new DateTime(2000, 8, 18), DateTimeKind.Utc), Email = "ahmet.yildiz@hotmail.com", City = "Antalya" },
            //    new Student { Id = 6, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 10), DateTimeKind.Utc), FirstName = "Elif", LastName = "Arslan", BirthDate = DateTime.SpecifyKind(new DateTime(2003, 7, 10), DateTimeKind.Utc), Email = "elif.arslan@hotmail.com", City = "Adana" },
            //    new Student { Id = 7, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 14), DateTimeKind.Utc), FirstName = "Murat", LastName = "Koç", BirthDate = DateTime.SpecifyKind(new DateTime(1998, 9, 14), DateTimeKind.Utc), Email = "murat.koc@hotmail.com", City = "Konya" },
            //    new Student { Id = 8, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 15), DateTimeKind.Utc), FirstName = "Zeynep", LastName = "Aydın", BirthDate = DateTime.SpecifyKind(new DateTime(2001, 12, 19), DateTimeKind.Utc), Email = "zeynep.aydin@hotmail.com", City = "Samsun" },
            //    new Student { Id = 9, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 15), DateTimeKind.Utc), FirstName = "Hasan", LastName = "Öztürk", BirthDate = DateTime.SpecifyKind(new DateTime(1997, 6, 21), DateTimeKind.Utc), Email = "hasan.ozturk@hotmail.com", City = "Kayseri" },
            //    new Student { Id = 10, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 16), DateTimeKind.Utc), FirstName = "Emine", LastName = "Çakır", BirthDate = DateTime.SpecifyKind(new DateTime(2004, 4, 11), DateTimeKind.Utc), Email = "emine.cakir@hotmail.com", City = "Eskişehir" },
            //    new Student { Id = 11, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 18), DateTimeKind.Utc), FirstName = "Berk", LastName = "Polat", BirthDate = DateTime.SpecifyKind(new DateTime(2002, 2, 25), DateTimeKind.Utc), Email = "berk.polat@hotmail.com", City = "Trabzon" },
            //    new Student { Id = 12, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 21), DateTimeKind.Utc), FirstName = "Deniz", LastName = "Şahin", BirthDate = DateTime.SpecifyKind(new DateTime(2000, 10, 16), DateTimeKind.Utc), Email = "deniz.sahin@hotmail.com", City = "Mersin" },
            //    new Student { Id = 13, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 21), DateTimeKind.Utc), FirstName = "Seda", LastName = "Kurt", BirthDate = DateTime.SpecifyKind(new DateTime(2001, 1, 8), DateTimeKind.Utc), Email = "seda.kurt@hotmail.com", City = "Gaziantep" },
            //    new Student { Id = 14, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 25), DateTimeKind.Utc), FirstName = "Merve", LastName = "Erdoğan", BirthDate = DateTime.SpecifyKind(new DateTime(1999, 11, 27), DateTimeKind.Utc), Email = "merve.erdogan@hotmail.com", City = "Şanlıurfa" },
            //    new Student { Id = 15, IsDeleted = false, CreaDate = DateTime.SpecifyKind(new DateTime(2024, 8, 27), DateTimeKind.Utc), FirstName = "Hüseyin", LastName = "Bozkurt", BirthDate = DateTime.SpecifyKind(new DateTime(2003, 5, 3), DateTimeKind.Utc), Email = "huseyin.bozkurt@hotmail.com", City = "Diyarbakır" },
            //};

            var countStudent = 15;
            var autoId = 0;
            var nameList = new List<string>();
            var lastnameList = new List<string>();
            var cityList = new List<string>();
            var startDate = new DateTime(1970, 1, 1);
            var endDate = new DateTime(2015, 12, 31);
            int totalDays = (endDate - startDate).Days;

            using (StreamReader reader = new StreamReader(@"C:\Users\TT\source\repos\StudentAttendanceTrackingApp\StudentAttendanceTrackingApp.Data\Names.txt"))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {                    
                    nameList.Add(line);
                }
            }

            using (StreamReader reader = new StreamReader(@"C:\Users\TT\source\repos\StudentAttendanceTrackingApp\StudentAttendanceTrackingApp.Data\LastNames.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lastnameList.Add(line);
                }
            }

            using (StreamReader reader = new StreamReader(@"C:\Users\TT\source\repos\StudentAttendanceTrackingApp\StudentAttendanceTrackingApp.Data\Cities.txt"))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    cityList.Add(line);
                }
            }

            var list = new List<Student>();

            for (int i = 1; i <= countStudent; i++)
            {
                autoId++;
                var randomNumberNames = random.Next(0, nameList.Count);
                var randomNumberLastNames = random.Next(0, lastnameList.Count);
                var randomNumberCities = random.Next(0, cityList.Count);
                var randomNumberDate = random.Next(totalDays + 1); // endDate in dahil edilmesi için +1
                var randomDate = startDate.AddDays(randomNumberDate).ToUniversalTime();


                var firstname = nameList[randomNumberNames];
                var lastname = lastnameList[randomNumberLastNames];
                Student student = new Student()
                {
                    Id = autoId,
                    FirstName = firstname,
                    LastName = lastname,
                    City = cityList[randomNumberCities],
                    BirthDate = randomDate,
                    Email = $"{firstname.ToLower()}.{lastname.ToLower()}.{randomDate.Year.ToString().Substring(2, 2)}@hotmail.com",
                    CreaDate = DateTime.UtcNow,
                    IsDeleted = false
                };

                list.Add(student);
            }

            return list;

        }

        public static List<Lesson> LessonsData()
        {
            var lessons = new List<Lesson>();
            //{
            //    new Lesson { IsDeleted = false, Id = 1, Name = "Matematik" },
            //    new Lesson { IsDeleted = false, Id = 2, Name = "Fizik" },
            //    new Lesson { IsDeleted = false, Id = 3, Name = "Kimya" },
            //    new Lesson { IsDeleted = false, Id = 4, Name = "Biyoloji" },
            //    new Lesson { IsDeleted = false, Id = 5, Name = "Tarih" },
            //    new Lesson { IsDeleted = false, Id = 6, Name = "Coğrafya" },
            //    new Lesson { IsDeleted = false, Id = 7, Name = "İngilizce" },
            //    new Lesson { IsDeleted = false, Id = 8, Name = "Edebiyat" },
            //    new Lesson { IsDeleted = false, Id = 9, Name = "Bilgisayar Bilimleri" },
            //    new Lesson { IsDeleted = false, Id = 10, Name = "Beden Eğitimi" },
            //};

            var lessonNameList = new List<string>();

            using (StreamReader reader = new StreamReader(@"C:\Users\TT\source\repos\StudentAttendanceTrackingApp\StudentAttendanceTrackingApp.Data\Lessons.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lessonNameList.Add(line);
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                var lesson = new Lesson();
                lesson.Id = i;
                lesson.Name = lessonNameList[i-1];
                lesson.CreaDate = DateTime.UtcNow;
                lesson.IsDeleted = false;

                lessons.Add(lesson);
            }

            return lessons;
        }

        public static List<ApiUser> ApiUsersData()
        {
            var users = new List<ApiUser>
            {
                new ApiUser
                {
                    Id = 1,
                    UserName = "jdoe",
                    Password = "password123",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com",
                    Phone = "+1234567890",
                    Company = "Tech Solutions",
                    IsDeleted = false,
                    CreaDate = DateTime.SpecifyKind(new DateTime(2023, 1, 15), DateTimeKind.Utc)
                },
                new ApiUser
                {
                    Id = 2,
                    UserName = "asmith",
                    Password = "securepass456",
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alicesmith@example.com",
                    Phone = "+0987654321",
                    Company = "Innovatech",
                    IsDeleted = false,
                    CreaDate = DateTime.SpecifyKind(new DateTime(2023, 2, 20), DateTimeKind.Utc)
                },
                new ApiUser
                {
                    Id = 3,
                    UserName = "bmiller",
                    Password = "mypassword789",
                    FirstName = "Bob",
                    LastName = "Miller",
                    Email = "bobmiller@example.com",
                    Phone = "+1122334455",
                    Company = "Future Tech",
                    IsDeleted = false,
                    CreaDate = DateTime.SpecifyKind(new DateTime(2023, 3, 10), DateTimeKind.Utc)
                },
                new ApiUser
                {
                    Id = 4,
                    UserName = "cjohnson",
                    Password = "pass1234",
                    FirstName = "Charlie",
                    LastName = "Johnson",
                    Email = "charliejohnson@example.com",
                    Phone = "+6677889900",
                    Company = "Tech Innovators",
                    IsDeleted = false,
                    CreaDate = DateTime.SpecifyKind(new DateTime(2023, 4, 5), DateTimeKind.Utc)
                },
                new ApiUser
                {
                    Id = 5,
                    UserName = "ddavis",
                    Password = "password321",
                    FirstName = "Diana",
                    LastName = "Davis",
                    Email = "dianadavis@example.com",
                    Phone = "+4455667788",
                    Company = "NextGen Tech",
                    IsDeleted = false,
                    CreaDate = DateTime.SpecifyKind(new DateTime(2023, 5, 25), DateTimeKind.Utc)
                }
            };

            return users;
        }
    }
}
