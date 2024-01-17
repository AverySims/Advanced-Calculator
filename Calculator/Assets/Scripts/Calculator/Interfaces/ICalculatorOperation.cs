namespace CalculatorApp.Interfaces
{
	/// <summary>
	/// Interface representing a calculator operation.
	/// </summary>
	public interface ICalculatorOperation
	{
		/// <summary>
		/// Executes the specified operation on the given operands.
		/// </summary>
		public double Calculate(double a, double b);
	}
}