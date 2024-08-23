using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceTrackingApp.Business.Commands;
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
        private readonly SATDbContext context;
        public SignInHandler(SATDbContext _context)
        {
            context = _context;
        }
        public async Task<bool> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var res = await context.ApiUsers.Where(x => x.UserName == request.UserName).FirstOrDefaultAsync(cancellationToken);

            if (res != null && res.Password == request.Password)
            {
                return true;
            }

            return false;
        }
    }
}
