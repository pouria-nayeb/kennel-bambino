using System.ComponentModel.DataAnnotations;

namespace kennel_bambino.web.Models
{
    public class Carousel
    {
        [Key]
        public int CarouselId { get; set; }

        [StringLength(75)]
        public string ImageName { get; set; }

        [Required]
        [StringLength(75)]
        public string Alt { get; set; }

        [Required]
        public byte Number { get; set; }
    }
}
