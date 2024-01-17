using CalculatorApp.Interfaces;

namespace CalculatorApp.Operators
{
	public class MultiplyOperation : ICalculatorOperation
	{
		public double Calculate(double a, double b) => a * b;
	}
}
