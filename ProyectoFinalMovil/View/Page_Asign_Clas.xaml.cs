using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalMovil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Asign_Clas : TabbedPage
    {
        
        public Page_Asign_Clas(Usuario usuario)
        {
            InitializeComponent();            
        }

        //ESTE METODO CAMBIA DE VISTA PARA CREAR UNA NUEVA ASIGNATURA
        private void Btn_Nueva_Asignatura(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page_Nueva_Asignatura());
        }
    }
}