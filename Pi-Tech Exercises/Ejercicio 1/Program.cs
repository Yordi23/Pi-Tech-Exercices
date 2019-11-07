using System;

namespace Ejercicio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejercicio1 ejercicio1 = new Ejercicio1();
            Console.WriteLine("Ingrese la ruta del archivo que contiene los datos de entrada:");
            string path = Console.ReadLine();

            ejercicio1.Sort(path);
        }
    }
}
