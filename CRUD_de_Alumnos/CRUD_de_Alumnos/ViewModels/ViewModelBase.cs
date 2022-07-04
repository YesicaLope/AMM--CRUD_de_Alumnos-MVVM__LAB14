﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CRUD_de_Alumnos.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropetyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            var cambio = PropertyChanged;
            if (cambio != null)
            {
                cambio(this, new PropertyChangedEventArgs(nombrePropiedad));
            }
        }
    }
}
