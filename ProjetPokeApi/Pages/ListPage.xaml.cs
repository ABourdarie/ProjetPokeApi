
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using System.Linq;

namespace ProjetPokeApi.Pages
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = ListViewModels.ListViewModel.Instance;
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProjetPokeApi.Models.MyPokemon current = (e.CurrentSelection.FirstOrDefault() as ProjetPokeApi.Models.MyPokemon);
            if (current == null)
            {
                return;
            }
            (sender as CollectionView).SelectedItem = null;
            await Navigation.PushAsync(new ShowPage(current));
        }
    }
}