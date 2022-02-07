
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using PokeApiNet;
using System.Threading.Tasks;

namespace ProjetPokeApi.Pages
{

    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            PokemonsList.ToString();
        }
    }

    public class PokemonsList
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        
    }

    public class Pokemon
    {
        public static implicit operator Pokemon(string v)
        {
            throw new NotImplementedException();
        }

        public string Title { get; set; }   
           
    }

    public partial class PokemonsListViewModel
    {

    }

    public class program
    {
        static HttpClient client = new HttpClient();

        static async Task<Pokemon> GetPokemonAsync(string path)
        {
            Pokemon pokemon = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                pokemon = await response.Content.ReadAsStringAsync();
            }
            return pokemon;
        }

    }
    
}