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
    public class ItemData : IItemData
    {
        private readonly ItemContextDb _contextDb;

        public ItemData(ItemContextDb contextDb)
        {
            _contextDb = contextDb;

        }

        public async Task AddItem(Item item)
        {
            _contextDb.Items.Add(item);
            await _contextDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var items = await _contextDb.Items
                .OrderBy(i => i.Name)
                .ToListAsync();

            return items;
        }

        public async Task<Item> GetItem(int id)
        {
            var item = await _contextDb.Items.FindAsync(id);
            return item;
        }
    }
}
