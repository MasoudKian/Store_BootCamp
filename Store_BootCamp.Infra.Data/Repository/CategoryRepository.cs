using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Category;
using Store_BootCamp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_BootCamp.Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDBContext _dbContext;
        public CategoryRepository(StoreDBContext storeDBContext)
        {
            _dbContext = storeDBContext;
        }

        public void AddCategory(Category category)
        {
            _dbContext.categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategory(id);
            _dbContext.categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public ICollection<Category> GetAllCategories()
        {
            return _dbContext.categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _dbContext.categories.FirstOrDefault(a => a.id == id);
        }

        public void update(Category category)
        {
            _dbContext.categories.Update(category);
            _dbContext.SaveChanges();
        }
    }
}
