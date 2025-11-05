namespace _09_Anonimosly_methods_Lambda
{
	delegate void MyDelegat(string message);

	delegate int MyDelegat2(string message);
	internal class Program
	{

		static event MyDelegat _delegat;
		static event MyDelegat2 _delegat2;

		static void Main(string[] args)
		{


			_delegat += (string message) => Console.WriteLine(message);
			_delegat2 += (string message) => message.Length;

			_delegat("Hello, WORLD!");
			_delegat.Invoke("Hello, WORLD!");

			var n = _delegat2.Invoke("Hello, WORLD!");

			Console.WriteLine(n);

			_delegat += (string message) =>
			{

				Console.WriteLine(message);
				Console.WriteLine(message);
				Console.WriteLine(message);
				Console.WriteLine(message);
			};



		}
	}
}
