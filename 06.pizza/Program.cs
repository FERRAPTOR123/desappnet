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
                Console.Clear();
                Console.WriteLine("Debes especificar como quieres tu pizza \n");
                Console.WriteLine("<Tamano> <Ingredientes> <Cubierta> <Para>");
                Menu();
                return 1;
            }

            //tamano
            tam=char.Parse(args[0]);
            if (tam=='P') tamano="Pequeño";
            else if(tam=='M') tamano="Mediana";
            else tamano = "Grande";

            //ingredientes
            ing= args[1].Split("+");
            foreach(string i in ing){
                if(i=="E") ingredientes+="Extra Queso ";
                else if(i=="C") ingredientes+="Champinones ";
                else if(i=="P") ingredientes+="Piña ";
            }
            
            //cubierta
            cub=char.Parse(args[2]);
            if (cub=='D') cubierta="Delgada";
            else cubierta = "Gruesa";

            //Para
            par=char.Parse(args[3]);
            if (par=='C') para="Comer Aqui";
            else para = "Para llevar";


            //imprima la orden
            Console.WriteLine("Tu pizza quedo de la siguiente forma:  \n");
            Console.WriteLine("Tamano "+tamano+"\n");
            Console.WriteLine("Ingredientes "+ingredientes+"\n");
            Console.WriteLine("Cubierta "+cubierta+"\n");
            Console.WriteLine("Para "+para+"\n");
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
