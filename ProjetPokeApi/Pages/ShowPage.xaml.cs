
using System;
using ProjetPokeApi.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetPokeApi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowPage : ContentPage
    {

        public ShowPage(PokeApiNet.Pokemon param)
        {
            InitializeComponent();
            BindingContext = ListViewModel.Instance.ShowPoke(param);
        }
    }
}