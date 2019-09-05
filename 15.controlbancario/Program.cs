using System;
using ControlBancario.Clases;

namespace ControlBancario
{
    class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria micuenta1 = new CuentaBancaria();
            CuentaBancaria micuenta2 = new CuentaBancaria(1000);
            CuentaDeAhorros miahorro = new CuentaDeAhorros(600,0.3);
            CuentaDeCheques micheque = new CuentaDeCheques(5000,1000);

            micuenta1.Deposita(300);
            micuenta2.Retira(500);
            miahorro.Deposita(100);
            miahorro.Retira(50);
            micheque.Deposita(3000);
            micheque.Retira(9000);
            
            Console.WriteLine($"Cuenta 1 : {micuenta1.Saldo}");
            Console.WriteLine($"Cuenta 2 : {micuenta2.Saldo}");
            Console.WriteLine($"Cuenta 3 : {miahorro.Saldo}");
            Console.WriteLine($"Cuenta 4 : {micheque.Saldo}");

            // Probar cliente y banco

            Banco MiBanco = new Banco("Mac Pato Ricon SA de CV");

            Cliente cte1 = new Cliente("Chente Fox");
            Cliente cte2 = new Cliente("Felipe Beberon");
            Cliente cte3 = new Cliente("Lord Peña");
            Cliente cte4 = new Cliente("Cabezita de Algodon");

            cte1.AgregarCuenta(new CuentaDeCheques(2000,1000));
            cte2.AgregarCuenta(new CuentaDeCheques(1000,200));
            cte3.AgregarCuenta(new CuentaDeCheques(900,100)); 
            cte4.AgregarCuenta(new CuentaDeCheques(12000,1000));
            cte4.AgregarCuenta(new CuentaDeAhorros(2000,0.3));

            cte1.Cuentas[0].Retira(300);
            cte3.Cuentas[0].Deposita(1200);
            cte4.Cuentas[1].Retira(1000);

            MiBanco.AgregarCliente(cte1);
            MiBanco.AgregarCliente(cte2);
            MiBanco.AgregarCliente(cte3);
            MiBanco.AgregarCliente(cte4);

            MiBanco.AgregarCliente(new Cliente("Tello Chorejas"));
            MiBanco.Clientes[4].AgregarCuenta(new CuentaDeCheques(3000,900));

            Console.WriteLine("------- Reporte de Clientes ------- \n");
            Console.WriteLine($"{MiBanco.Nombre}");
            
            foreach(Cliente cte in MiBanco.Clientes) {
                Console.WriteLine($"Cliente: {cte.Nombre}");
                foreach(CuentaBancaria cta in cte.Cuentas) {
                    if(cta is CuentaDeAhorros) 
                        Console.WriteLine($"Cuenta de Ahorros {cta.Saldo} ");
                    else
                        Console.WriteLine($"Cuenta de Cheques {cta.Saldo} ");
                }
                Console.WriteLine("");
            }

            





            

        }
        
    }
}
