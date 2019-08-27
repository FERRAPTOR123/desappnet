using System;

namespace _06.pizza
{
    class Program
    {
        static int Main(string[] args)
        {
            String tamano="", ingredientes="", cubierta="", para="";
            String[] ing;
            char tam,cub,par;

            if (args.Length<4)
            {
                Conosole.Clear();
                Console.WriteLine("Debes especificar como quieres tu pizza \n");
                Console.WriteLine("<Tamano> <Ingredientes> <Cubierta> <Para>");
                Menu();
                return 1;

            }


            return 0;
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("Menu \n");
            Console.WriteLine("Tamaño: (P)equena, (M)ediana,(G)rande \n");
            Console.WriteLine("Ingredientes: (E)tra queso, (C)ampiñones,(P)na \n");
            Console.WriteLine("Cubierta: (D)elgada o (G)ruesa \n");
            Console.WriteLine("Para: (C)omer aqui o Para (L)levar \n");
        }

    }
}
