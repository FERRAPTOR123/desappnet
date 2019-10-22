using System.Collections.Generic;

namespace dvdCollection.Models {

    public class RoleTypes {
        public int RoleTypeID { get; set;}
        public string RoleDesc { get; set;}

        public ICollection<FilmsActorRoles> FilmActorRoles { get; set;}

    }
}