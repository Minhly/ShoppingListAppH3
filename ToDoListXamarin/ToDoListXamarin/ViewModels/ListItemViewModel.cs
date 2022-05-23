using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDoListXamarin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ListItemViewModel : BaseViewModel
    {
        private int itemId;
        private string title;
        private string shoppingdate;

        public Command deleteList;

        public string Id { get; set; }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string ShoppingDate
        {
            get => shoppingdate;
            set => SetProperty(ref shoppingdate, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id.ToString();
                Title = item.Title;
                ShoppingDate = item.ShoppingDate.ToString();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public Command DeleteList
        {
            get
            {
                if (deleteList == null)
                {
                    deleteList = new Command(PerformDeleteList);
                }

                return deleteList;
            }
        }

        private async void PerformDeleteList()
        {
            await DataStore.DeleteItemAsync(itemId);
            await Shell.Current.GoToAsync($"..");
        }
    }
}