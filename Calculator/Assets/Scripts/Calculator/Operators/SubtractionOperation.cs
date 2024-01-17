using CalculatorApp.Interfaces;

namespace CalculatorApp.Operators
{
	public class SubtractionOperation : ICalculatorOperation
	{
		public double Calculate(double a, double b) => a - b;
	}
}
