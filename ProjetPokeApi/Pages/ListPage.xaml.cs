
using PokeApiNet;
using ProjetPokeApi.ViewModel;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetPokeApi.Pages
{

    public partial class ListPage : ContentPage
    {

        public ListPage()
        {
            InitializeComponent();
            BindingContext = ListViewModel.Instance;
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            Pokemon param = (Pokemon)((TappedEventArgs)args).Parameter;
            Debug.WriteLine(args);
            Navigation.PushModalAsync(new ShowPage(param));
        }



        } 

}