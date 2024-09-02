using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceTrackingApp.Business.Commands;
using StudentAttendanceTrackingApp.Business.Repositories.Abstracts;
using StudentAttendanceTrackingApp.Business.Specification.Users;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Handlers
{
    public class SignInHandler : IRequestHandler<SignInCommand, bool>
    {
        //private readonly SATDbContext context;
        //public SignInHandler(SATDbContext _context)
        //{
        //    context = _context;
        //}

        private readonly IApiUserRepository apiUserRepository;

        public SignInHandler(IApiUserRepository _apiUserRepository)
        {
            apiUserRepository = _apiUserRepository;
        }
    
        public async Task<bool> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //var res = await context.ApiUsers.Where(x => x.UserName == request.UserName).FirstOrDefaultAsync(cancellationToken);

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
