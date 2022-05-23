using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoListXamarin.Models
{
    public class ShoppingListAndItems
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("date")]
        public DateTime ShoppingDate { get; set; }
        public ObservableCollection<ToDoItem> ShoppingItems { get; set; }

        public ShoppingListAndItems() {}
    }
}
