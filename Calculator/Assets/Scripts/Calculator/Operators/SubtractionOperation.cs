using Calculator.Interfaces;

namespace Calculator.Operators
{
	public class SubtractionOperation : ICalculatorOperation
	{
		public decimal Calculate(decimal a, decimal b) => a - b;
	}
}
