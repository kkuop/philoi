using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Models
{
    public class UserInterest
    {
        public int UserInterestId { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        //[ForeignKey("Interests")]
        //public int InterestId { get; set; }
        //public Interests Interest { get; set; }

        public UserInterest()
        {

        }
    }
}
