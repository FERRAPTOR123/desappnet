using System;

namespace _05.ciclos
{
    class Program
    {
        static int Main(string[] args)
        {  
            int op,c=0,suma=0;
            if (args.Length==0)
            {

                
                Console.Clear();
                menu();
                return 1;
            } 

            op = int.Parse(args[0]);
            
            switch(op){
                
                case 1:{
                    c=1;
                    suma=0;
                    while(c<=100){
                        Console.Write($"{c} ");
                        suma+=c;
                        c++;
                    }
                    Console.WriteLine("La suma es "+ suma);
                }
                break;

                case 2:{
                    c=100;
                    suma=0;
                    while(c>=1){
                        Console.Write($"{c}");
                        suma+=c;
                        c++;
                    }
                    Console.WriteLine("La suma es "+ suma);
                }
                break;


                case 3:{
                    suma=0;
                    for(int i=50;i<=200;i++){
                        Console.Write($"{i}");
                        suma+=i;
                    }
                    Console.WriteLine("La suma es "+ suma);
                }
                break;
                
                case 4:{
                    suma=0;
                    for(int i=2;i<=100;i+=2){
                        Console.Write($"{i}");
                        suma+=i;
                    }
                    Console.WriteLine("La suma es "+ suma);
                }
                break;

                case 5:{
                    suma=0;
                    for(int i=99;i>0;i=2){
                        Console.Write($"{i}");
                        suma+=i;
                    }
                    Console.WriteLine("La suma es "+ suma);
                }
                break;

                case 6 : {
                    c=272;
                    suma=0;
                    while(c>=40) {
                        Console.Write($"{c} ");
                        suma+=c;
                        c-=4;
                    }
                    Console.WriteLine($"\n La suma es {suma}");
                }
                break;
            }

            return 0;
        }

        static void menu(){
            Console.WriteLine("Menu \n");
            Console.WriteLine("[1] Numeros del 1 al 100 con cliclo while");
            Console.WriteLine("[2] Nomeros del 100 al 1 con ciclo do while");
            Console.WriteLine("[3] Numeros del 50 al 200 con ciclo for");
            Console.WriteLine("[4] Nomeros del 2 al 100 solo con pares con cliclo for");
            Console.WriteLine("[5] Numeros del 99 al 1 solo con impares del ciclo for");
            Console.WriteLine("[6] Numeros del 272 al 40 en decremento de 4 con ciclo while");
        }
    }
}
