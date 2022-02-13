using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea1_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var pagina1 = new operaciones();
            await Navigation.PushAsync(pagina1);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaEmpleados.ItemsSource = await App.BaseDatos.listaempleados();
        }


        private async void ListaEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Empleados item = (Models.Empleados)e.Item;
            var newpage = new operaciones();
            newpage.BindingContext = item;
            await Navigation.PushAsync(newpage);
        }
    }
}
