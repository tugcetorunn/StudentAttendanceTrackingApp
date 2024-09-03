
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Response<int>>
    {
        private readonly IStudentRepository studentRepository;
        private readonly ITokenValidationService tokenValidationService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public DeleteStudentHandler(IStudentRepository _studentRepository, ITokenValidationService _tokenValidationService, IHttpContextAccessor _httpContextAccessor)
        {
            studentRepository = _studentRepository;
            tokenValidationService = _tokenValidationService;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<Response<int>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // validation daki gibi jwt kendi hata çıktısını fırlatıyor. aşağıdaki response un önüne geçiyor.
            var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var validationResult = tokenValidationService.ValidateToken(token);

            if (!validationResult)
            {
                return new Response<int>
                {
                    StatusCode = 401,
                    IsSuccess = false,
                    Message = "Expired or invalid token.",
                    Error = "Unauthorized",
                    Data = 0
                };
            }

            var maxId = await studentRepository.GetMaxId(cancellationToken);

            if (request.Id <= 0 || request.Id > maxId || request.Id == null)
            {
                return new Response<int>
                {
                    StatusCode = 400,
                    IsSuccess = false,
                    Message = "Invalid student ID.",
                    Error = "BadRequest",
                    Data = 0
                };
            }

            try
            {
                var delStudent = await studentRepository.GetByIdAsync(request.Id, cancellationToken);
                
                if (delStudent == null)
                {
                    return new Response<int>
                    {
                        StatusCode = 404,
                        IsSuccess = false,
                        Message = "The student not found.",
                        Error = "NotFound",
                        Data = 0
                    };
                }

                delStudent.IsDeleted = true;
                await studentRepository.SaveChangesAsync();

                return new Response<int>
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = "The student deleted successfully.",
                    Error = null,
                    Data = delStudent.Id
                };
            }
            catch (Exception ex)
            {
                return new Response<int>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occurred while deleting the student.",
                    Error = ex.Message,
                    Data = 0
                };
            }
        }
    }
}
