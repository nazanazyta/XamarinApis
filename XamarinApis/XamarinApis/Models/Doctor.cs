using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApis.Models
{
    public class Doctor
    {
        [JsonProperty("idDoctor")]
        public int IdDoctor { get; set; }
        [JsonProperty("apellido")]
        public String Apellido { get; set; }
        [JsonProperty("especialidad")]
        public String Especialidad { get; set; }
        [JsonProperty("hospital")]
        public int IdHospital { get; set; }
        [JsonProperty("salario")]
        public int Salario { get; set; }
    }
}
