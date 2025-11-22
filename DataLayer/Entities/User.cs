using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User : BaseEntity
    {
       
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
        public UserRole  Role { get; set; }
      

        #region Relations
        public ICollection<Post> Post { get; set; }
        public ICollection<PostComment> PostComment { get; set; }
        #endregion

    }

    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
