using CoreEscuela.Util;
namespace CoreEscuela.Entities
{
	public class School:SchoolBase, IPlace { 

        public int creationYear { get; set; }
        public string Country { get; set; }
        public string City { set; get; }
        public string Address { set; get; }

        public SchoolTypes SchoolType { set; get; }
        public List<Course> coursesList { get; set; } = new List<Course>();

        /*
            Constructores

            Hay dos para demostrar la implementación de sobrecarga de
            constructores.
        */
        public School(string name, int year) => (Name, creationYear) = (name, year);

        public School(string name, int year, SchoolTypes SchoolType,
                string country = "", string city = "")
        {
            Name = name;
            (Name, creationYear) = (name, year);
            this.SchoolType = SchoolType;
            (Country, City) = (country, city);
        }

        public override string ToString()
        {
            return $"Nombre: {Name}\n Tipo: { SchoolType}\n País: { Country }\n Ciudad: { City }\n";
        }

        public void CleanPlace() {
            Printer.PrintLine();
            Console.WriteLine("Limpiando escuela...");
            foreach(var course in coursesList)
            {
                course.CleanPlace();
            }
            Console.WriteLine($"Escuela {Name} está limpio.");
        }

    }
}

