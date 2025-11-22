using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.Category
{
    public class EditeCategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
    }
}
