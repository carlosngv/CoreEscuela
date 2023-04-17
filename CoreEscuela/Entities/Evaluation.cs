using System;
namespace CoreEscuela.Entities
{
	public class Evaluation: SchoolBase
	{
        public Student student { get; set; }
        public Assignature assignature { get; set; }
        public double note { get; set; }

        public override string ToString()
        {
            return $"Assignature: ${assignature}, Note: {note}";
        }
    }
}

