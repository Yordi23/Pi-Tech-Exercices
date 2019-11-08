using System;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejercicio4 ejercicio = new Ejercicio4();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\EjercicioEscrituraNumeros.json";
            ejercicio.GenerateExercise(path);

            Console.WriteLine("El archivo en formato Json ha sido exportado exitosamente en el escritorio.");
        }
    }
}
