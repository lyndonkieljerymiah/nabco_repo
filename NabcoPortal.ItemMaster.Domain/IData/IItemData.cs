using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.ItemMaster.Domain.IData
{
    public interface IItemData
    {
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task<IEnumerable<Item>> GetItems(int page,int size);
        Task<IEnumerable<Item>> GetItems(int page, int size,string search);
        int GetTotalRecordCount();
        Task<Item> GetItem(int id);
        

    }
}
