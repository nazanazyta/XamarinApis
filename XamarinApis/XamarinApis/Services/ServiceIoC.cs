using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinApis.ViewModels;

namespace XamarinApis.Services
{
    public class ServiceIoC
    {
        IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //EMPEZAMOS A DECLARAR OBJETOS QUE NECESITAMOS QUE TENGAN COMUNICACIÓN
            //VIEWMODELS
            builder.RegisterType<DoctoresViewModel>();
            builder.RegisterType<DoctorViewModel>();
            builder.RegisterType<DoctoresFavoritosViewModel>();
            builder.RegisterType<DoctorInsertarViewModel>();
            //SERVICIO API
            builder.RegisterType<ServiceDoctores>();
            //SERVICIO SESSION
            builder.RegisterType<ServiceSession>().SingleInstance();
            //CONSTRUIMOS EL CONTAINER
            this.container = builder.Build();
        }

        //NECESITAMOS PROPIEDADES PARA PODER HACER LOS
        //BINDING DENTRO DE XAML SOBRE LAS VISTAS
        public DoctoresViewModel DoctoresViewModel
        {
            get { return this.container.Resolve<DoctoresViewModel>(); }
        }

        public DoctorViewModel DoctorViewModel
        {
            get { return this.container.Resolve<DoctorViewModel>(); }
        }

        public ServiceSession ServiceSession
        {
            get { return this.container.Resolve<ServiceSession>(); }
        }

        public DoctoresFavoritosViewModel DoctoresFavoritosViewModel
        {
            get { return this.container.Resolve<DoctoresFavoritosViewModel>(); }
        }

        public DoctorInsertarViewModel DoctorInsertarViewModel
        {
            get { return this.container.Resolve<DoctorInsertarViewModel>(); }
        }
    }
}
