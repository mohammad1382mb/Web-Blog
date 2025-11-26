using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Services.Category;
using Blog.Areas.Admin.Models.Category;
using CoreLayer.DTOs.Category;
using CoreLayer.Utilities;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }

        [Route("admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId)
        {
            return View();
        }
        [HttpPost("admin/category/add/{parentId}")]
        public IActionResult Add(int? parentId ,CreateCategoryViewModel createViewModel)
        {
            createViewModel.ParentId = parentId;
            var result = _categoryService.CreateCategory(createViewModel.MapToDto());
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(createViewModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            var model = new EditCategoryViewModel()
            {
                Slug = category.Slug,
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Title = category.Title
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , EditCategoryViewModel editModel)
        {
            var result = _categoryService.EditeCategory(new EditeCategoryDto()
            {
                Id = editModel.Id,
                Slug = editModel.Slug,
                MetaDescription = editModel.MetaDescription,
                MetaTag = editModel.MetaTag,
                Title = editModel.Title
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
