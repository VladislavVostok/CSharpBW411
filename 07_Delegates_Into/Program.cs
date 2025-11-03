using static System.Console;
using System.Linq;

namespace _07_Delegates_Into
{


	class Student
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public DateTime BirthDate { get; set; }
	}



	public delegate double CalcDelegate(double x, double y);
	public class Calculator
	{
		public double Add(double x, double y)
		{
			return x + y;
		}
		public static double Sub(double x, double y)
		{
			return x - y;
		}
		public double Mult(double x, double y)
		{
			return x * y;
		}
		public double Div(double x, double y)
		{
			if (y != 0)
			{
				return x / y;
			}
			throw new DivideByZeroException();
		}
	}

	public delegate T AddDelegate<T>(T x, T y);
	public class ExampleClass
	{
		public int AddInt(int x, int y)
		{
			return x + y;
		}
		public double AddDouble(double x, double y)
		{
			return x + y;
		}
		public static char AddChar(char x, char y)
		{
			return (char)(x + y);
		}
	}


	class Program
	{


		static void Main(string[] args)
		{
			//Calculator calc = new Calculator();
			//Write("Enter an expression: ");
			//string expression = ReadLine();
			//char sign = ' ';
			//// определения знака арифметического действия
			//foreach (char item in expression)
			//{
			//	if (item == '+' || item == '-' || item ==
			//	'*' || item == '/')
			//	{
			//		sign = item;
			//		break;
			//	}
			//}
			//try
			//{
			//	// получение значений операндов
			//	string[] numbers = expression.Split(sign);

			//	CalcDelegate del = null;
			//	CalcDelegate delAll = calc.Add; // групповое преобразование методов
			//	delAll += Calculator.Sub;
			//	delAll += calc.Mult;
			//	delAll += calc.Div;

			//	delAll -= calc.Div;

			//	foreach (CalcDelegate item in delAll.GetInvocationList()) // массив делегатов
			//	{

			//		try
			//		{
			//			// вызов
			//			WriteLine($"Result: {item(5.7, 3.2)}");
			//		}
			//		catch (Exception ex)
			//		{
			//			WriteLine(ex.Message);
			//		}
			//	}

			//	switch (sign)
			//	{
			//		case '+':
			//			del = new CalcDelegate(calc.Add);
			//			break;
			//		case '-':
			//			del = new CalcDelegate(Calculator.
			//			Sub);
			//			break;
			//		case '*':
			//			del = calc.Mult; // групповое
			//							 // преобразование методов
			//			break;
			//		case '/':
			//			del = calc.Div;
			//			break;
			//		default:
			//			throw new
			//			InvalidOperationException();
			//	}
			//	WriteLine($"Result: {del(double.Parse(numbers[0]), double.Parse(numbers[1]))}");

			//	del += calc.Mult;
			//}
			//catch (Exception ex)
			//{
			//	WriteLine(ex.Message);
			//}




			List<Student> group = new List<Student> {
				new Student {
					FirstName = "John",
					LastName = "Miller",
					BirthDate = new DateTime(1997,3,12)
				},
				new Student {
					FirstName = "Candice",
					LastName = "Leman",
					BirthDate = new DateTime(1998,7,22)
				},
				new Student {
					FirstName = "Joey",
					LastName = "Finch",
					BirthDate = new DateTime(1996,11,30)
				},
				new Student {
					FirstName = "Nicole",
					LastName = "Taylor",
					BirthDate = new DateTime(1996,5,10)
				}
			};
			WriteLine("List of students:");
			//group.ForEach(SetState);

			//group.ForEach(s =>
			//{
			//	s.LastName += s.LastName.ToUpper();
			//	s.FirstName += s.FirstName.ToLower();
			//});

			//group.ForEach(FullName);

			var students = group
				.Where(
					(s) => s.FirstName.StartsWith("J")
				)
				.Select(FullName).ToList();

			foreach (var item in students) WriteLine(item);

			string? str = students.Find(s => s.Length == 12 );

			//string str = (students as List<string>).Find(StartWith);

			//students = group.Select((s) => $" {s.LastName}\t{s.FirstName}");

			//foreach (string item in students)
			//{
			//	WriteLine(item);
			//}


		}

		static bool StartWith(string str)
		{
			return str.StartsWith("Miller");
		}

		static string FullName(Student student)
		{
			return $" {student.LastName}\t{student.FirstName}";
		}

		static void SetState(Student student)
		{
			student.FirstName += "Test";
			student.LastName += "Test";
		}
	}
}