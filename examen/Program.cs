using System;
using Examen.Clases;

namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            Red miRed =new Red("Red Patito, SA de CV","Mr pato McDonald","Av. Princeton 123, Orlando Florida");

            Nodo nodo1 = new Nodo("192.168.0.10","servidor","5",10,"linux");
            Nodo nodo2 = new Nodo("192.168.0.12","equipoactivo","2",12,"ios");
            Nodo nodo3 = new Nodo("192.168.0.20","computadora","8",5,"windows");
            Nodo nodo4 = new Nodo("192.168.0.15","servidor","10",22,"linux");
            miRed.AgregarNodo(nodo1);
            miRed.AgregarNodo(nodo2);
            miRed.AgregarNodo(nodo3);
            miRed.AgregarNodo(nodo4);


            

            Vulnerabilidad vul1 = new Vulnerabilidad("CVE-2015-1635","microsoft","HTTP.sys permite a atacantesremotos ejecutar código arbitrario","remota","02/12/2015");
            Vulnerabilidad vul2 = new Vulnerabilidad("CVE-2017-0004","microsoft","El servicio LSASS permite causar una denegación de servicio","local","01/10/2015");
             
            Vulnerabilidad vul3 = new Vulnerabilidad("CVE-2017-3847","cisco","Cisco Firepower Management Center XSS","remota","21/02/2017");
            
            Vulnerabilidad vul4 = new Vulnerabilidad("CVE-2009-2504","microsoft","Múltiples desbordamientos de enteros en APIs Microsoft .NET 1.1","local","14/04/2015");
            Vulnerabilidad vul5 = new Vulnerabilidad("CVE-2016-7271","microsoft","Elevación de privilegios Kernel Segura en Windows 10 Gold","local","14/04/2015");
            Vulnerabilidad vul6 = new Vulnerabilidad("CVE-2017-2996","adobe","Adobe Flash Player 24.0.0.194 corrupción de memoria explotable","remota","14/04/2015");

            nodo1.AgregarVulenerabilidad(vul1);
            nodo1.AgregarVulenerabilidad(vul2);

            nodo2.AgregarVulenerabilidad(vul3);

            nodo3.AgregarVulenerabilidad(vul4);
            nodo3.AgregarVulenerabilidad(vul5);
            nodo3.AgregarVulenerabilidad(vul6);

            Console.WriteLine("Empresa: "+miRed.Empresa);
            Console.WriteLine("Propietario: "+miRed.Propietario);
            Console.WriteLine("Domicilio: "+miRed.Domicilio+"\n");

            Console.WriteLine("Total nodos red: "+miRed.Contador_nodos);
            int totalNodos=nodo1.Contador_vulnerabilidades+nodo2.Contador_vulnerabilidades+nodo3.Contador_vulnerabilidades+nodo4.Contador_vulnerabilidades;
            Console.WriteLine("Total vulnerabilidades: "+totalNodos+"\n");

            Console.WriteLine("Ip: "+nodo1.Ip+ " Tipo: "+nodo1.Tipo + " Puertos: "+nodo1.Puertos + " Saltos: "+nodo1.Saltos + " So: "+nodo1.So+ " TotVul: "+ nodo1.Contador_vulnerabilidades); 
            Console.WriteLine("Ip: "+nodo2.Ip+ " Tipo: "+nodo2.Tipo + " Puertos: "+nodo2.Puertos + " Saltos: "+nodo2.Saltos + " So: "+nodo2.So, " TotVul: ", nodo2.Contador_vulnerabilidades);
            Console.WriteLine("Ip: "+nodo3.Ip+ " Tipo: "+nodo3.Tipo + " Puertos: "+nodo3.Puertos + " Saltos: "+nodo3.Saltos + " So: "+nodo3.So, " TotVul: ", nodo3.Contador_vulnerabilidades);
            Console.WriteLine("Ip: "+nodo4.Ip+ " Tipo: "+nodo4.Tipo + " Puertos: "+nodo4.Puertos + " Saltos: "+nodo4.Saltos + " So: "+nodo4.So, " TotVul: ", nodo4.Contador_vulnerabilidades+"\n");

            Console.WriteLine("Mayor numero de saltos: "+miRed.MayorSalto());
            Console.WriteLine("Menor numero de saltos: "+miRed.MenorSalto()+"\n");

            Console.WriteLine("Vulnerabilidades por nodo"+"\n");
            
            Console.WriteLine("Ip: "+nodo1.Ip+ " Tipo: "+nodo1.Tipo+"\n");
            Console.WriteLine("Vulnerabilidades"+"\n");
            Console.WriteLine("Clave: "+ vul1.Clave+" Vendedor: "+ vul1.Vendedor+" Descripcion: "+vul1.Descripcion+" Tipo: "+vul1.Tipo+ " Fecha: "+ vul1.Fecha+" Antiguedad en años: "+ vul1.antiguedad());
            Console.WriteLine("Clave: "+ vul2.Clave+" Vendedor: "+ vul2.Vendedor+" Descripcion: "+vul2.Descripcion+" Tipo: "+vul2.Tipo+ " Fecha: "+ vul2.Fecha+" Antiguedad en años: "+ vul2.antiguedad()+"\n");
            
            Console.WriteLine("Ip: "+nodo2.Ip+ " Tipo: "+nodo2.Tipo+"\n");
            Console.WriteLine("Vulnerabilidades"+"\n");
            Console.WriteLine("Clave: "+ vul3.Clave+" Vendedor: "+ vul3.Vendedor+" Descripcion: "+vul3.Descripcion+" Tipo: "+vul3.Tipo+ " Fecha: "+ vul3.Fecha+" Antiguedad en años: "+ vul3.antiguedad()+"\n");

            Console.WriteLine("Ip: "+nodo3.Ip+ " Tipo: "+nodo3.Tipo+"\n");
            Console.WriteLine("Vulnerabilidades"+"\n");
            Console.WriteLine("Clave: "+ vul4.Clave+" Vendedor: "+ vul4.Vendedor+" Descripcion: "+vul4.Descripcion+" Tipo: "+vul4.Tipo+ " Fecha: "+ vul4.Fecha+" Antiguedad en años: "+ vul4.antiguedad() );
            Console.WriteLine("Clave: "+ vul5.Clave+" Vendedor: "+ vul5.Vendedor+" Descripcion: "+vul5.Descripcion+" Tipo: "+vul5.Tipo+ " Fecha: "+ vul5.Fecha+" Antiguedad en años: "+ vul5.antiguedad() );
            Console.WriteLine("Clave: "+ vul6.Clave+" Vendedor: "+ vul6.Vendedor+" Descripcion: "+vul6.Descripcion+" Tipo: "+vul6.Tipo+ " Fecha: "+ vul6.Fecha+" Antiguedad en años: "+ vul6.antiguedad() +"\n");

            Console.WriteLine("Ip: "+nodo4.Ip+ " Tipo: "+nodo3.Tipo+"\n");
            Console.WriteLine("Vulnerabilidades"+"\n");
            Console.WriteLine("No hay vulneravilidades");
        }
        
    }
}
