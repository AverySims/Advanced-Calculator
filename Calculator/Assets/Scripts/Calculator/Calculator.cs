using System.Collections;
using System.Collections.Generic;
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
		
		private ICalculatorOperation _operation;

		public void SetOperation(ICalculatorOperation operation)
		{
			_operation = operation;
			
			if (buttonEvents != null) buttonEvents.OperationButtonPress(operation);
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