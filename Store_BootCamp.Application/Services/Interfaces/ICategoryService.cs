using Store_BootCamp.Application.ViewModels.Category;
using Store_BootCamp.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        public void AddCategory(CategoryViewModel category);
        public void update(CategoryViewModel category);
        public void DeleteCategory(int id);
        public Category GetCategory(int id);
        public ICollection<CategoryViewModel> GetAllCategory();
    }
}
