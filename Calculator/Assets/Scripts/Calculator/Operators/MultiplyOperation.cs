using Calculator.Interfaces;

namespace Calculator.Operators
{
	public class MultiplyOperation : ICalculatorOperation
	{
		public decimal Calculate(decimal a, decimal b) => a * b;
	}
}
