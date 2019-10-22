using System.Collections.Generic;

namespace dvdCollection.Models {

    public class FilmGeneres {
        public int GenereID { get; set;}
        public string GenreDesc { get; set;}

        public ICollection<FilmTitles> FilmTitles { get; set;}

    }
}