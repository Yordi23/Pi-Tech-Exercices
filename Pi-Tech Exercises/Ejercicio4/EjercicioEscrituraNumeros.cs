namespace Ejercicio4
{
    //Clase que representa los Ejercicio de Escritura de Números.
    class EjercicioEscrituraNumeros
    {
        public string instruction { get; set; }
        public string problem { get; set; }
        public string[] options { get; set; }
        public string result { get; set; }


        public EjercicioEscrituraNumeros(string instruction, string problem, string[] options, string result)
        {
            this.instruction = instruction;
            this.problem = problem;
            this.options = options;
            this.result = result;
        }
    }
}
