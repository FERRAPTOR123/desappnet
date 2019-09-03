using System;

namespace _08.vectorPromedio
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A =new int[15];
            int[] B =new int[15];
            int[] C =new int[15];
            
            Random rnd = new Random();
            
            for(int i=0; i<A.Length;i++){
                A[i]=rnd.Next(1,30);
                B[i]=rnd.Next(1,30);
                C[i]=A[i]*B[i];
            }

        Console.WriteLine("\n El vector A");imrpime(A);
        Console.WriteLine("\n El vector B");imrpime(B);
        Console.WriteLine("\n El vector C");imrpime(C);

        
        }

        static void imrpime(int[] v){
            for(int i=0; i<v.Length;i++){
                Console.Write($"{v[i]}\n");
            }
            
        }
    }
}
