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
            //string[] specials = {"once", "doce","trece","catorce", "quince","diezciseis", "diecisiete", "dieciocho", "diecinueve"};
            string[] tens ={"veinte", "treinta","cuarenta","cincuenta","sesenta", "setenta", "ochenta", "noventa"};

            if (num < 20) output = units[num];

            else if(num < 100)
            {
                int dec = num / 10;
                int u = num % 10;

                if (u == 0) return tens[dec-2];

                output = string.Format("{0} y {1}", Convert(((num / 10) * 10)), (u == 1 ? "uno" : Convert(num % 10)));
            }


            return output;

        }

        public int[] GenerateArray()
        {
            int[] arr = new int[100];
            for (int i = 0; i < 100; i++)
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
