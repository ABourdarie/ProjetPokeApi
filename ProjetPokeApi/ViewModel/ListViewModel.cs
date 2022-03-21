
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using PokeApiNet;
using ProjetPokeApi;
using ProjetPokeApi.Models;
using ProjetPokeApi.ViewModels;

namespace ProjetPokeApi.ListViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public ObservableCollection<MyPokemon> PokemonsList
        {
            get { return GetValue<ObservableCollection<MyPokemon>>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<MyPokemon> TeamList
        {
            get { return GetValue<ObservableCollection<MyPokemon>>(); }
            set { SetValue(value); }
        }
        private static readonly ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance { get { return _instance; } }

        public ListViewModel()
        {
            PokemonsList = new ObservableCollection<MyPokemon>();
            LinkApi();
            LinkData();
        }

        async void LinkApi()
        {
            PokeApiClient pokeClient = new PokeApiClient();

            for (int i = 1; i <= 151; i++)
            {
                Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(i));

                MyPokemon myPokemon = new MyPokemon
                {
                    Id = pokemon.Id,
                    Name = pokemon.Name,
                    Image = pokemon.Sprites.FrontDefault,
                    HP = pokemon.Stats[0].BaseStat,
                    Attack = pokemon.Stats[1].BaseStat,
                    Defense = pokemon.Stats[2].BaseStat,
                    SpeAttack = pokemon.Stats[3].BaseStat,
                    SpeDefense = pokemon.Stats[4].BaseStat,
                    Speed = pokemon.Stats[5].BaseStat
                };

                PokemonsList.Add(myPokemon);

            }
        }
        async void LinkData()
        {
            Database pokeDB = await Database.Instance;

            PokemonsList = new ObservableCollection<MyPokemon>(await pokeDB.GetItemsAsync());
        }
    }
}
