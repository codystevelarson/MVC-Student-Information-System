using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Must enter a street address")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }

        [Required(ErrorMessage = "Must enter a city name")]
        public string City { get; set; }
        public State State { get; set; }

        [ValidZipcode(ErrorMessage = "Postal zip code must be a number (ex. 55303)")]
        [Required(ErrorMessage = "Must enter a postal zip code")]
        public string PostalCode { get; set; }
    }
}