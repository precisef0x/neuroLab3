using System;
using System.Collections.Generic;

namespace neuroLab_3
{
	public static class Stuff
	{
		public static int N, p, epochCount;
		public static double step, a, b;
		public static List<double> x_reference;

		public static double Function(double t)
		{
			return Math.Sqrt(0.1 * t) + 1.0;
		}

		public static void InitConstants(int N, double a, double b, int p)
		{
			Stuff.N = N;
			Stuff.a = a;
			Stuff.b = b;
			Stuff.p = p;
			x_reference = new List<double>();
			x_reference.Add(1);
			step = (1.0 / (N - 1)) * (b - a);

			for (double t = a; t <= 2 * b; t += step)
				x_reference.Add(Function(t));
		}
	}
}
