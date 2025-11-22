using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Category : BaseEntity
    {
       
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }
        [MaxLength(100)]
        public string MetaTag { get; set; }
        [MaxLength(100)]
        public string MetaDescription { get; set; }
        public int? ParentId { get; set; }


        #region Relations
        public ICollection<Post> Post { get; set; }
        #endregion

    }
}
