using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Models
{
    public class Interests
    {
        [Key]
        public int InterestsId { get; set; }
        public string Name { get; set;}

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }

        [ForeignKey("Categories")]
        public int CategoriesId { get; set; }
        public Interests categories { get; set; }
    }
}
