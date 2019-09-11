using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Examen.Clases
{
    public class Vulnerabilidad {
         
        protected string clave; // permite acceso a las clases q hereden
        protected string vendedor;
        protected string descripcion;
        protected string tipo;
        protected string fecha;
        DateTime hoy = DateTime.Today;
        DateTime fecha_DataTime;
        double horas;
        public Vulnerabilidad() {

        }
        public Vulnerabilidad(string clave, string vendedor, string descripcion,string tipo,string fecha) {
            this.clave = clave;
            this.vendedor = vendedor;
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.fecha = fecha;
        }
             
        public string Clave
        {
            get { return clave;}
        }

        public string Vendedor
        {
            get { return vendedor;}
        }

        public string Descripcion
        {
            get { return descripcion;}
        }

        public string Tipo
        {
            get { return tipo;}
        }

        public string Fecha
        {
            get { return fecha;}
        }

        public double antiguedad(){
            fecha_DataTime=Convert.ToDateTime(fecha,new CultureInfo("es-ES"));
            var dias=(DateTime.Now-fecha_DataTime).TotalDays;
            return dias/365;
        }


        
    }


}
