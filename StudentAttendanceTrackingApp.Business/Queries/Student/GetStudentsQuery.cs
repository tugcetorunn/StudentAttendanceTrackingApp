using MediatR;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Queries
{
    public class GetStudentsQuery : IRequest<List<Student>>
    {
        // request için gerekli parametreler buraya eklenir. query parametreli buradan çeker. bu işlemde parametreye gerek yok.
    }
}
