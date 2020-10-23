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
    public partial class Page_Register : ContentPage
    {
        readonly UsuarioManager usuarioManager = new UsuarioManager();
        public Page_Register()
        {
            InitializeComponent();
        }

        //ESTE METODO REGISTRA UN NUEVO USUARIO
        private async void Crea_Usuario_Registro_Btn_Clicked(object sender, EventArgs e)
        {
            string nombre = Nombres_Registro_Txt.Text;
            string apellido = Apellidos_Registro_Txt.Text;
            string correo = Correo_Registro_Txt.Text;
            string contraseña = Clave_Registro_Txt.Text;
            int tipo_identificacion = Tipo_Id_Registro_Pk.SelectedIndex;
            string numero_identificacion = Id_Registro_Txt.Text;

            var result = await usuarioManager.Add(nombre, apellido, correo, contraseña, tipo_identificacion, numero_identificacion);
            Usuario usuario = (Usuario)result;
            if (usuario.id_usuario != 0)
            {               
                await DisplayAlert("Registro", "Registrado Exitosamente", "OK");
                await Navigation.PushAsync(new Page_Asign_Clas(usuario));
            }
            else
            {
                await DisplayAlert("Registro fallo", "No se pudo rigistrar como un usuarios, esposible que ya exista una cuenta con ese correo", "OK");
            }

        }

        //ESTE METODO TE REGRESA AL LOGIN
        private void Cancelar_Btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}