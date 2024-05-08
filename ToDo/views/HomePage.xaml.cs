﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Droid.Resources.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }
        private async void LoadItems()
        {
            var items = await App.Context.GetItemsAsync();
            lista_tareas.ItemsSource = items;
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmación", "¿Esta seguro de eliminar el elemnto?", "si", "no"))
            {

                var item= (ToDoItem)(sender as MenuItem).CommandParameter;
                var result= await App.Context.DeleteItemAsync(item);
                if (result == 1) {
                    LoadItems();
                }
            }
        }
    }
}