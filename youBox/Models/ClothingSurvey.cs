using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace youBox.Models
{
    public class ClothingSurvey
    {
        [Key]
        public int Id { get; set; }
        public int Question1 { get; set; }
        public int Question2 { get; set; }
        public int Question3 { get; set; }
        public int Question4 { get; set; }
        public int Question5 { get; set; }
        public int Question6 { get; set; }
        public int Question7 { get; set; }
        [ForeignKey("Subscriber")]
        public int SubscriberId { get; set; }
        public Subscriber subscriber { get; set; }


    }
}
