using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListXamarin.ViewModels;
using ToDoListXamarin.Views;
using Xamarin.Forms;

namespace ToDoListXamarin
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = _viewModel = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        private async void OnAddItem(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CreateShoppingList));
            //Application.Current.MainPage = new NavigationPage(new ListCreate());
        }
    }
}
