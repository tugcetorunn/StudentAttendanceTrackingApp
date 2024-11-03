
using System.Net;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, Response<List<StudentDto>>>
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public GetStudentsHandler(IStudentRepository _studentRepository, IMapper _mapper)
        {
            studentRepository = _studentRepository;
            mapper = _mapper;
        }

        // bir handler ı illaki controller da çağırmak kullanmak zorunda değiliz. herhangi bir metod veya başka bir handlerda da bir handler ı çağırabiliriz mediatr
        // aracılığı ile. ayrıca bir tane değil birden fazla handler çağrılabilir.

        public async Task<Response<List<StudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var students = await studentRepository.ListAsync(new GetStudentsReadonlySpec(), cancellationToken);
                return new Response<List<StudentDto>>()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Message = "Students retrieved successfully.",
                    Error = null,
                    Data = mapper.Map<List<StudentDto>>(students)
                };
            }
            catch (Exception ex)
            {
                return new Response<List<StudentDto>>()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = "An error occurred while retrieving students.",
                    Error = ex.Message,
                    Data = null
                };
            }
            
        }
    }
}
