
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Response<Student>>
    {
        private readonly IStudentRepository studentRepository;
        private readonly IValidator<CreateStudentCommand> validator;
        public CreateStudentHandler(IStudentRepository _studentRepository, IValidator<CreateStudentCommand> _validator)
        {
            studentRepository = _studentRepository;
            validator = _validator;
        }
        public async Task<Response<Student>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            // programı çalıştırdığımızda controller a gitmeden validator ı çalıştırıyor. ve çıktıyı validator ın kendi middleware ini çalıştırıyor.
            // yani kod buraya gelmiyor bu yüzden bizim standart response umuzla da çıktı vermiyor. bunun için validation kurallarını ayrı bir class ta
            // kendi metodumuzla yazarsak bu çıktıyı alabiliriz. burada tek sıkıntı kendi response umuzun dönmemesi gerisi doğru çalışıyor. programın önce 
            // controller a sonra handler oradan validator a gitmesini ayarlayabilirsek çözülür.

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));

                return new Response<Student>
                {
                    StatusCode = 400,
                    IsSuccess = false,
                    Message = "Validation failed.",
                    Error = errors,
                    Data = null
                };
            }

            try
            {
                // create metodunun bir başka yolu

                var newStudent = Student.Create(request.FirstName, request.LastName, request.BirthDate, request.Email, request.City);

                await studentRepository.AddAsync(newStudent, cancellationToken);

                if (newStudent == null)
                {
                    return new Response<Student>
                    {
                        StatusCode = 400,
                        IsSuccess = false,
                        Message = "The student could not be created.",
                        Error = "NullException",
                        Data = null
                    };
                }

                return new Response<Student>
                {
                    StatusCode = 201,
                    IsSuccess = true,
                    Message = "The student created successfully.",
                    Error = null,
                    Data = newStudent
                };

            }
            catch (Exception ex)
            {

                return new Response<Student>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occurred while creating the student.",
                    Error = ex.Message,
                    Data = null
                };
            }
        }
    }
}
