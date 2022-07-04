using CRUD_de_Alumnos.Models;
using CRUD_de_Alumnos.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUD_de_Alumnos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        MainViewModel Vm { get { return BindingContext as MainViewModel; } }

        public async void UpdateRow_Tapped(object sender, EventArgs e)
        {
            var contenedor = ((Frame)sender).GestureRecognizers[0];

            AlumnoModel alumnoModel = ((TapGestureRecognizer)contenedor).CommandParameter as AlumnoModel;


            string Nombre = await DisplayPromptAsync("Actualizar Nombre", alumnoModel.AlumnoNombre);
            string Promedio = await DisplayPromptAsync("Actualizar Promedio", alumnoModel.AlumnoPromedio.ToString());
            string Fecha = await DisplayPromptAsync("Actualizar Fecha", alumnoModel.AlumnoFecha.ToString("dd-MM-yyyy"));
            string Sexo = await DisplayPromptAsync("Cambiar de sexo", alumnoModel.AlumnoSexo.ToString());

            alumnoModel.AlumnoNombre = Nombre;
            alumnoModel.AlumnoPromedio = Convert.ToDouble(Promedio);
            alumnoModel.AlumnoFecha = Convert.ToDateTime(Fecha);
            alumnoModel.AlumnoSexo = Convert.ToBoolean(Sexo);

            Vm.UpdateRowCommand.Execute(alumnoModel);

        }
        void DeliveryYN(object sender, EventArgs args)
        {
            RadioButton radioButton = sender as RadioButton;
            label.Text = $"{radioButton.Content}";
        }

        private async void DeleteRow_Swiped(object sender, SwipedEventArgs e)
        {

            bool resultado = await DisplayAlert("Eliminar", "¿Seguro que desea eliminar el registro?", "Sí", "No");

            if (resultado)
            {
                var contenedor = ((Frame)sender).GestureRecognizers[0];

                AlumnoModel alumnoModel = ((TapGestureRecognizer)contenedor).CommandParameter as AlumnoModel;

                Vm.DeleteRowCommand.Execute(alumnoModel);
            }

        }

    }
}
