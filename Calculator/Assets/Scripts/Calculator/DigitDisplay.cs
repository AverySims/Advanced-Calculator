using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using CalculatorApp.Events;
using CalculatorApp.Interfaces;
using CalculatorApp.Operators;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace CalculatorApp
{
	public class DigitDisplay : MonoBehaviour
	{
		[Title("Event References")]
		[SerializeField]
		private ButtonEventHandler buttonEvents;

		[FormerlySerializedAs("currentValue")]
		[Title("Component References")]
		[SerializeField]
		private TextMeshProUGUI currentValueText;
		
		[FormerlySerializedAs("previousValue")] [SerializeField]
		private TextMeshProUGUI previousValueText;

		private string _currentValue;
		private string _previousValue;
		private string _operation;
		private bool _operationSet;
		
		#region Unity Methods

		private void Awake()
		{
			currentValueText.text = "";
			previousValueText.text = "";
		}

		private void OnEnable()
		{
			buttonEvents.OnValueUpdated += OnValueUpdated;
			buttonEvents.OnOperationButtonPressed += OnOperatorButtonPressed;
			buttonEvents.OnClearButtonPressed += OnClearButtonPressed;
			buttonEvents.OnEqualsButtonPressed += OnEqualsButtonPressed;
		}

		private void Start()
		{
			
		}

		private void OnDisable()
		{
			buttonEvents.OnValueUpdated -= OnValueUpdated;
			buttonEvents.OnOperationButtonPressed -= OnOperatorButtonPressed;
			buttonEvents.OnClearButtonPressed -= OnClearButtonPressed;
			buttonEvents.OnEqualsButtonPressed -= OnEqualsButtonPressed;
		}

		#endregion
		
		private void OnValueUpdated(double value)
		{
			_currentValue = value.ToString(CultureInfo.CurrentCulture);
			currentValueText.text = _currentValue;
		}
		
		private void OnOperatorButtonPressed(ICalculatorOperation operation)
		{
			if (_operation == operation.ToString()) return;
			
			_operation = operation.ToString();
			_previousValue = _currentValue;
			
			switch (operation)
			{
				case AdditionOperation:
					previousValueText.text = $"{_previousValue} +";
					break;
				case SubtractionOperation:
					previousValueText.text = $"{_previousValue} -";
					break;
				case MultiplyOperation:
					previousValueText.text = $"{_previousValue} *";
					break;
				case DivisionOperation:
					previousValueText.text = $"{_previousValue} /";
					break;
			}
		}
		
		private void OnClearButtonPressed()
		{
			// currentValue.text = "";
		}
		
		private void OnEqualsButtonPressed()
		{
			_previousValue = "";
			previousValueText.text = "";
		}
	}
}