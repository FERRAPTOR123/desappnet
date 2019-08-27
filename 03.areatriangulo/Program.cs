using System;

namespace _03.areatriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            float area, b, altura;
            Console.WriteLine("Programa que calcula el area de un triangulo");

            if (args.Length<2)
            {
                Console.WriteLine("Forma de uso \n");
                Console.WriteLine("<b> <altura>");
                Environment.Exit(0);
            }
            b=float.Parse(args[0]);
            altura=float.Parse(args[1]);
            area = (b*altura)/2;
            Console.WriteLine($"El area es {area} ");
        }
    }
}
