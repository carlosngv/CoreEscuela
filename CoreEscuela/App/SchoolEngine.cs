using System;
using CoreEscuela.Entities;
using CoreEscuela.Util;

namespace CoreEscuela.App
{

    // Una clase sealed permite crear instancias pero no heredar del mismo
	public sealed class SchoolEngine
	{
        

        public School School { get; set; }
        
        public SchoolEngine(){}

		public void Init()
		{
            School = new School("Platzi School", 2012, SchoolTypes.Elementary, "Guatemala", "Guatemala");

            LoadCourses();
            LoadAssignatures();
            LoadEvaluations();
            return;

        }

        public Dictionary<DictionaryKeys, IEnumerable<SchoolBase>> GetObjectDictionary()
        {
            var dictionary = new Dictionary<DictionaryKeys, IEnumerable<SchoolBase>>();
            var evaluationList = new List<Evaluation>();
            var assignatureList = new List<Assignature>();
            var studentList = new List<Student>();

            School.coursesList.ForEach(course =>
            {
                studentList.AddRange(course.Students);
                assignatureList.AddRange(course.Assignatures);
                course.Students.ForEach(student => evaluationList.AddRange(student.Evaluations));
            });

            dictionary.Add(DictionaryKeys.School, new[] { School });
            dictionary.Add(DictionaryKeys.Course, School.coursesList);
            dictionary[DictionaryKeys.Assignature] = assignatureList;
            dictionary[DictionaryKeys.Student] = studentList;
            dictionary[DictionaryKeys.Evaluation] = evaluationList;

            return dictionary;
        }

        public void ShowDictionary(Dictionary<DictionaryKeys, IEnumerable<SchoolBase>> dic,
            bool printEvaluations = false)
        {
            foreach(var dicObj in dic)
            {
                Printer.PrintTitle(dicObj.Key.ToString());
                foreach(var val in dicObj.Value)
                {
                    switch (dicObj.Key)
                    {
                        case DictionaryKeys.Evaluation:
                            if (printEvaluations)
                                Console.WriteLine($"Evaluation: {val}");
                            break;
                        case DictionaryKeys.Student:    
                            Console.WriteLine($"Student: {val}");
                            break;
                        case DictionaryKeys.School:
                            Console.WriteLine($"School: {val}");
                            break;
                        case DictionaryKeys.Course:
                            var curTemp = val as Course;
                            if (curTemp != null) {
                                int studentCount = curTemp.Students.Count;
                                Console.WriteLine($"Course: {val} | Total students: {studentCount.ToString()}.");
                            }
                            break;
                        case DictionaryKeys.Assignature:
                            Console.WriteLine($"Asssignature: {val.ToString()}");
                            break;
                        default:
                            Console.WriteLine($"Value: {val}");
                            break;
                    }
                }
            }
        }
        

        public List<SchoolBase> GetSchoolBaseObject(bool hasEvaluations)
        {
            var listObj = new List<SchoolBase>();
            listObj.Add(School);
            listObj.AddRange(School.coursesList);

            foreach (var course in School.coursesList)
            {
                listObj.AddRange(course.Assignatures);
                listObj.AddRange(course.Students);

                if(hasEvaluations)
                {
                    foreach (var student in course.Students)
                    {
                        listObj.AddRange(student.Evaluations);
                    }
                }

            }

            return listObj;
        }

        public List<SchoolBase> GetSchoolBaseObject()
        {
            var listObj = new List<SchoolBase>();
            listObj.Add(School);
            listObj.AddRange(School.coursesList);

            foreach(var course in School.coursesList)
            {
                listObj.AddRange(course.Assignatures);
                listObj.AddRange(course.Students);
                foreach(var student in course.Students)
                {
                    listObj.AddRange(student.Evaluations);
                }
            }

            return listObj;
        }

        private void LoadEvaluations()
        {
            foreach(var course in School.coursesList)
            {
                GenerateEvaluations(course);
            }
        }

        private void LoadAssignatures()
        {
            foreach(Course course in School.coursesList)
            {
                List<Assignature> assignaturesList = new List<Assignature>(){
                    new Assignature { Name = "Math"},
                    new Assignature { Name = "Physics" },
                    new Assignature { Name = "Language" },
                    new Assignature { Name = "Nature Science" }
                };

                course.Assignatures.AddRange(assignaturesList);

            }
        }

        private void GenerateEvaluations(Course course)
        {
           

            Random random = new Random();
            foreach(var assignature in course.Assignatures)
            {
                foreach (var student in course.Students)
                {
                    for(int i = 0; i < 5; i++) {
                        random = new Random();
                        var randomNote = (float)random.NextDouble();
                        var evalNote = Math.Round((5 * randomNote), 2);
                        var newEvaluation = new Evaluation() { Name= assignature.Name, assignature = assignature, student = student, note = evalNote };
                        student.Evaluations.Add(newEvaluation);
                    }
                }

            }
        }

        private List<Student> GenerateStudents(int quantity)
        {
            string[] firstNames = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastNames = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] secondNames = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var stundentsList = from n1 in firstNames
                                            from n2 in secondNames
                                            from ln in lastNames
                                            select new Student { Name = $"{n1} {n2} {ln}" };
           return stundentsList.OrderBy( (student) => student.UniqueID).Take(quantity).ToList();
        }

        private void LoadCourses()
        {
            School.coursesList = new List<Course>() {
                new Course { Name = "101", schedule = ScheduleType.morning  },
                new Course { Name = "320", schedule = ScheduleType.afternoon },
                new Course { Name = "460", schedule = ScheduleType.morning },
                new Course { Name = "103", schedule = ScheduleType.night},
                new Course { Name = "102 - Vacacional", schedule = ScheduleType.night },
             };

            Random random = new Random();
            foreach(var course in School.coursesList)
            {
                var randomQuantity = random.Next(5, 25);
                course.Students = GenerateStudents(randomQuantity);
            }
        }
	}
}

