using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ejercicio4
{
    class Ejercicio4
    {
        public void GenerateExercise(string path)
        {
            Random rdn = new Random();
            string[] options = new string[4];
            string instruction = "Escribe el número siguiente presionando los botones en el orden correcto.";

            int num = rdn.Next(100001);
            string problem = String.Format("{0:n0}",num);
            string result = Convert(num);

            options = GenerateOptions(result);

            EjercicioEscrituraNumeros ejercicio = new EjercicioEscrituraNumeros(instruction, problem, options, result);
            SerializeAndExport(path, ejercicio);

        }

        private string Convert (int num)
        {
            string output = "";

            string[] units = {"cero", "uno", "dos" ,"tres" ,"cuatro" ,"cinco" ,"seis" ,"siete" ,"ocho" ,"nueve","diez", 
                              "once", "doce", "trece", "catorce", "quince", "diezciseis", "diecisiete", "dieciocho", "diecinueve" };
            string[] tens ={"veinte", "treinta","cuarenta","cincuenta","sesenta", "setenta", "ochenta", "noventa"};
            string[] hundreds = {"quinientos",null,"setecientos",null,"novecientos"};

            if (num < 20) output = units[num];

            else if (num < 100)
            {
                int ten = num / 10;
                int unit = num % 10;


                if (unit == 0) output = tens[ten - 2];

                else if (num < 30) output = "veinti" + Convert(num - 20);

                else
                {
                    output = Convert(((num / 10) * 10)) + " y ";

                    if (unit == 1) output += "uno";
                    else output += Convert(num % 10);
                }
            }
            
            else if (num == 100) output = "cien";

            else if (num < 200) output = "ciento " + Convert(num - 100);

            else if (num < 1000)
            {
                int ten = (num / 10) % 10;
                int unit = num % 10;
                int hundred = (num / 100) % 10;

                if (ten == 0 && unit == 0)
                {
                    if (hundred == 5 || hundred == 7 || hundred == 9) output = hundreds[hundred - 5];

                    else output = Convert((num / 100)) + "cientos";
                }

                else output = Convert((num / 100) * 100) + " " + Convert(num % 100);
            }
            else if (num == 1000) output = "mil";

            else if (num < 2000) output = "mil " + Convert(num % 1000);

            else if (num <= 100000)
            {
                output = Convert((num / 1000)) + " mil";
                
                if ((num % 1000) > 0) output += " " + Convert(num % 1000);
            }


            return output;

        }

        private string[] GenerateOptions(string result)
        {
            Random rdn = new Random();
            string[] output = new string[6];
            string[] arrResult = SeparateNumber(result);
            int remainSpace = 6 - arrResult.Length;

            output = PoblateOutput(arrResult, output, remainSpace);

            
            while (remainSpace > 0)
            {
                string[] rdnNumber = SeparateNumber(Convert(rdn.Next(100001)));
                output = PoblateOutput(rdnNumber, output,remainSpace);
                remainSpace -= rdnNumber.Length;
            }


            return output;
        }

        private string[] SeparateNumber(string num)
        {
            List<string> output = new List<string>();
            string segment = "";
            int count = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (count == 2)
                {
                    output.Add(segment);
                    count = 0;
                    segment = "";
                    i--;
                }
                else
                {
                    if (num[i] == ' ') count++;
                    else if (num[i] == 'y') count--;

                    if (count == 2) continue;
                    segment += num[i];
                }


            }

            if (segment[0] == 'y') segment = segment.Substring(2);
            output.Add(segment);

            return output.ToArray();
        }

        public string[] PoblateOutput(string[] arr, string[] output, int remainSpace)
        {
            Random rdn = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                int num = rdn.Next(6);

                if (output[num] == null)
                {
                    output[num] = arr[i];
                    remainSpace--;
                }

                else if (remainSpace == 0) break;

                else i--;
            }


            return output;
        }

        public int[] GenerateArray()
        {
            int[] arr = new int[100000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
            return arr;
        }

        public void Test()
        {
            int[] arr = GenerateArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(Convert(arr[i]));
            }
            Console.ReadKey();   
        }

        //Se convierte el objeto a formato Json y se exporta.
        private void SerializeAndExport(string path, EjercicioEscrituraNumeros ejercicio)
        {
            var ejercicioJSon = JsonConvert.SerializeObject(ejercicio);
            File.WriteAllText(path, ejercicioJSon);
        }
    }
}
