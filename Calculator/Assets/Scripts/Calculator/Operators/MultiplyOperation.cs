using Calculator.Interfaces;

namespace Calculator.Operators
{
	public class MultiplyOperation : ICalculatorOperation
	{
		public decimal Execute(decimal a, decimal b) => a * b;
	}
}
