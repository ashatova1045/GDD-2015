using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.ABM_de_Usuario
{
    public class Usuario
    {
        public int id { get; set; }
        public String username { get; set; }
        public String contrasena { get; set; }
        public int tipoPasaporte { get; set; }
        public decimal numeroPasaporte { get; set; }
        public String direccion { get; set; }
        public String fecNac { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String mail { get; set; }
        public decimal telefono { get; set; }
     

        public Boolean habilitado { get; set; }

        public Usuario()
        {
           
        }



    }

}