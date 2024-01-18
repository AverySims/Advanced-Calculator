using System;
using CalculatorApp.Interfaces;
using UnityEngine;

namespace CalculatorApp.Events
{
	[CreateAssetMenu(fileName = "ButtonEvents", menuName = "Calculator/Button Events")]
	public class ButtonEventHandler : ScriptableObject
	{
		public event Action<double> OnValueUpdated;
		public event Action<ICalculatorOperation> OnOperationButtonPressed;
		public event Action<int> OnDigitButtonPressed;
		public event Action OnDecimalButtonPressed;
		public event Action OnSignButtonPressed;
		public event Action OnClearButtonPressed;
		public event Action OnEqualsButtonPressed;
		
		public void ValueUpdate(double value) => OnValueUpdated?.Invoke(value);
		public void OperationButtonPress(ICalculatorOperation operation) => OnOperationButtonPressed?.Invoke(operation);
		public void DigitButtonPress(int digit) => OnDigitButtonPressed?.Invoke(digit);
		public void DecimalButtonPress() => OnDecimalButtonPressed?.Invoke();
		public void SignButtonPress() => OnSignButtonPressed?.Invoke();
		public void ClearButtonPress() => OnClearButtonPressed?.Invoke();
		public void EqualsButtonPress() => OnEqualsButtonPressed?.Invoke();
	}
}