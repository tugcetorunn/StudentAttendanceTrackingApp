
using System.Net;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Response<StudentDto?>>
    {
        private readonly IStudentRepository studentRepository;
        private readonly ITokenValidationService tokenValidationService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IValidator<UpdateStudentCommand> validator;
        private readonly IMapper mapper;
        public UpdateStudentHandler(IStudentRepository _studentRepository, ITokenValidationService _tokenValidationService, IHttpContextAccessor _httpContextAccessor, IValidator<UpdateStudentCommand> _validator, IMapper _mapper)
        {
            studentRepository = _studentRepository;
            tokenValidationService = _tokenValidationService;
            httpContextAccessor = _httpContextAccessor;
            validator = _validator;
            mapper = _mapper;
        }

        public async Task<Response<StudentDto?>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var tokenValidationResult = tokenValidationService.ValidateToken(token);

            if (!tokenValidationResult)
            {
                return new Response<StudentDto?>
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    IsSuccess = false,
                    Message = "Expired or invalid token.",
                    Error = "Unauthorized",
                    Data = null
                };
            }

            var maxId = await studentRepository.GetMaxId(cancellationToken);

            if (request.Id <= 0 || request.Id > maxId || request.Id == null)
            {
                return new Response<StudentDto?>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    Message = "Invalid student ID.",
                    Error = "BadRequest",
                    Data = null
                };
            }

            var requestValidationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!requestValidationResult.IsValid)
            {
                var errors = string.Join(", ", requestValidationResult.Errors.Select(e => e.ErrorMessage));

                return new Response<StudentDto?>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    Message = "Validation failed.",
                    Error = errors,
                    Data = null
                };
            }

            var updateStudent = await studentRepository.GetByIdAsync(request.Id, cancellationToken);

            try
            {
                if (updateStudent == null)
                {
                    return new Response<StudentDto?>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        IsSuccess = false,
                        Message = "The student not found.",
                        Error = "NotFound",
                        Data = null
                    };
                }

                updateStudent.FirstName = request.FirstName;
                updateStudent.LastName = request.LastName;
                updateStudent.Email = request.Email;
                updateStudent.BirthDate = request.BirthDate;
                updateStudent.City = request.City;

                await studentRepository.UpdateAsync(updateStudent, cancellationToken);

                return new Response<StudentDto?>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Message = "The student updated successfully.",
                    Error = null,
                    Data = mapper.Map<StudentDto>(updateStudent)
                };
            }
            catch (Exception ex)
            {
                return new Response<StudentDto?>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    Message = "An error occurred while updating the student.",
                    Error = ex.Message,
                    Data = null
                };
            }
        }
    }
}
