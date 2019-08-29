using System;

namespace _08.vectorPromedio
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vector = 
            {10,20,30,40,50,60,70,80,90,100,
            10,20,30,40,50,60,70,80,90,100,
            10,20,30,40,50,60,70,80,90,100,
            10,20,30,40,50,60,70,80,90,100,};

            int suma=0, nmp=0;
            float promedio=0;
            
            for(int i=0; i<vector.Length;i++){
                Console.WriteLine($"{vector[i]} ");
                suma+= vector[i];
            }

            promedio=suma/vector.Length;
            Console.WriteLine($"El promedio es{nmp}\n");

            Console.WriteLine("Numeros mayor que el promedio\n");
            for(int i=0; i<vector.Length;i++){
                if (vector[i]>promedio)
                {
                    Console.WriteLine($"{vector[i]} ");
                    nmp++;
                }
            }

            Console.WriteLine($"Mayores que el promedio {nmp}");
        }
    }
}
