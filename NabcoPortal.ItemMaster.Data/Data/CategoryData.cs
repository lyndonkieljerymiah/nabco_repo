using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabcoPortal.ItemMaster.Domain.IData;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.ItemMaster.Data.Data
{
    public class CategoryData : ICategoryData
    {
        private readonly ItemContextDb _contextDb;

        public CategoryData(ItemContextDb contextDb)
        {
            _contextDb = contextDb;
        }


        public async Task AddCategory(Category category)
        {
            try
            {
                _contextDb.Categories.Add(category);
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message,e);
            }
        }

        public async Task UpdateCategory(Category category)
        {
            try
            {
                _contextDb.Categories.Attach(category);
                _contextDb.Entry(category).State = EntityState.Modified;
                await _contextDb.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _contextDb.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var category = await _contextDb.Categories.OrderBy(c => c.Name).ToListAsync();
            return category;
        }
    }
}
