using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyecto.Models {

    public class Autores {
        [Key]
        [Display(Name="ID")]
        public int AutorID { get; set;}
        [Display(Name="Name",Prompt="Nombre completo del autor")]
        [Required(ErrorMessage="El nombre del autor es obligatorio")]
        [StringLength(80)]
        public string AutorFullName { get; set;}
        [Display(Name="Notes",Prompt="Notas adicionales del autor")]
        [StringLength(300)]
        public string AutorNotes { get; set;}

        }
}