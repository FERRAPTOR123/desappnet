using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace proyecto.Models {

    public class Editorial {
        public int ImprentaID {get; set;}
        public int TituloID {get; set;}

        public Imprenta Imprenta {get; set;}
        public Titulos Titulo {get; set;}
    }
}