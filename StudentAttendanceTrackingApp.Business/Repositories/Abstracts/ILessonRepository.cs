﻿using Ardalis.Specification;
using StudentAttendanceTrackingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Business.Repositories.Abstracts
{
    public interface ILessonRepository : IRepositoryBase<Lesson>
    {
    }
}