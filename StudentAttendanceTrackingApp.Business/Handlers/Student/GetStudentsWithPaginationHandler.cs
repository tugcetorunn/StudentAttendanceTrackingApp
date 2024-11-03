
using System.Net;

namespace StudentAttendanceTrackingApp.Business.Handlers.Student
{
    public class GetStudentsWithPaginationHandler : IRequestHandler<GetStudentsWithPaginationQuery, Response<List<StudentDto>>>
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public GetStudentsWithPaginationHandler(IStudentRepository _studentRepository, IMapper _mapper)
        {
            studentRepository = _studentRepository;
            mapper = _mapper;
        }

        public async Task<Response<List<StudentDto>>> Handle(GetStudentsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int skip = (request.PageIndex - 1) * request.TotalCount; // 2. sayfadan 10 kişi istenirse -> ilk 10 kişiyi skip lemesi için
                int take = request.TotalCount;
                var studentDtos = mapper.Map<List<StudentDto>>(await studentRepository.ListAsync(new GetStudentsWithPaginationReadonlySpec(skip, take), cancellationToken));

                return new Response<List<StudentDto>>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Message = "Students retrieved successfully with pagination.",
                    Error = null,
                    Data = studentDtos
                };
            }
            catch (Exception ex)
            {
                return new Response<List<StudentDto>>()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = "An error occurred while retrieving students with pagination.",
                    Error = ex.Message,
                    Data = null
                };
            }
            
            
        }
    }
}
