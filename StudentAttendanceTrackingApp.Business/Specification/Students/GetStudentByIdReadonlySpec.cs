
namespace StudentAttendanceTrackingApp.Business.Specification.Students
{
    public class GetStudentByIdReadonlySpec : Specification<Student>
    {
        public GetStudentByIdReadonlySpec(int id)
        {
            // bu class sayesinde bir çok kez yaptığımız id ile student getirme işlemini bir kez yapıp göstereceğimiz yerlerde sadece burayı çağırarak 
            // erişiriz.
            // query property si specification paketinden geliyor.
            Query.Where(x => x.Id == id).AsNoTracking(); // sadece okunacak bir şey (readonly) olduğu için asNoTracking kullanıyoruz.
            // x dediğimiz student ın (yani base aldığımız specification içindeki tip) bir kopyasıdır. student ın property lerine erişim sağlarız.
        }
    }


}
