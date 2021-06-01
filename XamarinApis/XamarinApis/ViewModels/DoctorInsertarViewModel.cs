using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModels
{
    public class DoctorInsertarViewModel: ViewModelBase
    {
        ServiceDoctores ServiceDoctores;

        public DoctorInsertarViewModel(ServiceDoctores serviceDoctores)
        {
            this.ServiceDoctores = serviceDoctores;
            this.Doctor = new Doctor();
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

        public Command InsertarDoctor
        {
            get
            {
                return new Command(async() =>
                {
                    await this.ServiceDoctores.CreateDoctorAsync(Doctor.IdDoctor, Doctor.Apellido,
                        Doctor.Especialidad, Doctor.IdHospital, Doctor.Salario);
                    await Application.Current.MainPage.DisplayAlert("Alert", "Doctor insertado", "OK");
                });
            }
        }
    }
}
