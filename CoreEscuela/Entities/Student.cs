namespace CoreEscuela.Entities
{
	public class Student: SchoolBase
	{

		public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

	}
}
