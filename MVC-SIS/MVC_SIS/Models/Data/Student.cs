using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Must enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must enter a last name")]
        public string LastName { get; set; }

        [GPALimit(ErrorMessage = "GPA must be a positive number less than or equal to 4")]
        public decimal GPA { get; set; }
        public Address Address { get; set; }

        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}