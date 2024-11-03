
using System.Net;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Response<StudentDto>>
    {
        // ardalis specification ile repository design pattern ını kullanacağımız için handler lardaki context i repository tarafına vererek handler
        // class larını bir katman daha soyutlaştırmış oluyoruz.

        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public GetStudentByIdHandler(IStudentRepository _studentRepository, IMapper _mapper)
        {
            studentRepository = _studentRepository;
            mapper = _mapper;
        }

        public async Task<Response<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            // Custom validation control
            // request kontrolünün böyle sağlanması best practice değil. guard kullanılabilir.

            var maxId = await studentRepository.GetMaxId(cancellationToken); // await kullanmazsak, id Task<int> tipinde oluyor.

            if (request.Id <= 0 || request.Id > maxId || request.Id == null)
            {
                return new Response<StudentDto>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    Message = "Invalid student ID.",
                    Error = "BadRequest",
                    Data = null
                };
            }

            try
            {
                var spec = new GetStudentByIdReadonlySpec(request.Id);
                var student = await studentRepository.GetBySpecAsync(spec, cancellationToken);

                if (student == null)
                {
                    return new Response<StudentDto>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        IsSuccess = false,
                        Message = "The student not found.",
                        Error = "NotFound",
                        Data = null
                    };
                }

                return new Response<StudentDto>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Message = "The student retrieved successfully.",
                    Error = null,
                    Data = mapper.Map<StudentDto>(student)
                };
            }
            // yukarıdaki koşulların dışında bir sorun çıkarsa diye;
            catch (Exception ex)
            {
                return new Response<StudentDto>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = "An error occurred while retrieving the student.",
                    Error = ex.Message,
                    Data = null
                };
            }
            
        }
    }
}

// request ler için kontrol yöntemleri
// fluent validation
// data annotation
// custom validation 