using CoreEscuela.Util;
namespace CoreEscuela.Entities
{


	public class Course: SchoolBase, IPlace
	{
		public ScheduleType schedule { get; set; }
        public string Address { set; get; }

        public List<Assignature> Assignatures { get; set; } = new List<Assignature>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();



        public override string ToString()
        {

            return $"ID: {UniqueID}\n Nombre: { Name }\n Horario: {schedule}";
        }

        public void CleanPlace()
        {
            Printer.PrintLine();
            Console.WriteLine("Limpiando establecimiento...");
            Console.WriteLine($"Curso {Name} está limpio.");
        }

    }
}
