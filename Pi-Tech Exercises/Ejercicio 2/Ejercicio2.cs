using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ejercicio_2
{
    class Ejercicio2
    {
        
        public void GenerateExercise(string path)
        {
            string instruction = "Selecciona el resultado de la siguiente suma.";

            string[] problem = new string[2];
            string[] options = new string[4];

            int resutl = 0;

            Random rdn = new Random();


            for (int i = 0; i < problem.Length; i++)
            {
                //Debido a que no se especifica en el ejercicio, elegí arbitrariamente que 
                //el número máximo para realizar las operaciones de suma sería 100,000.
                int num = rdn.Next(100001);
                resutl += num;
                problem[i] = ParseNum(num);
            }

            options[rdn.Next(3)] = ParseNum(resutl);
            options = GenerateOptions(options);


            EjercicioSuma ejercicio = new EjercicioSuma(instruction,problem,options,resutl);

            SerializeAndExport(path, ejercicio);
        }


        private string ParseNum(int num)
        {
            string strNum = Convert.ToString(num), output = "";
            List<char> temp = new List<char>();
            int count = 0;

            for (int i = strNum.Length-1; i > 0; i--)
            {
                if (count == 3)
                {
                    temp.Add(',');
                    count = 0;
                }

                else
                {
                    temp.Add(strNum[i]);
                    count++;
                }
            }
            for (int i = 0; i < temp.Count; i++)
                output += temp[i];

            return output;
        }

        //Se crean opciones aleatorias.
        private string[] GenerateOptions (string[] arr)
        {
            Random rdn = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                //El resultado posible más grande es 200,000 (100,000 + 100,000)
                if (arr[i] == null) rdn.Next(200001);
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
