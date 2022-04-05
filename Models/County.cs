using System;
using System.ComponentModel.DataAnnotations;

namespace UtahCrashes.Models
{
    public class County
    {
        [Key]
        [Required]
        public int County_ID { get; set; }
        public string County_Name { get; set; }
    }
}
