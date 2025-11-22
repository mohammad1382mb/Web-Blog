using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PostComment : BaseEntity
    {
        
        public int UserId { get; set; }
        public int PostId { get; set; }
        [Required]
        [MaxLength(500)]
        public string text { get; set; }
       

        #region Relations
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion


    }
}
