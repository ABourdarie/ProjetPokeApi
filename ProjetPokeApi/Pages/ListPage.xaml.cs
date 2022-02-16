
using Xamarin.Forms;
using PokeApiNet;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace ProjetPokeApi.Pages
{

    public partial class ListPage : ContentPage
    {

        public ListPage()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            PokeApiClient pokeClient = new PokeApiClient();

           for (int i = 1; i < 21; i++)
            {
                Pokemon poke = await Task.Run(async () => await pokeClient.GetResourceAsync<Pokemon>(i));
                Debug.WriteLine(poke.Name);
            }
        }
 
            
        
    }
    
}