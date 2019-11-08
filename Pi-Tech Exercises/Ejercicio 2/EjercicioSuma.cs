namespace Ejercicio_2
{
    //Clase que representa los Ejercicio de Suma.
    class EjercicioSuma
    {
        public string instruction { get; set; }
        public string[] problem { get; set; }
        public string[] options { get; set; }
        public int result { get; set; }


        public EjercicioSuma(string instruction, string[] problem, string[] options, int result)
        {
            this.instruction = instruction;
            this.problem = problem;
            this.options = options;
            this.result = result;
        }
    }
}
