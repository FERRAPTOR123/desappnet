using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyecto.Data 
{
    public static class DbInitializer {
        public static void Initializate(proyectoContext context) {
            context.Database.EnsureCreated(); // crea bd si no existe

            if(context.Generos.Any()) {
                return; // la bd ya tiene datos
            }

            // arreglo del tipo Generos 
            var Generos = new Generos[] {
                new Generos {GeneroDesc="Dama"},
                new Generos {GeneroDesc="Romance"},
                new Generos {GeneroDesc="Animacion"},
                new Generos {GeneroDesc="Historico"},
                new Generos {GeneroDesc="Ficcion"},
                new Generos {GeneroDesc="Crimen"},
                new Generos {GeneroDesc="Terror"},
            };
            // pasar el arreglo a la tabla de Generos en el modelo
            foreach(Generos g in Generos) {
                context.Generos.Add(g);
            }
            //grabar los datos en la bd fisica
            context.SaveChanges(); 
            // Autores
            var Autores = new Autores[] {
                new Autores {AutorFullName="Pablo Cohelo",AutorNotes="Escritor de historias religiosas de por medio"},
                new Autores {AutorFullName="Manuel de cervantez",AutorNotes="Escritor Mexicano reconocido a nivel mundial ganador de un oscar"},
                new Autores {AutorFullName="Maria de la cruz",AutorNotes="Escritora de historias romanticas"}
            };
            foreach(Autores a in Autores) {
                context.Autores.Add(a);
            }
            context.SaveChanges();

            // Imprenta
            var Imprenta = new Imprenta[] {
                new Imprenta {ImprentaName="Alejandro González Iñárritu",ContactEmailAddress="alegon@gmail.com",WebSite="http://alegon.com"},
                new Imprenta {ImprentaName="Alfonso Cuarón",ContactEmailAddress="cuaron@yahoo.com",WebSite="http://cuaron.tv   "},
                new Imprenta {ImprentaName="Guillermo del Toro",ContactEmailAddress="deltoro@gmail.com",WebSite="http://deltoro.com"},
            };
            foreach(Imprenta p in Imprenta) {
                context.Imprenta.Add(p);
            }
            context.SaveChanges();

            // Titulos
            var Titulos = new Titulos[] {
                new Titulos {Titulo="El laberinto del fauno",
                GeneroID=1, LibroRelaseDate=DateTime.Parse("1/1/2010"),
                NumeroDePaginas=120, Prologo="El fauno asusta la niña" }
            };
            foreach(Titulos t in Titulos) {
                context.Titulos.Add(t);
            }
            context.SaveChanges();




        }
    }
}