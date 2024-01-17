using Calculator.Interfaces;

namespace Calculator.Operators
{
	public class AdditionOperation : ICalculatorOperation
	{
		public decimal Execute(decimal a, decimal b) => a + b;
	}
}
