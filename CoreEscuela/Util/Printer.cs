using System;
namespace CoreEscuela.Util
{
	public class Printer
	{
		public static void PrintLine(int size = 10)
		{
			var line = "".PadRight(size, '=');
			
			Console.WriteLine(line);
		}

		public static void PrintTitle(string title)
		{
			PrintLine(title.Length + 5);
			Console.WriteLine($"| {title}  |");
            PrintLine(title.Length + 5);
        }
	}
}

