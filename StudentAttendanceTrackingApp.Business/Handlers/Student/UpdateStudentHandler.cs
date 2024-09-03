
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Response<Student?>>
    {
        private readonly IStudentRepository studentRepository;
        private readonly ITokenValidationService tokenValidationService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IValidator<UpdateStudentCommand> validator;
        public UpdateStudentHandler(IStudentRepository _studentRepository, ITokenValidationService _tokenValidationService, IHttpContextAccessor _httpContextAccessor, IValidator<UpdateStudentCommand> _validator)
        {
            studentRepository = _studentRepository;
            tokenValidationService = _tokenValidationService;
            httpContextAccessor = _httpContextAccessor;
            validator = _validator;
        }

        public async Task<Response<Student?>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var tokenValidationResult = tokenValidationService.ValidateToken(token);

            if (!tokenValidationResult)
            {
                return new Response<Student?>
                {
                    StatusCode = 401,
                    IsSuccess = false,
                    Message = "Expired or invalid token.",
                    Error = "Unauthorized",
                    Data = null
                };
            }

            var maxId = await studentRepository.GetMaxId(cancellationToken);

            if (request.Id <= 0 || request.Id > maxId || request.Id == null)
            {
                return new Response<Student?>
                {
                    StatusCode = 400,
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

                return new Response<Student?>
                {
                    StatusCode = 400,
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
                    return new Response<Student?>
                    {
                        StatusCode = 404,
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

                return new Response<Student?>
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = "The student updated successfully.",
                    Error = null,
                    Data = updateStudent
                };
            }
            catch (Exception ex)
            {
                return new Response<Student?>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occurred while updating the student.",
                    Error = ex.Message,
                    Data = null
                };
            }
        }
    }
}
