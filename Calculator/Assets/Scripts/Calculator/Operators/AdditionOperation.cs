using CalculatorApp.Interfaces;

namespace CalculatorApp.Operators
{
	public class AdditionOperation : ICalculatorOperation
	{
		public double Calculate(double a, double b) => a + b;
	}
}
