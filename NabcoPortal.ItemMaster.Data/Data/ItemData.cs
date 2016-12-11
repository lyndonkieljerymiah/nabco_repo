using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using NabcoPortal.ItemMaster.Domain.IData;
using NabcoPortal.ItemMaster.Domain.Model;
using Utilities.Extension;

namespace NabcoPortal.ItemMaster.Data.Data
{
    public class ItemData : IItemData, IDisposable
    {
        private readonly ItemContextDb _contextDb;
        private readonly ReferenceContextDb _referenceContextDb;

        public ItemData(ItemContextDb contextDb,ReferenceContextDb referenceContextDb)
        {
            _contextDb = contextDb;
            _referenceContextDb = referenceContextDb;

        }


        public async Task AddItem(Item item)
        {
            _contextDb.Items.Add(item);
            await _contextDb.SaveChangesAsync();
        }


        public async Task<IEnumerable<Item>> GetItems(int page, int size)
        {       
            var items = await _referenceContextDb.Items
                .Limit(page, size,m => m.OrderBy(i => i.ModelNo))
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<Item>> GetItems(int page, int size, string search)
        {
            var items = await _referenceContextDb.Items
                .Where(i => i.Description.Contains(search))
                .Limit(page, size, m => m.OrderBy(i => i.ModelNo))
                .ToListAsync();

            return items;
        }

        public int GetTotalRecordCount()
        {
            return _referenceContextDb.Items.Count();
        }


        public async Task<Item> GetItem(int id)
        {
            var item = await _contextDb.Items
                .Include(i => i.Category)
                .SingleOrDefaultAsync(i => i.Id == id);

            return item;
        }


        public async Task UpdateItem(Item item)
        {
            _contextDb.Items.Attach(item);
            _contextDb.Entry(item).State = EntityState.Modified;
            await _contextDb.SaveChangesAsync();

        }
        
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);    
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                _contextDb.Dispose();
                _referenceContextDb.Dispose();
                handle.Dispose();
            }

            disposed = true;
        }


        
    }
}
