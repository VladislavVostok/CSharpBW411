using System.Collections;


namespace _06_Interfaces_General
{


    struct Person
    {
        public string name;
        public int age;

        public void Print()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }
    }

    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: {Series} {Number}";
        }
    }

    class Student:  IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }

        public int CompareTo(object? obj)
        {
            if (obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"-> {FirstName} {LastName} {BirthDate.ToString()}";
        }
    }




class Auditory: IEnumerable
    {
        Student[] students =
        {
            new Student {
                FirstName ="John",
                LastName ="Miller",
                BirthDate =new DateTime(1997,3,12),
                StudentCard =new StudentCard { Number=189356, Series="AB" }
            },

            new Student {
                FirstName ="Candice",
                LastName ="Leman",
                BirthDate =new DateTime(1998,7,22),
                StudentCard = new StudentCard { Number=345185, Series="XA" }
            },
                new Student {
                FirstName ="Joey",
                LastName ="Finch",
                BirthDate = new DateTime(1996,11,30),
                StudentCard = new StudentCard { Number=258322, Series="AA" }
            },
            new Student {
                FirstName ="Nicole",
                LastName ="Taylor",
                BirthDate = new DateTime(1996,5,10),
                StudentCard = new StudentCard { Number=513484, Series="AA" }
            }
        };

        public void Sort()
        {
            Array.Sort(students);
        }

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }
    }



    internal class Program
    {

        static void Main(string[] args)
        {

            Auditory auditory = new();

            foreach (var item in auditory)
            {
                Console.WriteLine(item);
            }

            auditory.Sort();

            foreach (var item in auditory)
            {
                Console.WriteLine(item);
            }
        }
    }
}
