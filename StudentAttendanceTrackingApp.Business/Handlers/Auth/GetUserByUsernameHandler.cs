
namespace StudentAttendanceTrackingApp.Business.Handlers.Auth
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, ApiUserDto>
    {
        private readonly IApiUserRepository apiUserRepository;
        private readonly IMapper mapper;

        public GetUserByUsernameHandler(IApiUserRepository _apiUserRepository, IMapper _mapper)
        {
            apiUserRepository = _apiUserRepository;
            mapper = _mapper;
        }

        public async Task<ApiUserDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetByUsernameReadonlySpec(request.UserName);
            var apiUser = await apiUserRepository.GetBySpecAsync(spec, cancellationToken);
            return mapper.Map<ApiUserDto>(apiUser);
        }
    }
}
