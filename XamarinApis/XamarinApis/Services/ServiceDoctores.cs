using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinApis.Models;

namespace XamarinApis.Services
{
    public class ServiceDoctores
    {
        private String url;

        public ServiceDoctores()
        {
            this.url = "https://apicruddoctorespgs.azurewebsites.net/";
        }

        //private HttpClient GetClient()
        //{
        //    HttpClient client = new HttpClient();
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    return client;
        //}

        private async Task<T> CallApiAsync<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            String request = "api/doctores";
            List<Doctor> doctores = await this.CallApiAsync<List<Doctor>>(request);
            return doctores;
        }

        public async Task<Doctor> FindDoctorAsync(int id)
        {
            String request = "api/doctores/" + id;
            Doctor doctor = await this.CallApiAsync<Doctor>(request);
            return doctor;
        }

        public async Task CreateDoctorAsync(int iddoctor, String apellido, String especialidad, int idhospital, int salario)
        {
            Doctor doctor = new Doctor();
            doctor.IdDoctor = iddoctor;
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.IdHospital = idhospital;
            doctor.Salario = salario;
            String json = JsonConvert.SerializeObject(doctor);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores";
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage response = await client.PostAsync(uri, content);
            }
        }

        public async Task UpdateDoctorAsync(int iddoctor, String apellido, String especialidad, int idhospital, int salario)
        {
            Doctor doctor = await this.FindDoctorAsync(iddoctor);
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.IdHospital = idhospital;
            doctor.Salario = salario;
            String json = JsonConvert.SerializeObject(doctor);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores";
                Uri uri = new Uri(this.url + request);
                HttpResponseMessage response = await client.PutAsync(uri, content);
            }
        }

        public async Task DeleteDoctorAsync(int id)
        {
            String request = "api/doctores/" + id;
            Uri uri = new Uri(this.url + request);
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync(uri);
            }
        }
    }
}
