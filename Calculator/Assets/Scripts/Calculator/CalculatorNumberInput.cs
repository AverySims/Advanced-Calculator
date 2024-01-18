using System;
using System.Collections;
using System.Collections.Generic;
using CalculatorApp.Events;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace CalculatorApp
{
	public class CalculatorNumberInput : MonoBehaviour
	{
		[Title("Event References")]
		[SerializeField]
		private ButtonEventHandler buttonEvents;
		
		[Title("Component References")]
		[Tooltip("A list of button component references for the digits \"0\" through \"9\".\n" +
		         "Component references should be assigned in order from least to greatest.")]
		[SerializeField]
		private List<Button> digitButtons;

		[Tooltip("The button component reference to convert the value to a decimal value.")]
		[SerializeField]
		private Button decimalButton;
		
		[Tooltip("The button component reference to convert the value to a flip the sign value.")]
		[SerializeField]
		private Button signButton;

		#region Unity Methods

		private void OnEnable()
		{
			// subscribe to the button click events
			for (int i = 0; i < digitButtons.Count; i++)
			{
				int value = i;
				digitButtons[i].onClick.AddListener(() => OnDigitClick(value));
			}
			
			decimalButton.onClick.AddListener(OnDecimalClick);
			signButton.onClick.AddListener(OnSignClick);
		}

		private void OnDisable()
		{
			// un-subscribe to the button click events
			foreach (var button in digitButtons)
			{
				button.onClick.RemoveAllListeners();
			}
			
			decimalButton.onClick.RemoveListener(OnDecimalClick);
			signButton.onClick.RemoveListener(OnSignClick);
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
			
			Debug.Log($"Decimal was clicked!");
		}
		
		/// <summary>
		/// This method will be called when the sign button is clicked.
		/// </summary>
		private void OnSignClick()
		{
			if (buttonEvents != null) buttonEvents.SignButtonPress();
			
			Debug.Log($"Sign was clicked!");
		}
		
	}
}