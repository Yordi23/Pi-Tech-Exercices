using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio4
{
    class Ejercicio4
    {
        public string Convert (int num)
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

                else
                {
                    output = Convert(((num / 10) * 10)) + " ";

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

        public int[] GenerateArray()
        {
            int[] arr = new int[1000];
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
