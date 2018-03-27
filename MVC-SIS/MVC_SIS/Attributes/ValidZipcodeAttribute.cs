using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class ValidZipcodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                //Change string into an int and check if it is 5 char long
                string checkZipString = (string)value;

                if(checkZipString.Length == 5)
                {
                    int checkZipint;
                    if (int.TryParse(checkZipString, out checkZipint))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}