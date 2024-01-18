using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using CalculatorApp.Events;
using CalculatorApp.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CalculatorApp
{
	public class Calculator : MonoBehaviour
	{
		[Title("Event References")]
		[SerializeField]
		private ButtonEventHandler buttonEvents;
		
		[Title("Variable A")]
		[HorizontalGroup("Horizontal")]
		[HideLabel]
		[SerializeField]
		public double variableA;

		[Title("Variable B")]
		[HorizontalGroup("Horizontal")]
		[HideLabel]
		[SerializeField]
		public double variableB;
		
		private double _result;
		private ICalculatorOperation _operation;
		
		private bool _firstInput = true;
		private bool _isOperationSet;
		private bool _hasPressedDigit;
		
		// private bool _isDecimal;
		
		private readonly CultureInfo _cultureInfo = CultureInfo.CurrentCulture;
		
		private void Awake()
		{
			buttonEvents.ValueUpdate(_firstInput ? variableA : variableB);
		}
		
		private void OnEnable()
		{
			buttonEvents.OnDigitButtonPressed += OnDigitButtonPressed;
			buttonEvents.OnDecimalButtonPressed += OnDecimalButtonPressed;
			buttonEvents.OnSignButtonPressed += OnSignButtonPressed;
			buttonEvents.OnOperationButtonPressed += OnOperationButtonPressed;
			buttonEvents.OnClearButtonPressed += OnClearButtonPressed;
			buttonEvents.OnEqualsButtonPressed += OnEqualsButtonPressed;
		}

		private void OnDisable()
		{
			buttonEvents.OnDigitButtonPressed -= OnDigitButtonPressed;
			buttonEvents.OnDecimalButtonPressed -= OnDecimalButtonPressed;
			buttonEvents.OnSignButtonPressed -= OnSignButtonPressed;
			buttonEvents.OnOperationButtonPressed -= OnOperationButtonPressed;
			buttonEvents.OnClearButtonPressed -= OnClearButtonPressed;
			buttonEvents.OnEqualsButtonPressed -= OnEqualsButtonPressed;
		}
		
		public void OnOperationButtonPressed(ICalculatorOperation operation)
		{
			if (_firstInput && !_hasPressedDigit)
			{
				variableA = _result;
				variableB = 0;
				buttonEvents.ValueUpdate(_firstInput ? variableA : variableB);
			}
			
			_operation = operation;
			_firstInput = false;
			
			// Debug.Log($"Setting operation: {_operation}");
		}
		
		private void OnDigitButtonPressed(int digit)
		{
			// convert the current value to a string and append the digit
			var variable = _firstInput ? variableA.ToString(_cultureInfo) : variableB.ToString(_cultureInfo);
			
			bool isZero = variable.Length <= 1 && variable[0] == '0' && digit == 0;
			bool isMaxValue = variable.Length >= 15;
			
			// check if:
			// the value length is 1 or less, the value is 0, and the digit is 0.
			// if so, return to prevent adding 0 after 0.
			if (isZero || isMaxValue)
			{
				// force invoke the value update event to update the display
				buttonEvents.ValueUpdate(_firstInput ? variableA : variableB);
				return;
			}

			variable += digit.ToString(_cultureInfo);
			
			// convert the string back to a double and assign it to the appropriate variable
			if (_firstInput) variableA = double.Parse(variable, _cultureInfo);
			else variableB = double.Parse(variable, _cultureInfo);
			
			_hasPressedDigit = true;
			
			buttonEvents.ValueUpdate(_firstInput ? variableA : variableB);
		}
		
		private void OnDecimalButtonPressed()
		{
			// no functionality
		}
		
		private void OnSignButtonPressed()
		{
			
		}
		
		private void OnClearButtonPressed()
		{
			_result = 0;
			variableA = 0;
			variableB = 0;
			_firstInput = true;

			buttonEvents.ValueUpdate(_firstInput ? variableA : variableB);
		}
		
		private void OnEqualsButtonPressed()
		{
			_result = Calculate();
			_firstInput = true;
			
			buttonEvents.ValueUpdate(_result);
			// Debug.Log($"Result: {_result}");
		}
		
		public double Calculate()
		{
			return _operation.Calculate(variableA, variableB);
		}
		
		public double Calculate(double a, double b)
		{
			return _operation.Calculate(a, b);
		}
	
		public double Calculate(double a, double b, ICalculatorOperation operation)
		{
			return operation.Calculate(a, b);
		}
	}
}