using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ejercicio3
{
    class Ejercicio3
    {
        //Nota: A pesar de que en el ejemplo se muestra que dentro del archivo Json el campo de 
        //resultado es igual a 0, asumí que este campo corresponde al resultado de realizar la 
        //operación indicada.
        public void GenerateExercise(string path)
        {
            Random rdn = new Random();
            string instruction = "Completa correctamente la oración arrastrando al espacio en blanco la cantidad que corresponda.";
            string[] options = new string[4];

            string[] temp = GenerateProblem();
            string problem = temp[0];
            double result = Math.Round(Convert.ToDouble(temp[1]), 2); 

            options[rdn.Next(4)] = String.Format("{0:n}", result);
            options = GenerateOptions(options);

            EjercicioPorcentaje ejercicio = new EjercicioPorcentaje(instruction, problem, options, result);
            SerializeAndExport(path, ejercicio);

        }
        
        //Se genera el número, el porcentaje y el tipo de ejercicio de manera aleatoria.
        private string[] GenerateProblem ()
        {
            double num, percentage;
            int typeOfExercise;
            Random rdn = new Random();
            string[] output = new string[2];

            num = rdn.Next(100001);
            percentage = rdn.Next(101);
            typeOfExercise = rdn.Next(2);
            
            //Dependiendo de el tipo de ejercicio se realiza una operación u otra
            switch (typeOfExercise)
            {
               
                case 0:
                    output[0] = String.Format("Aumentar en un {0} % la cantidad de {1}, resulta en:",percentage, String.Format("{0:n}", num));
                    output[1] = Convert.ToString((num * percentage/100) + num);
                    break;
                case 1:
                    output[0] = String.Format("Reducir en un {0} % la cantidad de {1}, resulta en:", percentage, String.Format("{0:n}", num));
                    output[1] = Convert.ToString(num - (num * percentage/100));
                    break;
            }

            return output;
        }


        //Se generan opciones aleatorias.
        private string[] GenerateOptions(string[] arr)
        {
            Random rdn = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                //El máximo resultado posible es 200,000 (Adicionar 100% a 100,000)
                if (arr[i] == null) arr[i] = String.Format("{0:n}", rdn.NextDouble()* 200001);
            }

            return arr;
        }

        //Se convierte el objeto a formato Json y se exporta.
        private void SerializeAndExport(string path, EjercicioPorcentaje ejercicio)
        {
            var ejercicioJSon = JsonConvert.SerializeObject(ejercicio);
            File.WriteAllText(path, ejercicioJSon);
        }

    }
}
