using Store_BootCamp.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Domain.InterfacesRepository
{
    public interface ICategoryRepository
    {
        public void AddCategory(Category category);
        public void update(Category category);
        public void DeleteCategory(int id);
        public Category GetCategory(int id);
        public ICollection<Category> GetAllCategories();    
    }
}
