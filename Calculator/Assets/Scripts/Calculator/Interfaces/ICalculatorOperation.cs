namespace Calculator.Interfaces
{
	/// <summary>
	/// Interface representing a calculator operation.
	/// </summary>
	public interface ICalculatorOperation
	{
		/// <summary>
		/// Executes the specified operation on the given operands.
		/// </summary>
		decimal Execute(decimal a, decimal b);
	}
}