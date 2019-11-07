using System;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejercicio3 ejercicio = new Ejercicio3();


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\EjercicioPorcentaje.json";
            ejercicio.GenerateExercise(path);

            Console.WriteLine("El archivo en formato Json ha sido exportado exitosamente en el escritorio.");
        }
    }
}
