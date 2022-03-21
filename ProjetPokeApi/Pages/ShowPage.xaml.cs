
using PokeApiNet;
using ProjetPokeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetPokeApi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowPage : ContentPage
    {

        public ShowPage(MyPokemon pokemon)
        {
            InitializeComponent();
            BindingContext = pokemon;
        }

    }
}