using System;
using System.ComponentModel.DataAnnotations;

namespace UtahCrashes.Models
{
    public class County
    {
        [Key]
        [Required]
        public string County_ID { get; set; }
        public DateTime County_Name { get; set; }
    }
}
