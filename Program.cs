using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivHilos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hilos hilos = new Hilos();

            while (hilos.terminado < 2) { }

            Console.Write("Finalizo el programa");

            Console.ReadKey();
        }
    }
}