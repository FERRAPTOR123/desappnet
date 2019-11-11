using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Examen2.Models;

namespace Examen2.Data 
{
    public static class DbInitializer {
        public static void Initializate(Examen2CollectionContext context) {
            context.Database.EnsureCreated(); // crea bd si no existe

            if(context.PaymentMethods.Any()) {
                return; // la bd ya tiene datos
            }

            // arreglo del tipo FilmGeneres 
            var PaymentMethods = new PaymentMethods[] {
                new PaymentMethods {PaymentMethod="Efectivo"},
                new PaymentMethods {PaymentMethod="Debito"},
                new PaymentMethods {PaymentMethod="Credito"},

            };
            // pasar el arreglo a la tabla de FilmGeneres en el modelo
            foreach(PaymentMethods g in PaymentMethods) {
                context.PaymentMethods.Add(g);
            }
            //grabar los datos en la bd fisica
            context.SaveChanges();      

            // FilmCertificates
            var RoomTypes = new RoomTypes[] {
                new RoomTypes {RoomType="Para 2"},
                new RoomTypes {RoomType="Para 3"},
                new RoomTypes {RoomType="Para 4"},
                new RoomTypes {RoomType="Swit"},
                new RoomTypes {RoomType="Lujo"},
            };
            foreach(RoomTypes f in RoomTypes) {
                context.RoomTypes.Add(f);
            }
            context.SaveChanges();

        }
    }
}