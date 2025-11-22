using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Areas.Admin.Models.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; }

        [Display(Name = "Slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; }

        [Display(Name = "MetaTag (با - از هم جدا کنید)")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string MetaTag { get; set; }

        public string MetaDescription { get; set; }
    }
}
