using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModels
{
    public class DoctorViewModel: ViewModelBase
    {
        ServiceDoctores ServiceDoctores;

        public DoctorViewModel(ServiceDoctores servicedoctores)
        {
            this.ServiceDoctores = servicedoctores;
        }

        private Doctor _Doctor;
        public Doctor Doctor
        {
            get { return this._Doctor; }
            set
            {
                this._Doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        public Command EliminarDoctor
        {
            get
            {
                return new Command(async () =>
                {
                    await this.ServiceDoctores.DeleteDoctorAsync(Doctor.IdDoctor);
                    MessagingCenter.Send(App.ServiceLocator.DoctoresViewModel, "Recargar");
                    await Application.Current.MainPage.DisplayAlert("Alert", "Doctor " + Doctor.Apellido + " eliminado", "OK");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command MarcarFavorito
        {
            get
            {
                return new Command(async () =>
                {
                    ServiceSession session = App.ServiceLocator.ServiceSession;
                    session.Favoritos.Add(this.Doctor);
                    await Application.Current.MainPage.DisplayAlert("Alert", "Doctor almacenado", "OK");
                });
            }
        }
    }
}
