using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class ValidStateAbbreviationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string checkString = (string)value;
                if(checkString.Length == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}