
namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class SignInHandler : IRequestHandler<SignInCommand, bool>
    {
        private readonly IApiUserRepository apiUserRepository;

        public SignInHandler(IApiUserRepository _apiUserRepository)
        {
            apiUserRepository = _apiUserRepository;
        }
    
        public async Task<bool> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var spec = new GetByUsernameReadonlySpec(request.UserName);
            var user = await apiUserRepository.GetBySpecAsync(spec, cancellationToken);

            if (user != null && user.Password == request.Password)
            {
                return true;
            }

            return false;
        }
    }
}
