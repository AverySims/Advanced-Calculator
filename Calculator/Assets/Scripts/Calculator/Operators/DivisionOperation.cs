using Calculator.Interfaces;

namespace Calculator.Operators
{
	public class DivisionOperation : ICalculatorOperation
	{
		public decimal Calculate(decimal a, decimal b) => a / b;
	}
}
