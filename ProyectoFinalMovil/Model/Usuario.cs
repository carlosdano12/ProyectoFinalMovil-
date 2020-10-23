using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMovil
{
    public class Usuario
    {

        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public int id_tipo_identificacion { get; set; }
        public string numero_identificacion { get; set; }

        public override string ToString()
        {
            return id_usuario + " " + nombre + " " + apellido;
        }
    }
}