using Calculator.Interfaces;

namespace Calculator.Operators
{
	public class AdditionOperation : ICalculatorOperation
	{
		public decimal Calculate(decimal a, decimal b) => a + b;
	}
}
