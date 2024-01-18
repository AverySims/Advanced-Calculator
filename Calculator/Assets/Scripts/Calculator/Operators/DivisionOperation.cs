using CalculatorApp.Interfaces;

namespace CalculatorApp.Operators
{
	public class DivisionOperation : ICalculatorOperation
	{
		public double Calculate(double a, double b)
		{
			if (a == 0 || b == 0) return double.NaN; // return NaN if either operand is 0 (shouldn't divide by 0)
			return a / b;
		}
	}
}
