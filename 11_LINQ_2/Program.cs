using System.Drawing;
using System.Net.NetworkInformation;

namespace _11_LINQ_2
{
	class People
	{
		public int Age { get; set; }
		public string Name { get; set; }	
	}

	class OwnerPet
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	class Pet
	{
		public int OwnerId { get; set; }	
		public int Age { get; set; }
		public string  Color { get; set; }
		public string Type {  get; set; }
		public string Call { get; set; }
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			var data = new[] { 1, 2, 3, 4, 5 };

			var people = new List<People>() {

				new People()
				{
					
					Age=16,
					Name="Игнат"
				},
				new People()
				{
					Age=18,
					Name="Геракл"
				},
				new People()
				{
					Age=45,
					Name="Вася"
				},
				new People()
				{
					Age=16,
					Name="Гомер"
				},
			};


			var pets = new List<Pet>() {

				new Pet()
				{   OwnerId = 1,
					Age=16,
					Color= "Зеленый",
					Type="Горилла",
					Call="Гомер"
				},

				new Pet()
				{   OwnerId = 2,
					Age=11,
					Color= "Чёрный",
					Type="Слон",
					Call="Вася"
				},

				new Pet()
				{   OwnerId = 3,
					Age=5,
					Color= "Розовый",
					Type="Кот",
					Call="Леонард"
				},

				new Pet()
				{   OwnerId = 3,
					Age=6,
					Color= "Сутулая",
					Type="Собака",
					Call="Лоуренс"
				},
			};

			var ownersPets = new List<OwnerPet>() {

				new OwnerPet()
				{   
					Name="Борис",
					Id = 1,
				},

				new OwnerPet()
				{
					Name="Игнат",
					Id= 2,
				},

				new OwnerPet()
				{
					Name = "Илья",
					Id = 3,
				}
			};

			// Where
			var evenData = data.Where(n => n % 2 == 0);

			evenData = from n in data
						where n % 2 == 0
						select n;

			// Select
			var sqrData = data.Select(n => n * n);

			sqrData = from n in data
					   select n * n;

			// SelectMany
			var nested = new[] { new[] { 1, 2 }, new[] { 3 } };
			nested.SelectMany(a => a); // 1,2,3

			var nestedQuery = from arr in nested
							  from n in arr
							  select n;



			// OrderBy / ThenBy
			var orderedPeople = people.OrderBy(p => p.Name)
									.ThenBy(p => p.Age);

			orderedPeople = from p in people
							orderby p.Name, p.Age
							select p;

			// GroupBy

			var grouped = data.GroupBy(n => n % 2 == 0 ? "even" : "odd");


			var groupedQuery =	from n in data
								group n by n % 2 == 0 ? "even" : "odd" 
								into g
								select new { Key = g.Key, Items = g };   // Анонимный объект


			// Join
			var ownerPetData = ownersPets.Join(pets,
								p => p.Id,
								pet => pet.OwnerId,
								(p, pet) => 
								new { p.Name, Pet = pet.Call });


			ownerPetData =	from p in ownersPets
							join pet in pets 
							on p.Id equals pet.OwnerId
							select new { p.Name, Pet = pet.Call };

			// GroupJoin

			var petsOwner =  ownersPets.GroupJoin(pets,
				  p => p.Id,
				  pet => pet.OwnerId,
				  (p, grp) => new
				  {
					  Owner = p.Name,
					  Pets = grp.Select(x => x.Type).ToList()
				  });


			petsOwner = from p in ownersPets
						join pet in pets on p.Id equals pet.OwnerId 
						into grp
			select new
			{
				Owner = p.Name,
				Pets = (from x in grp select x.Type).ToList()
			};


			foreach (var po in petsOwner)
			{
				Console.WriteLine(po.Owner);
				foreach(var p in po.Pets)
				{
						Console.WriteLine(p);
				}
			}

			// All / Any

			bool isAllDataTrue = data.All(n => n > 0);
			bool isAnyDataTrue = data.Any(n => n % 2 == 0);
			isAllDataTrue = data.All(n => n % 2 == 0);

			isAllDataTrue = (from n in data where n <= 0 select n).Any() == !data.All(n => n > 0);

			// Contains

			bool isExists = data.Contains(3);

			(from n in data where n == 3 select n).Any();

			// Count / Sum / Min / Max / Average

			int c = data.Count(n => n > 2);
			c = data.Count();
			int s = data.Sum();
			s = data.Sum(n => n%2 == 0 ? n : 0);
			int min = data.Min();
			int max = data.Max();
			double avg = data.Average();


			(from n in data where n > 2 select n).Count();

			// Aggregate
			int agg = data.Aggregate((a, b) => a * b);

			// Distinct

			var newArr = new[] { 1, 2, 2, 3 }.Distinct();

			Print(newArr);

			// Union / Intersect / Except
			var a = new[] { 1, 2 };
			var b = new[] { 2, 3 };
			var union = a.Union(b);
			Print(union);
			var intersect = a.Intersect(b);
			Print(intersect);
			var except = a.Except(b);
			Print(except);


			var take = data.Take(3);
			Print(take);
			var skipTake = data.Skip(2).Take(2); // page 2, size 2
			Print(skipTake);

			int elem = data.ElementAt(2);

			var listData = data.ToList();
			var dictData = data.ToDictionary(n => n);
			var listArray = listData.ToArray();
			var hashSet = listArray.ToHashSet();

			var letters = new[] { "A", "B", "C" };
			var dataZip = letters.Zip(data, ( l, n) => $"{n}{l}");
			Print(dataZip);


			// Дан массив целых.
			// Найти три наибольших различных числа
			// и вывести их в порядке убывания.

			var top3 = data.Distinct()
							.OrderByDescending(x => x)
							.Take(3)
							.ToList();

		}

		static void Print<T>(IEnumerable<T> newArr) {

			foreach (T i in newArr) Console.Write(" " + i);
			Console.WriteLine();
		}

	}
}
