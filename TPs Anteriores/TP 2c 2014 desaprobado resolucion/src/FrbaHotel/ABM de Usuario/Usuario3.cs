using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.OperacionesDB.ModeloSistema;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.ABM_de_Hotel;

namespace FrbaHotel.ABM_de_Usuario
{
    public class Usuario
    {
        public String id { get; set; }
        public String username { get; set; }
        public String contrasena{get;set;}
        public String tipoPasaporte { get; set; }
        public String numeroPasaporte { get; set; }
        public String direccion { get; set; }
        public String fecNac { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String mail { get; set; }
        public String telefono { get; set; }
        //public List<Rol> roles { get; set; }
        //public List<Hotel> hoteles { get; set; }
        //hotel seleccionado para desempeñar operaciones en este preciso momento
        //public Hotel hotelActual { get; set; }
        //public Rol rolAlctual { get; set; }

        public Boolean habilitado { get; set; }

        public Usuario()
        {
            //constructor del usario
        }


    }
}
