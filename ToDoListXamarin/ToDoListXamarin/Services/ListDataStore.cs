using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListXamarin.Models;

namespace ToDoListXamarin.Services
{
    public class ListDataStore : IDataStore<ShoppingListAndItems>
    {
        public List<ShoppingListAndItems> lists;
        
        public ListDataStore() 
        {
            lists = new List<ShoppingListAndItems>()
            {
                new ShoppingListAndItems {Id = 1, Title = "Todo 1", ShoppingDate = Convert.ToDateTime("11-01-2022")},
                new ShoppingListAndItems {Id = 2, Title = "Todo 2", ShoppingDate = Convert.ToDateTime("11-02-2022")},
                new ShoppingListAndItems {Id = 3, Title = "Todo 3", ShoppingDate = Convert.ToDateTime("11-03-2022")},
                new ShoppingListAndItems {Id = 4, Title = "Todo 4", ShoppingDate = Convert.ToDateTime("11-04-2022")}
            };
        }

        public async Task<bool> AddItemAsync(ShoppingListAndItems item)
        {
            lists.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = lists.Where((ShoppingListAndItems arg) => arg.Id == id).FirstOrDefault();
            lists.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ShoppingListAndItems> GetItemAsync(int id)
        {
            return await Task.FromResult(lists.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ShoppingListAndItems>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(lists);
        }

        public async Task<bool> UpdateItemAsync(ShoppingListAndItems item)
        {
            var oldItem = lists.Where((ShoppingListAndItems arg) => arg.Id == item.Id).FirstOrDefault();
            lists.Remove(oldItem);
            lists.Add(item);

            return await Task.FromResult(true);
        }
    }
}
