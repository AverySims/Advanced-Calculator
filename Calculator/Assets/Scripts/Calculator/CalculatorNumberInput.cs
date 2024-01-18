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
		
		private void OnDigitClick(int value)
		{
			Debug.Log($"Digit {value} was clicked!");
		}
		
		private void OnDecimalClick()
		{
			Debug.Log($"Decimal was clicked!");
		}
		
		private void OnSignClick()
		{
			Debug.Log($"Sign was clicked!");
		}
		
	}
}