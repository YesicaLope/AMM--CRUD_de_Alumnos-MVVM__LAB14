using CRUD_de_Alumnos.BL;
using CRUD_de_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_de_Alumnos.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        Alumno alumno = new Alumno();


        private ObservableCollection<AlumnoModel> listAlumno;
        public ObservableCollection<AlumnoModel> ListAlumno
        {
            get { return listAlumno; }
            set { listAlumno = value; RaisePropetyChanged(); }
        }



        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; RaisePropetyChanged(); }
        }

        private string promedio;
        public string Promedio
        {
            get { return promedio; }
            set { promedio = value; RaisePropetyChanged(); }
        }

        private string fecha;
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; RaisePropetyChanged(); }
        }

        private string sexo;
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; RaisePropetyChanged(); }
        }


        public ICommand InsertRowCommand { get; set; }
        public ICommand UpdateRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand DeleteAllRowCommand { get; set; }

        public MainViewModel()
        {

            DeleteRowCommand = new Command<AlumnoModel>(execute: async (alumnoModel) => {
                await alumno.DeleteAlumno(alumnoModel);

                LoadListAlumno();
            });

            DeleteAllRowCommand = new Command(execute: async () => {
                await alumno.DeleteAllAlumno();
                LoadListAlumno();
            });

            UpdateRowCommand = new Command<AlumnoModel>(execute: async (alumnoModel) => {
                await alumno.UpdateAlumno(alumnoModel);

                LoadListAlumno();
            });

            InsertRowCommand = new Command(execute: async () => {

                await alumno.InsertAlumno(new AlumnoModel()
                {
                    AlumnoNombre = Nombre,
                    AlumnoPromedio = Convert.ToDouble(Promedio),
                    AlumnoFecha = Convert.ToDateTime(Fecha),
                    AlumnoSexo = Convert.ToBoolean(Sexo)
                });
                Nombre = nombre;
                Promedio = promedio;
                Fecha = fecha;
                Sexo = sexo;

                LoadListAlumno();
            });


            LoadListAlumno();


        }
        async void LoadListAlumno()
        {

            ListAlumno = new ObservableCollection<AlumnoModel>(await alumno.GetListAlumno());
        }

    }
}
