using System.Collections.Generic;

namespace Examen.Clases
{
    public class Nodo {
        private string ip;
        private string tipo;
        private string puertos;
        private int saltos;
        private string so;

        private int contador_vulnerabilidades;
        private List<Vulnerabilidad> vulnerabilidades;

        public Nodo(string ip,string tipo,string puertos,int saltos,string so) {
            this.ip = ip;
            this.tipo= tipo;
            this.puertos= puertos;
            this.saltos= saltos;
            this.so= so;
            vulnerabilidades = new List<Vulnerabilidad>();
        }

        public string Ip {
            get {return ip;}
        }
        public string Tipo {
            get {return tipo;}
        }
        public string Puertos {
            get {return puertos;}
        }
        public int Saltos {
            get {return saltos;}
        }
        public string So {
            get {return so;}
        }

        public int Contador_vulnerabilidades {
            get {return contador_vulnerabilidades;}
        }

        public List<Vulnerabilidad> Vulnerabilidades {
            get {return vulnerabilidades;}
        }

        public void AgregarVulenerabilidad(Vulnerabilidad vul) {
            vulnerabilidades.Add(vul);
            contador_vulnerabilidades++;
        }



    }
}