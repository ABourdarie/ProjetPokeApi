using PokeApiNet;
using ProjetPokeApi.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace ProjetPokeApi.ViewModel
{
    internal class ListViewModel : BaseViewModel
    {
        public static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance => _instance;

        internal object ShowPoke(Pokemon param)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<MyPokemon> ListofPokemon
        {
            get => GetValue<ObservableCollection<MyPokemon>>();
            set
            {
                SetValue(value);
            }
        }

        public ListViewModel()
        {
            ListofPokemon = new ObservableCollection<MyPokemon>();
            InitList();
        }

        public void ShowPoke(object pokemon)
        {
            ListofPokemon = new ObservableCollection<MyPokemon>();
            InitPoke(pokemon);
        }

        private async void InitList()
        {
            PokeApiClient pokeClient = new PokeApiClient();

            for (int i = 1; i < 21; i++)
            {
                Pokemon poke = await Task.Run(async () => await pokeClient.GetResourceAsync<Pokemon>(i));

                MyPokemon mypokemon;

                if (poke.Types.Count > 1)
                {
                    mypokemon = new MyPokemon
                    {
                        Id = poke.Id,
                        Nom = poke.Name,
                        Poids = poke.Weight,
                        Type = poke.Types[0].Type.Name + " " + poke.Types[1].Type.Name
                    };
                }
                else
                {
                    mypokemon = new MyPokemon
                    {
                        Id = poke.Id,
                        Nom = poke.Name,
                        Poids = poke.Weight,
                        Type = poke.Types[0].Type.Name

                    };
                }
                    
                

                ListofPokemon.Add(mypokemon);
            }
          
        }

        private async void InitPoke(object pokemon)
        {
            using (PokeApiClient pokeClient = new PokeApiClient())
                for (int i = 1; i < 21; i++)
                {
                    Pokemon poke = await Task.Run(async () => await pokeClient.GetResourceAsync<Pokemon>(i));
                    Pokemon mypokemon = poke;  

                    if (pokemon == mypokemon) {
                        //ListofPokemon.Add(mypokemon);
                    }
                }

        }


    }
}
