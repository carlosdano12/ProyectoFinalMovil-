using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoFinalMovil
{
    class UsuarioManager
    {

        public List<Usuario> Usuarios { get; set; }
        const string url = "http://10.0.2.2/apiapp/api.php";

        private async Task<HttpClient> get()
        {

            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");
            return cliente;
        }

        public async Task<List<Usuario>> GetAll()
        {


            HttpClient client = await get();
            string result = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<List<Usuario>>(result);
        }

        public async Task<Usuario> Add(string nombre, string apellido, string correo, string contraseña, int tipo_identificaion, string numero_identificacion)
        {
            Usuario user = new Usuario()
            {
                id_usuario = 0,
                nombre = nombre,
                apellido = apellido,
                correo = correo,
                contraseña = contraseña,
                id_tipo_identificacion = tipo_identificaion,
                numero_identificacion = numero_identificacion
            };
            HttpClient cliente = await get();
            var response = await cliente.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());

        }
    }
}

