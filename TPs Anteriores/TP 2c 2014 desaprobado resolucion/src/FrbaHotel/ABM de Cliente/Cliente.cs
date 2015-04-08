using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.ABM_de_Cliente
{
 public class Cliente
    {
      

        public string id { get; set; }
        public string pasaporteNumero { get; set; }
        public string tipoPasaporte { get; set; }
        public string mail { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string calleDomicilio { get; set; }
        public string numeroCalle { get; set; }
        public string piso { get; set; }
        public string depto { get; set; }
        public string nacionalidad { get; set; }
        public string ciudadResidencia { get; set; }
        public string paisResidencia { get; set; }
        public string tarjetaDeCredito { get; set; }
        public Boolean habilitado { get; set; }





        public Cliente()
        {
        }

        public Cliente(string unId,string numPas,string tipoPas,string unMail,string ape,
                        string nom,DateTime fecnac,string calleDom,
                         string calleNum,string unPiso,string unDepto,string nacion,
                        string ciudadRes,string paisRes,string tarjCred,Boolean habilitado)
       {

           
           this.id = Convert.ToString(unId);
           this.pasaporteNumero = Convert.ToString(numPas);
           this.tipoPasaporte = Convert.ToString(tipoPas);
           this.mail = Convert.ToString(unMail);
           this.apellido = Convert.ToString(ape);
           this.nombre = Convert.ToString(nom);
           this.fechaNacimiento = Convert.ToDateTime(fecnac);
           this.calleDomicilio = Convert.ToString(calleDom);
           this.numeroCalle = Convert.ToString(calleNum);
           this.piso = Convert.ToString(unPiso);
           this.depto = Convert.ToString(unDepto);
           this.nacionalidad = Convert.ToString(nacion);
           this.ciudadResidencia = Convert.ToString(ciudadRes);
           this.paisResidencia = Convert.ToString(paisRes);
           this.tarjetaDeCredito = Convert.ToString(tarjCred);
           this.habilitado = habilitado;

        





        }

     


 
    }

  
}
