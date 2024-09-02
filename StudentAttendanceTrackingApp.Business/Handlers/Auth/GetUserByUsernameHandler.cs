using MediatR;
using StudentAttendanceTrackingApp.Business.Queries;
using StudentAttendanceTrackingApp.Business.Repositories.Abstracts;
using StudentAttendanceTrackingApp.Business.Specification.Users;
using StudentAttendanceTrackingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Handlers.Auth
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, ApiUser>
    {
        private readonly IApiUserRepository apiUserRepository;

        public GetUserByUsernameHandler(IApiUserRepository _apiUserRepository)
        {
            apiUserRepository = _apiUserRepository;
        }

        public async Task<ApiUser> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetByUsernameReadonlySpec(request.UserName);
            return await apiUserRepository.GetBySpecAsync(spec, cancellationToken);
        }
    }
}
