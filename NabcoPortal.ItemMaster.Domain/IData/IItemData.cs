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
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(int Id);
    }
}
