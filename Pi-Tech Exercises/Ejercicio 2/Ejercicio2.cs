using Newtonsoft.Json;
using System;
using System.IO;

namespace Ejercicio_2
{
    class Ejercicio2
    {   
        //Nota: A pesar de que en el ejemplo se muestra que dentro del archivo Json el campo de 
        //resultado es igual a 0, asumí que este campo corresponde al resultado de realizar la 
        //operación de suma.
        public void GenerateExercise(string path)
        {
            string instruction = "Selecciona el resultado de la siguiente suma.";
            string[] problem = new string[2];
            string[] options = new string[4];
            int result = 0;
            Random rdn = new Random();


            //Generamos de manera aleatoria dos números para realizar la operación de suma.
            for (int i = 0; i < problem.Length; i++)
            {
                //Debido a que no se especifica en el ejercicio, elegí arbitrariamente que 
                //el número máximo para realizar las operaciones de suma sería 100,000.
                int num = rdn.Next(100001);
                result += num;
                problem[i] = String.Format("{0:n0}", num);
            }


            options[rdn.Next(4)] = String.Format("{0:n0}", result);
            options = GenerateOptions(options);


            EjercicioSuma ejercicio = new EjercicioSuma(instruction,problem,options,result);
            SerializeAndExport(path, ejercicio);
        }
        


        //Se generan opciones aleatorias.
        private string[] GenerateOptions (string[] arr)
        {
            Random rdn = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                //El máximo resultado posible es 200,000 (100,000 + 100,000)
                if (arr[i] == null) arr[i] = String.Format("{0:n0}", rdn.Next(200001));
            }

            return arr;
        }



        //Se convierte el objeto a formato Json y se exporta.
        private void SerializeAndExport(string path, EjercicioSuma ejercicio)
        {
            var ejercicioJSon = JsonConvert.SerializeObject(ejercicio);          
            File.WriteAllText(path, ejercicioJSon);
        }
        
       

       

    }
}
