using System;

namespace neuroLab_3
{
	class Neuron
	{
		public double[] w; //Weights
		public double[] x; //Inputs
		readonly int p; //Inputs count
		double rate;
		public bool on;

		public Neuron(int N, int inputs, double rate)
		{
			p = inputs;
			this.rate = rate;
			w = new double[inputs + 1];
			x = new double[2 * N];
			for (int i = 0; i <= p; i++)
			{
				w[i] = 0;
				x[i] = Stuff.x_reference[i];
			}
			on = true;
		}

		public void GenerateNextValue(int n)
		{
			double value = 0;
			for (int k = 1; k <= p; k++)
				value += w[k] * Stuff.x_reference[n - p + k - 1];
			value += w[0];
			x[n] = value;
		}

		public void WidrowHoff(int index)
		{
			for (int k = 1; k <= p; k++)
			{
				w[k] += rate * (Stuff.x_reference[index] - x[index]) * x[index - p + k - 1];
			}
			w[0] += rate * (Stuff.x_reference[index] - x[index]);
		}

		public void Learn(int index)
		{
			GenerateNextValue(index);
			WidrowHoff(index);
		}

		public double GetTotalError()
		{
			double temp = 0.0;
			for (int i = 1; i <= Stuff.N; i++)
			{
				temp += Math.Pow(x[i] - Stuff.x_reference[i], 2);
			}
			return Math.Sqrt(temp);
		}

		public void printWeights()
		{
			string ws = "";
			for (int i = 0; i <= p; i++)
			{
				ws += Convert.ToString(Math.Round(w[i], 4)) + " ";
			}
			Console.WriteLine("Weights: {0}", ws);
		}

	}
}
