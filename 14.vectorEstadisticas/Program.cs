using System;

namespace _14.vectorEstadisticas
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] A;
            int n=0;
            Console.WriteLine("Cuantos elementos? ");
            n=int.Parse(Console.ReadLine());

            A = new double[n];

            Console.WriteLine("Dame los elementos del arreglo \n");
            leer(A);

            Console.WriteLine("Estadisticas \n");
            Console.WriteLine($"mayor {mayor(A)}");
            Console.WriteLine($"menor {menor(A)}");
            Console.WriteLine($"media {media(A)}");
            Console.WriteLine($"Varianza {varianza(A,media(A))}");
            Console.WriteLine($"Desv Estandar {Math.Sqrt(varianza(A,media(A)))}");
            
        }



        static double varianza(double[] v, double media){
            double s=0;
            for (int i=0; i<v.Length;i++)
            {
                s+= Math.Pow(v[i]-media,2);
            }
            return s/v.Length-1;
        }
        static double media(double[] v){
            double s=0;
            for (int i=0; i<v.Length; i++)
            {
                s+=v[i];
            }   
            return s/v.Length;
        }
        static double mayor(double[] v){
            double m=v[0];
            for(int i=1; i<v.Length;i++){
                if (v[i]>m)
                {
                    m=v[i];
                }
            
            }
            return m;
        }

        static double menor(double[] v) {
            double m=v[0];
            for(int i=1; i<v.Length;i++){
                if (v[i]<m)
                {
                    m=v[i];
                }
            
            }
            return m;
        }

        static void leer(double [] v){
            for(int i=0; i<v.Length;i++){
                Console.WriteLine($"Elemento [{i+1}]=");
                v[i]=double.Parse(Console.ReadLine());
            }
        }
    }
}
