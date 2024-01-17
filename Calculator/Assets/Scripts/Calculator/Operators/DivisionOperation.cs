using CalculatorApp.Interfaces;

namespace CalculatorApp.Operators
{
	public class DivisionOperation : ICalculatorOperation
	{
		public double Calculate(double a, double b) => a / b;
	}
}
