
namespace StudentAttendanceTrackingApp.Business.Queries.Student
{
    public class GetStudentsWithPaginationQuery : IRequest<Response<List<StudentDto>>>
    {
        // pagination adım 1
        public int PageIndex { get; set; } = 1; // kaçıncı sayfa, hiç veri girilmezse ilk sayfadan 10 veri diye ayarlandı
        public int TotalCount { get; set; } = 10; // kaç kişi

        // örn. ilk 5 kişiyi atla 2. sayfada 5 kişiyi getir -> index 2 count 5
        // örn. ilk 10 kişiyi getir -> index 1 count 10
    }
}
