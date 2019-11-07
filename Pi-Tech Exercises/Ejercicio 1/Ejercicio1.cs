using System;
using System.IO;

namespace Ejercicio_1
{
    public class Ejercicio1
    {
        private string[] data;
        public void Sort(string path)
        {
            this.data = Read(path);

            if (this.data == null) return;

            MergeSort(this.data);

            string outputpath = TrimPath(path);

            File.WriteAllLines(outputpath, this.data);
        }


        //Genera la ruta del archivo que contiene el resultado esperado.
        private string TrimPath(string path)
        {
            path = path.Remove(path.Length - 4);
            path += "Output.csv";

            return path;

        }


        //Lee y almacena los datos del archivo de entrada.
        private string[] Read(string path)
        {
            try
            {
                string[] Data = File.ReadAllLines(path);
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private void MergeSort(string[] arr, string[] temp, int L, int R)
        {
            if (L >= R) return;

            int mid = L + (R - L) / 2;
            MergeSort(arr, temp, L, mid);
            MergeSort(arr, temp, mid + 1, R);
            Merge(arr, temp, L, R, mid);

        }
        private void Merge(string[] arr, string[] temp, int L, int R, int mid)
        {
            for (int k = L; k <= R; k++)
            {
                temp[k] = arr[k];
            }

            int i = L, j = mid + 1;
            for (int k = L; k <= R; k++)
            {
                if (i > mid) arr[k] = temp[j++];
                else if (j > R) arr[k] = temp[i++];
                else if (Compare(temp[j], temp[i])) arr[k] = temp[j++];
                else arr[k] = temp[i++];
            }
        }

        //Algoritmo de gran eficiencia utilizado para ordenar los elementos.
        private void MergeSort(string[] arr)
        {
            string[] temp = new string[arr.Length];
            MergeSort(arr, temp, 0, arr.Length - 1);
        }

        //Compara las cédulas comenzando desde el último dígito.
        public bool Compare(string element1, string element2)
        {
            int i = element1.Length - 1;
            int j = element2.Length - 1;

            for (; element1[i] != ','; i--, j--)
            {
                if (element1[i] != '-')
                {
                    if (Convert.ToInt32(element1[i]) < Convert.ToInt32(element2[j])) return true;

                    else if (Convert.ToInt32(element1[i]) > Convert.ToInt32(element2[j])) return false;
                }

            }
            return false;
        }
    }
}
