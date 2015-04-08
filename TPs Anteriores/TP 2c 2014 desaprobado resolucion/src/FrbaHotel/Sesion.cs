using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{

    using System;

    public class Singleton
    {
        private static Singleton instance;
        public int usuarioID;
        public int hotel;
        public int rol_cod;
        public string hotel_nombre;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
