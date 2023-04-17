using CoreEscuela.Entities;
using CoreEscuela.App;
using CoreEscuela.Util;

namespace CoreEscuela
{

    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CustomEventAction;
            AppDomain.CurrentDomain.ProcessExit += (object? sender, EventArgs e) => Printer.PrintTitle("Lambda action");
            Printer.PrintTitle("Pruebas de Polimorfismo");
            SchoolEngine engine = new SchoolEngine();
            engine.Init();
            PrintCourses(engine.School);

            var objList = engine.GetSchoolBaseObject();

            var listPlace = from obj in objList
                            where obj is IPlace
                            select (IPlace)obj;
                            
            

            engine.School.CleanPlace();

            var objDictionary = engine.GetObjectDictionary();
            //engine.ShowDictionary(objDictionary, true);
            var reporter = new Reporter(objDictionary);


    }

        private static void CustomEventAction(object? sender, EventArgs e)
        {
            // Se ejecuta este evento cuando vaya a terminar la ejecución del programa
            Printer.PrintTitle("Exit Porcess Event! Exiting...");
        }

        #region
        private static void PrintCourses(School School)
        {

            Console.WriteLine(School);
            Printer.PrintTitle("Cursos de la escuela");

            if (School.coursesList != null)
            {
                foreach (Course course in School.coursesList)
                {
                    Console.WriteLine(course.ToString());
                }
            }

        }
        #endregion
    }

}