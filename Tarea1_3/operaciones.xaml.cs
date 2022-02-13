using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tarea1_3.Models;
namespace Tarea1_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class operaciones : ContentPage
    {
        public operaciones()
        {
            InitializeComponent();
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleados
            {
                nombres = Nombres.Text,
                apellidos = Apellidos.Text,
                edad = Convert.ToInt32(Edad.Text),
                correo = correo.Text,
                direccion = direccion.Text
            };
            var resultado = await App.BaseDatos.EmpleadoGuardar(emple);
            if (resultado != 0)
            {
                await DisplayAlert("Aviso", "Empleado Ingresado con exito!!", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Error!!", "OK");
            }
            await Navigation.PopAsync();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleados
            {   
                codigo= Convert.ToInt32(Codigo.Text),
                nombres = Nombres.Text,
                apellidos = Apellidos.Text,
                edad = Convert.ToInt32(Edad.Text),
                correo = correo.Text,
                direccion = direccion.Text
            };
            var resultado = await App.BaseDatos.EmpleadoGuardar(emple);
            if (resultado != 0)
            {
                await DisplayAlert("Aviso", "Empleado Actualizado con exito!!", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Error!!", "OK");
            }
            await Navigation.PopAsync();

        }

        private async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleados
            {
                codigo = Convert.ToInt32(Codigo.Text)
            };
            var resultado = await App.BaseDatos.EmpleadoBorrar(emple);
            if (resultado != 0)
            {
                await DisplayAlert("Aviso", "Empleado Borrado con exito!!", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Error!!", "OK");
            }
            await Navigation.PopAsync();
        }
    }
}