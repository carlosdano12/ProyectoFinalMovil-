using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalMovil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Login : ContentPage
    {
        readonly UsuarioLogin usuario = new UsuarioLogin();
        public Page_Login()
        {
            InitializeComponent();
        }

        //ESTE METODO ES PARA INICIAR SESIÓN EN LA APP
        private async void Iniciar_Sesion_Btn_Clicked(object sender, EventArgs e)
        {
           
            string correo = Correo_Sesion_Txt.Text;
            string contraseña = Clave_Sesion_Txt.Text;

            var result = await usuario.logeo(correo, contraseña);

            Usuario user = (Usuario)result;

            if (user.id_usuario != 0)
            {
                await DisplayAlert("Login Exitoso", "Id: " + user.id_usuario + "Nombre: " + user.nombre, "OK");
                await Navigation.PushAsync(new Page_Asign_Clas(user));
            }
            else
            {
                await DisplayAlert("Login fallo", "Usuario No existe o la contraseña es Incorrecta", "OK");
            }
        }

        //ESTE METODO CONDUCE A UNA NUEVA PAGINA PARA REGISTRAR UN USUARIO
        private  void Registrar_Sesion_Btn_Clicked(object sender, EventArgs e)
        {            
            Navigation.PushAsync(new Page_Register());            
        }
    }
}