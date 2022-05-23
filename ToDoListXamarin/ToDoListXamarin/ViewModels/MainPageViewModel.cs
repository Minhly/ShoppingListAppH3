using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoListXamarin.Models;
using ToDoListXamarin.Views;
using Xamarin.Forms;
using System.Diagnostics;
using ToDoListXamarin.Services;
using System.Collections.Generic;

namespace ToDoListXamarin.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ShoppingListAndItems selectedList;

        public ObservableCollection<ShoppingListAndItems> Lists { get; }
        public Command LoadListsCommand { get; }
        public Command<ShoppingListAndItems> ItemTapped { get; }
        
        public MainPageViewModel()
        {
            Title = "Main";
            Lists = new ObservableCollection<ShoppingListAndItems>();
            LoadListsCommand = new Command(async () => await LoadShoppingListsCommand());

            ItemTapped = new Command<ShoppingListAndItems>(OnItemSelected);
        }

        async Task LoadShoppingListsCommand()
        {
            IsBusy = true;
            try
            {
                Lists.Clear();
                var lists = await DataStore.GetItemsAsync(true);
                foreach (var list in lists)
                {
                    Lists.Add(list);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ShoppingListAndItems SelectedItem
        {
            get => selectedList;
            set
            {
                SetProperty(ref selectedList, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(ShoppingListAndItems item)
        {
            if (item == null)
                return;
                // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ListItemsView)}?{nameof(ListItemViewModel.ItemId)}={item.Id}");
        }
    }
}