﻿using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major
    {
        
        public int MajorId { get; set; }

        //[DuplicateMajor(ErrorMessage = "Major already exists")]
        //[Required (ErrorMessage = "Must enter a major name")]
        public string MajorName { get; set; }
    }
}