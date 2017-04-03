using System;

namespace neuroLab_3
{
	class Program
	{
		static void Main(string[] args)
		{
			Stuff.InitConstants(20, 1, 5, 10); // N, a, b, window
			var neuron = new Neuron(20, Stuff.p, 0.05); // N, , rate

			int epochCount = 5000;

			while (neuron.on && epochCount > 0)
			{
				epochCount--;
				for (int i = Stuff.p + 1; i <= Stuff.N; i++)
				{
					neuron.Learn(i);
				}

				Console.WriteLine("E= {0:0.00000}", neuron.GetTotalError());
			}
		}
	}
}
