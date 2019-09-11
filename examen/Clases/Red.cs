using System.Collections.Generic;

namespace Examen.Clases{
    public class Red {
        private string empresa;
        private string propietario;
        private string domicilio;
        private int contador_nodos;
        private List<Nodo> nodos;

        public Red(string empresa,string propietario,string domicilio) {
            this.empresa=empresa;
            this.propietario=propietario;
            this.domicilio=domicilio;

            nodos = new List<Nodo>();
        }
        public string Empresa {
            get {return empresa;}
        }

        public string Propietario {
            get {return propietario;}
        }

        public string Domicilio {
            get {return domicilio;}
        }

        public int Contador_nodos {
            get {return contador_nodos;}
        }
        public List<Nodo> Nodos {
            get {return nodos;}
        }

        

        public void AgregarNodo(Nodo nod) {
            nodos.Add(nod);
            contador_nodos++;
        }

        public int MayorSalto(){
            int mayor=0;
            foreach (Nodo item in nodos)
            {
                if(mayor<item.Saltos){
                    mayor=item.Saltos;
                }
            }
            return mayor;
        }

        public int MenorSalto(){
            int mayor=0;
            foreach (Nodo item in nodos)
            {
                if(mayor>item.Saltos){
                    mayor=item.Saltos;
                }
            }
            return mayor;
        }


    }
}