using System;
using System.Collections;
using System.Collections.Generic;
using CalculatorApp.Events;
using CalculatorApp.Interfaces;
using CalculatorApp.Operators;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace CalculatorApp
{
	public class CalculatorOperatorInput : MonoBehaviour
	{
		[Title("Event References")]
		[SerializeField]
		private ButtonEventHandler buttonEvents;
		
		/*[HorizontalGroup("Horizontal", 0.9f)]
		[Title("Component References")]
		[Tooltip("A specified reference to a calculator component.\n" +
		         "\nIf the override is disabled for the calculator reference, " +
		         "the script will attempt to find a calculator component in the scene.")]
		[EnableIf("@overrideCalculatorReference == true")]
		[SerializeField]
		public Calculator calculator;
		
		[HorizontalGroup("Horizontal")]
		[Title("")] // empty title to align the button with the calculator reference
		[HideLabel]
		[ToggleLeft]
		[SerializeField] 
		private bool overrideCalculatorReference;*/
		
		[Title("Calculator")]
		[Tooltip("A specified operation to perform on the calculator.")]
		[SerializeField]
		private Operation calculatorOperation;

		private ICalculatorOperation _operation;
		private Button _button;

		#region Unity Methods

		private void Awake()
		{
			// Get the button component
			_button = GetComponent<Button>();
			
			// assign the operator type
			switch (calculatorOperation)
			{
				case Operation.Addition:
					_operation ??= new AdditionOperation();
					break;
				case Operation.Subtraction:
					_operation ??= new SubtractionOperation();
					break;
				case Operation.Multiplication:
					_operation ??= new MultiplyOperation();
					break;
				case Operation.Division:
					_operation ??= new DivisionOperation();
					break;
				default:
					SwitchDefaulted(calculatorOperation);
					break;
			}
		}

		private void OnEnable() => _button.onClick.AddListener(OnClick);

		private void OnDisable() => _button.onClick.RemoveListener(OnClick);

		#endregion
		
		private void OnClick()
		{
			if (buttonEvents != null) buttonEvents.OperationButtonPress(_operation);
		}

		private void SwitchDefaulted(Operation operation)
		{
			Debug.LogError($"Operation \"{operation.ToString()}\" NOT implemented, " +
			               $"please add the proper class/interface to the switch statement.");
		}
		
		public enum Operation
		{
			Addition,
			Subtraction,
			Multiplication,
			Division
		}
	}
}