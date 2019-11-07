using System;

namespace Ejercicio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejercicio2 ejercicio = new Ejercicio2();

           
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\EjercicioSuma.json";
            ejercicio.GenerateExercise(path);

            Console.WriteLine("El archivo en formato Json ha sido exportado exitosamente en el escritorio.");
        }
    }
}
