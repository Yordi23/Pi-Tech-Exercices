using System;
using System.Collections.Generic;
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
            string[] arr = new string[6];
            string[] arrResult = SeparateNumber(result);

            return null;
        }

        private string[] SeparateNumber(string num)
        {
            List<string> list = new List<string>();
            string segment = "";
            int count = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (count == 2)
                {
                    list.Add(segment);
                    count = 0;
                    segment = "";
                }
                else
                {
                    if (num[i] == ' ') count++;
                    else if (num[i] == 'y') count--;

                    if (count == 2) continue;
                    segment += num[i];
                }
                

            }

            return list.ToArray();
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
    }
}
