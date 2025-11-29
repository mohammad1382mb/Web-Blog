using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Post : BaseEntity
    {
       
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public int Visit { get; set; }
        public string ImageName { get; set; }


        #region Relation
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ICollection<PostComment> PostComment { get; set; }
        #endregion

    }
}
