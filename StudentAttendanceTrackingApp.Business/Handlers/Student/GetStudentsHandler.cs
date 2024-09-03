
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, Response<List<Student>>>
    {
        private readonly IStudentRepository studentRepository;
        public GetStudentsHandler(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        // bir handler ı illaki controller da çağırmak kullanmak zorunda değiliz. herhangi bir metod veya başka bir handlerda da bir handler ı çağırabiliriz mediatr
        // aracılığı ile. ayrıca bir tane değil birden fazla handler çağrılabilir.

        public async Task<Response<List<Student>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var students = await studentRepository.ListAsync(new GetStudentsReadonlySpec(), cancellationToken);
                return new Response<List<Student>>()
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = "Students retrieved successfully.",
                    Error = null,
                    Data = students
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Student>>()
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occurred while retrieving students.",
                    Error = ex.Message,
                    Data = null
                };
            }
            
        }
    }
}
