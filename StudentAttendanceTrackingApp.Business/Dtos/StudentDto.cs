
namespace StudentAttendanceTrackingApp.Business.Dtos
{
    public class StudentDto
    {
        // Automapper 1. adım Automapper ve AutoMapper.Extensions.Microsoft.DependencyInjection paketlerinin aynı versiyonlarla yüklenmesi
        // Automapper 2. adım Dto ların oluşturulması
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime CreaDate { get; set; }
    }
}
