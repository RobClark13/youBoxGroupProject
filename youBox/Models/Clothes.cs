using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace youBox.Models
{
    public class Clothes
    {[Key]
        public int Id { get; set; }
        public string Type {get;set;}
        public string Size { get; set; }
        public string Brand { get; set; }

    }
}
