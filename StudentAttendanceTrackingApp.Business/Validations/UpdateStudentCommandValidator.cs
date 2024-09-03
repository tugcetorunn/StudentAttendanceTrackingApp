
namespace StudentAttendanceTrackingApp.Business.Validations
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                                     .Length(3, 30).WithMessage("First name must be between 3 and 30 characters.")
                                     .Matches(@"^[a-zA-Z]+$").WithMessage("First name can only contain letters.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.")
                                     .Length(3, 30).WithMessage("Last name must be between 3 and 30 characters.")
                                     .Matches(@"^[a-zA-Z]+$").WithMessage("Last name can only contain letters.");

            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Birth date is required.")
                                     .LessThan(DateTime.UtcNow.AddYears(-18)).WithMessage("Student must be at least 18 years old.")
                                     .GreaterThan(DateTime.UtcNow.AddYears(-100)).WithMessage("Birth date must be realistic.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                                 .EmailAddress().WithMessage("Invalid email address.")
                                 .Must(email => IsAllowDomain(email)).WithMessage("Email domain is not allowed.");

            RuleFor(x => x.City).NotEmpty().WithMessage("City name is required.")
                                .Matches(@"^[a-zA-Z]+$").WithMessage("City name can only contain letters.");
        }

        private bool IsAllowDomain(string email)
        {
            var allowed = new List<string> { "hotmail.com", "gmail.com", "mycollege.edu" };
            var domain = email.Split("@").Last();
            return allowed.Contains(domain);
        }
    }
}
