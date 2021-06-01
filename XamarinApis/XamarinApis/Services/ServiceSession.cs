using System;
using System.Collections.Generic;
using System.Text;
using XamarinApis.Models;

namespace XamarinApis.Services
{
    public class ServiceSession
    {
        public List<Doctor> Favoritos { get; set; }

        public ServiceSession()
        {
            this.Favoritos = new List<Doctor>();
        }
    }
}
