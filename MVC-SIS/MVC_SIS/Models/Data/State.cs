using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State
    {
        //[DuplicateStateAbbreviation(ErrorMessage = "State abbreviation already exists")]
        [ValidStateAbbreviation(ErrorMessage = "State abbreviation must be 2 letters (ex. MN)")]
        [Required (ErrorMessage = "Please enter a state abbreviation")]
        public string StateAbbreviation { get; set; }

        //[DuplicateStateName(ErrorMessage = "State name already exists")]
        [Required (ErrorMessage = "Please enter a state name")]
        public string StateName { get; set; }
    }
}