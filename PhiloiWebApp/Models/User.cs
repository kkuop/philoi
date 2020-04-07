using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ZipCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string ImgUrl { get; set; }

        public User()
        {

        }
    }
}
