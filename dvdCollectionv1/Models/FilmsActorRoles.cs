using System.Collections.Generic;

namespace dvdCollection.Models {

    public class FilmsActorRoles {
        public int FilmTitleID {get; set;}
        public int ActorID {get; set;}
        public int RoleTypeID {get; set;}
        public string CharacterName {get; set;}
        public string CharacterDescription {get; set;}

        public Actors Actor {get; set;}
        public RoleTypes RoleType {get; set;}
        public FilmTitles FilmTitle {get; set;}
        
    }
}