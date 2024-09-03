
namespace StudentAttendanceTrackingApp.Business.Repositories.Abstracts
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Task<int> GetMaxId(CancellationToken cancellationToken);
    }
}
