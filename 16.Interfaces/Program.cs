using System;
using Interfaces.Clases;
using System.Collections.Generic;

namespace _16.Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {

            List <Caja> costal= LlenarCostal();
            Caja miCaja = new Caja("Roja", true, "Calzones rojos",10,20);
            Console.WriteLine("Ejemplo de interfaces \n\n");

            costal.Add(miCaja);
            foreach (Caja c in costal)
            {
            Console.WriteLine("Color: "+ c.Color);
            Console.WriteLine("Estatus: "+ c.EstaAbierta);
            Console.WriteLine("Contenido: "+ c.Contenido);
            Console.WriteLine("Dimenciones: "+ c.Medidas());   
            }
            
            
        }

        static List<Caja> LlenarCostal(){
            List<Caja> todo = new List<Caja>();

            todo.Add(new Caja("Rojo", false,"Manzanas",10,10));
            todo.Add(new Caja("Azul", false,"Peras",15,5));
            todo.Add(new Caja("Blanco", false,"Carbon",87,6));
            return todo;
        }
    }
}
