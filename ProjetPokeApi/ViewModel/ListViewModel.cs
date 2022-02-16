using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjetPokeApi.ViewModel
{
    internal class ListViewModel : BaseViewModel
    {
        public static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance => _instance;

        public ObservableCollection<Pokemon> ListofPokemon
        {
            get => GetValue<ObservableCollection<Pokemon>>();
            set
            {
                SetValue(value);
            }
        }
    }
}
