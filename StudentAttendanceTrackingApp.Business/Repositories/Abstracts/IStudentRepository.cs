
namespace StudentAttendanceTrackingApp.Business.Repositories.Abstracts
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<int> GetMaxId(CancellationToken cancellationToken);

        // diğer crud işlemlerini repository de tanımlamaya gerek yok çünkü ardalis ten gelen bu repository yapısının içeriğine baktığımızda metodlar zaten
        // halihazırda geliyor. bunların dışında başka metodlara ihtiyaç duyarsak buraya ekleme yapabiliriz.
    }
}
