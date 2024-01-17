using Calculator.Interfaces;

namespace Calculator.Operators
{
	public class DivisionOperation : ICalculatorOperation
	{
		public decimal Execute(decimal a, decimal b) => a / b;
	}
}
