using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio3
{
    //Clase que representa los Ejercicio de Porcentaje.
    class EjercicioPorcentaje
    {
        public string instruction { get; set; }
        public string problem { get; set; }
        public string[] options { get; set; }
        public double result { get; set; }


        public EjercicioPorcentaje(string instruction, string problem, string[] options, double result)
        {
            this.instruction = instruction;
            this.problem = problem;
            this.options = options;
            this.result = result;
        }
    }
}
