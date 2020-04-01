using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kennel_bambino.web.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [StringLength(75)]
        public string Title { get; set; }

        [StringLength(75)]
        public string ImageName { get; set; }

        public int? ParentId { get; set; }

        #region Relations - Navigation Properties

        [ForeignKey("ParentId")]
        public ICollection<Group> Groups { get; set; }

        [InverseProperty("Group")]
        public ICollection<Pet> Pets { get; set; }

        [InverseProperty("SubGroup")]
        public ICollection<Pet> Species { get; set; }

        #endregion
    }
}
