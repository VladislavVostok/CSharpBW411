namespace _08_Events_Into
{

	public delegate void ExamDelegate(string t);

	public delegate void RandDelegate();

	class RandEchangePrice
	{
		Random rnd = new();

		bool stop = false;

		public event RandDelegate StopRand;


		public void RandomPrice() {
			while (!stop) { 
				Console.WriteLine(rnd.Next());
			}
		}

		public void Stop()
		{
			stop = true;
			StopRand();
		}
	}


	class Receiver()
	{
		public event RandDelegate Rand;

		public void PrintData() {
			Rand();
		}
	}



	class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public void Exam(string task)
		{
			Console.WriteLine($"Student {LastName} solved the {task}");
		}
	}

	class Teacher
	{
		public event ExamDelegate examEvent;
		public void Exam(string task)
		{
			if (examEvent != null)
			{
				examEvent(task);
			}
		}
	}


	internal class Program
	{

		static List<Student> group = new List<Student> {
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
			BirthDate = new DateTime(1996,11,30)},
			new Student {
			FirstName = "Nicole",
			LastName = "Taylor",
			BirthDate = new DateTime(1996,5,10)
			}
		};
		static void Main(string[] args)
		{

			//	Teacher teacher = new Teacher();

			//	foreach (Student item in group)
			//	{
			//		teacher.examEvent += item.Exam;
			//	}

			//	teacher.Exam("Task");

			//	Console.WriteLine("Hello, World!");

			Receiver res = new();
			RandEchangePrice randEchangePrice = new RandEchangePrice();



			res.Rand += randEchangePrice.RandomPrice;

			  _ = Task.Run(() => res.PrintData());

			Task.Delay(10000).Wait();

			randEchangePrice.StopRand += randEchangePrice.Stop;

			randEchangePrice.Stop();

			Task.Delay(10000).Wait();
		}



	}
}
