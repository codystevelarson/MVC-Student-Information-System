using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class DuplicateStateAbbreviationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkString = (string)value;
                if (StateRepository.GetAll().Any(s => s.StateAbbreviation == checkString))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}