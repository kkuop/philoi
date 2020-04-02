using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhiloiWebApp.Models
{
    public class Categories
    {
        [Key]
        public int CategoriesId { get; set; }
        public string Name { get; set; }
    }
}
