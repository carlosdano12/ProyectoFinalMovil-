using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoFinalMovil
{
    class UsuarioLogin
    {
        public List<Usuario> Usuarios { get; set; }
        const string url = "http://10.0.2.2/apiapp/login.php";

        private async Task<HttpClient> get()
        {

            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");
            return cliente;
        }

        public async Task<Usuario> logeo(string correo, string contraseña)
        {
            Usuario user = new Usuario()
            {
                id_usuario = 0,
                nombre = "no",
                apellido = "no",
                correo = correo,
                contraseña = contraseña,
                id_tipo_identificacion = 0,
                numero_identificacion = "no",
            };
            HttpClient cliente = await get();
            var response = await cliente.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());

        }
    }
}