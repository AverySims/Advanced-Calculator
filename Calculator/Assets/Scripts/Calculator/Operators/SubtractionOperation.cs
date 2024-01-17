using Calculator.Interfaces;

namespace Calculator.Operators
{
	public class SubtractionOperation : ICalculatorOperation
	{
		public decimal Execute(decimal a, decimal b) => a - b;
	}
}
