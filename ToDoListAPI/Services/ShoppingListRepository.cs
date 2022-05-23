using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListClassLibrary.Models;

namespace ToDoListAPI.Services
{
    public class ShoppingListRepository : GenericRepository<Shoppinglist, ToDoListDBContext>, IShoppingListRepository
    {
        public ShoppingListRepository(ToDoListDBContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}
