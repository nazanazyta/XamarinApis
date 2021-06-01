using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModels
{
    public class DoctoresFavoritosViewModel: ViewModelBase
    {

        public DoctoresFavoritosViewModel()
        {
            ServiceSession session = App.ServiceLocator.ServiceSession;
            this.Doctores = new ObservableCollection<Doctor>(session.Favoritos);
        }

        private ObservableCollection<Doctor> _Doctores;
        public ObservableCollection<Doctor> Doctores
        {
            get { return this._Doctores; }
            set
            {
                this._Doctores = value;
                OnPropertyChanged("Doctores");
            }
        }
    }
}
