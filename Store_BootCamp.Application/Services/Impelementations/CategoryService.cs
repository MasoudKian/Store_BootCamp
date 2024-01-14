using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Category;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.Services.Impelementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryService;
        public CategoryService(ICategoryRepository category)
        {
            _categoryService = category;
        }

        public void AddCategory(CategoryViewModel category)
        {
            var categor = new Category();
            categor.Title = category.Title;
            categor.ParentsId = categor.ParentsId;
            _categoryService.AddCategory(categor);
        }

        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }

        public ICollection<CategoryViewModel> GetAllCategory()
        {
            var Categories = new List<CategoryViewModel>();
            var CatList = _categoryService.GetAllCategories();
            foreach (var item in CatList) {
            var CatViewmodel=new CategoryViewModel();
                CatViewmodel.Title = item.Title;
                CatViewmodel.ParentId = item.ParentsId;
                CatViewmodel.id = item.id;
                 Categories.Add(CatViewmodel);
            }
            return Categories;
        }

        public Category GetCategory(int id)
        {
            return _categoryService.GetCategory(id);
        }

        public void update(CategoryViewModel category)
        {
            var categor = new Category();
            categor.Title = category.Title;
            categor.ParentsId = category.ParentId;
            categor.id = category.id;
            _categoryService.update(categor);
        }
    }
}
