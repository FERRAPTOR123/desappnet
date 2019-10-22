using System;
using System.Collections.Generic;

namespace dvdCollection.Models {

    public class FilmTitles {
        public int FilmTitleID { get; set;}
        public string FilmTitle { get; set;}
        public string FilmStory { get; set;}
        public DateTime FilmRelaseDate { get; set;}
        public int FilmDuration { get; set;}
        public int FilmGenereID { get; set;}
        public int FilmCertificateID { get; set;}
        public string FilmAdditionalInfo { get; set;}

        public FilmGeneres Genere { get; set;}
        public Certificates Certificate { get; set;}

        public ICollection<FilmTitlesProducers> FilmTitlesProducers { get; set;}
        public ICollection<FilmsActorRoles> FilmActorRoles { get; set;}

         

    }
}