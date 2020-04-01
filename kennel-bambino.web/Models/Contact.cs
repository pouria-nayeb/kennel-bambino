using System;
using System.ComponentModel.DataAnnotations;

namespace kennel_bambino.web.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        [Required]
        [StringLength(750)]
        public string Description { get; set; }

        public bool IsChecked { get; set; }

        [Required]
        public DateTime SubmitDate { get; set; }
    }
}
