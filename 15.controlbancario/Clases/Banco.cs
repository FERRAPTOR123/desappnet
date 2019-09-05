using System.Collections.Generic;

namespace ControlBancario.Clases{
    public class Banco {
        private string nombre;
        private List<Cliente> clientes;

        public Banco(string nombre) {
            this.nombre=nombre;
            clientes = new List<Cliente>();
        }

        public string Nombre {
            get {return nombre;}
        }

        public List<Cliente> Clientes {
            get {return clientes;}
        }

        public void AgregarCliente(Cliente cte) {
            clientes.Add(cte);
        }

    }
}