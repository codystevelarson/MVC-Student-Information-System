using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class GPALimitAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is decimal)
            {
                decimal checkGPA = (decimal)value;

                if (checkGPA > 0 && checkGPA < 4)
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