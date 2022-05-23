using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListClassLibrary.Models;

namespace ToDoListAPI.Services
{
    public class ShoppingListItemRepository : GenericRepository<ShoppingListItem, ToDoListDBContext>, IShoppingListItemRepository
    {
        public ShoppingListItemRepository(ToDoListDBContext dbcontext)
            : base(dbcontext)
        {

            }

        public async Task<ICollection<ShoppingListItem>> GetItemsListByShoppingListId(int shoppingListId)
        {
            return await _dbcontext.ShoppingListItems.Where(c => c.ShoppinglistId == shoppingListId)
/*                .Include(c => c.Title)
                .Include(c => c.Checked)
                .Include(c => c.ShoppinglistId)*/
                .ToListAsync();
        }
    }
}
