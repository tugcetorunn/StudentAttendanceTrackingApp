using MediatR;
using StudentAttendanceTrackingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Queries
{
    public class GetUserByUsernameQuery : IRequest<ApiUser>
    {
        public string UserName { get; set; } 
    }
}
