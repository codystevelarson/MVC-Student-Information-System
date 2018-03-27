using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Course
    {
        public int CourseId { get; set; }

        //[DuplicateCourse(ErrorMessage = "Course name already exists")]
        [Required(ErrorMessage = "Must enter a course name")]
        public string CourseName { get; set; }
    }
}