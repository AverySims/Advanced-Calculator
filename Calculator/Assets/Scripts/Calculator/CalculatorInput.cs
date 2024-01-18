using System;
using System.Collections;
using System.Collections.Generic;
using CalculatorApp.Events;
using CalculatorApp.Operators;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace CalculatorApp
{
	public class CalculatorInput : MonoBehaviour
	{
		[Title("Event References")]
		[SerializeField]
		private ButtonEventHandler buttonEvents;

		[Title("Component References")]
		[Title("", "Operators")]
		[SerializeField]
		private Button additionOperator;
		
		[SerializeField]
		private Button subtractionOperator;
		
		[SerializeField]
		private Button multiplicationOperator;
		
		[SerializeField]
		private Button divisionOperator;
		
		[Title("", "Digits")]
		[Tooltip("A list of button component references for the digits \"0\" through \"9\".\n" +
		         "Component references should be assigned in order from least to greatest.")]
		[SerializeField]
		private List<Button> digitButtons;

		[Title("", "Decimal and Sign")]
		[Tooltip("The button component reference to convert the value to a decimal value.")]
		[SerializeField]
		private Button decimalButton;
		
		[Tooltip("The button component reference to convert the value to a flip the sign value.")]
		[SerializeField]
		private Button signButton;

		[Title("", "Clear and Equals")]
		[Tooltip("The button component reference to clear the current value.")]
		[SerializeField]
		private Button clearButton;
		
		[Tooltip("The button component reference to calculate the current equation")]
		[SerializeField]
		private Button equalsButton;
		
		#region Unity Methods

		private void OnEnable()
		{
			// subscribe to the button click events
			additionOperator.onClick.AddListener(() => buttonEvents.OperationButtonPress(new AdditionOperation()));
			subtractionOperator.onClick.AddListener(() => buttonEvents.OperationButtonPress(new SubtractionOperation()));
			multiplicationOperator.onClick.AddListener(() => buttonEvents.OperationButtonPress(new MultiplyOperation()));
			divisionOperator.onClick.AddListener(() => buttonEvents.OperationButtonPress(new DivisionOperation()));
			
			for (int i = 0; i < digitButtons.Count; i++)
			{
				int value = i;
				digitButtons[i].onClick.AddListener(() => OnDigitClick(value));
			}
			
			decimalButton.onClick.AddListener(OnDecimalClick);
			signButton.onClick.AddListener(OnSignClick);

			clearButton.onClick.AddListener(OnClearClick);
			equalsButton.onClick.AddListener(OnEqualsClick);
		}

		private void OnDisable()
		{
			// un-subscribe to the button click events
			additionOperator.onClick.RemoveAllListeners();
			subtractionOperator.onClick.RemoveAllListeners();
			multiplicationOperator.onClick.RemoveAllListeners();
			divisionOperator.onClick.RemoveAllListeners();
			
			foreach (var button in digitButtons)
			{
				button.onClick.RemoveAllListeners();
			}
			
			decimalButton.onClick.RemoveListener(OnDecimalClick);
			signButton.onClick.RemoveListener(OnSignClick);
			
			clearButton.onClick.RemoveListener(OnClearClick);
			equalsButton.onClick.RemoveListener(OnEqualsClick);
		}

		#endregion
		
		/// <summary>
		/// This method will be called when a digit button (0-9) is clicked.
		/// </summary>
		/// <param name="value">The value of the digit button.</param>
		private void OnDigitClick(int value)
		{
			if (buttonEvents != null) buttonEvents.DigitButtonPress(value);
			
			Debug.Log($"Digit {value} was clicked!");
		}
		
		/// <summary>
		/// This method will be called when the decimal button is clicked.
		/// </summary>
		private void OnDecimalClick()
		{
			if (buttonEvents != null) buttonEvents.DecimalButtonPress();
			
			Debug.Log("Decimal was clicked!");
		}
		
		/// <summary>
		/// This method will be called when the sign button is clicked.
		/// </summary>
		private void OnSignClick()
		{
			if (buttonEvents != null) buttonEvents.SignButtonPress();
			
			Debug.Log("Sign was clicked!");
		}
		
		private void OnClearClick()
		{
			if (buttonEvents != null) buttonEvents.ClearButtonPress();
			
			Debug.Log("Clear was clicked!");
		}
		
		private void OnEqualsClick()
		{
			if (buttonEvents != null) buttonEvents.EqualsButtonPress();
			
			Debug.Log("Equals was clicked!");
		}
	}
}