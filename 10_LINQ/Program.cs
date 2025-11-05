namespace _10_LINQ
{
	class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public override string ToString()
		{
			return $"Surname: {LastName}, Name: {FirstName}, Born: {BirthDate.ToLongDateString()}";

		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Student> _group = new List<Student> {
				new Student {
					FirstName = "John",
					 LastName = "Miller",
					 BirthDate = new DateTime(1997, 3, 12)
				 },
				new Student
				{
					FirstName = "Candice",
					LastName = "Leman",
					BirthDate = new DateTime(1998, 7, 22)
				},
				new Student
				{
					FirstName = "Joey",
					LastName = "Finch",
					BirthDate = new DateTime(1996, 11, 30)
				},
				new Student
				{
					FirstName = "Nicole",
					LastName = "Taylor",
					BirthDate = new DateTime(1996, 5, 10)
				},
				new Student
				{
					FirstName = "Corey",
					LastName = "Taylor",
					BirthDate = new DateTime(1996, 5, 10)
				}
			};

			var res = from g in _group 
					  where g.BirthDate.Month == 5
					  select g;


			foreach (var student in res) {
				Console.WriteLine(student.ToString());
			}

			int[] arrayInt = { 5, 34, 67, 12, 94, 42 };

			var query = from i in arrayInt 
						where i%2==0 
						select i;



			foreach (var q in query) { 
				Console.WriteLine(q.ToString());
			}

			var queryArr = arrayInt
				.Where(item => item % 2 == 0)
				.Select(item => item.ToString());

			foreach (var q in queryArr) { 
				Console.WriteLine(q.ToString());
			}

		}
	}
}
