using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Data
{
    public class Lesson : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
