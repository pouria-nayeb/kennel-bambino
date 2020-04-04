using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kennel_bambino.web.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        [StringLength(320)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(750)]
        public string Description { get; set; }

        [Required]
        public string Information { get; set; }

        public bool Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public bool ReadyForDelivery { get; set; }

        [Required]
        public double Price { get; set; }

        public bool IsDelete { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int GroupId { get; set; }

        [Display(Name = "Specie")]
        public int? SubGroupId { get; set; }

        [Display(Name = "Eye Color")]
        public int EyeColorId { get; set; }

        [Display(Name = "Body Pattern")]
        public int PatternId { get; set; }

        [Display(Name = "Body Type")]
        public int BodyTypeId { get; set; }

        #region Relations - Navigation Properties

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [ForeignKey("SubGroupId")]
        public Group SubGroup { get; set; }

        public EyeColor EyeColor { get; set; }

        public Pattern Pattern { get; set; }

        public BodyType BodyType { get; set; }

        public ICollection<Photo> Photos { get; set; }

        #endregion
    }
}
