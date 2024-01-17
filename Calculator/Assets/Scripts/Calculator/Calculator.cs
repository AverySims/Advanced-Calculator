using System.Collections;
using System.Collections.Generic;
using CalculatorApp.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace CalculatorApp
{
	public class Calculator : MonoBehaviour
	{
		[HorizontalGroup("Horizontal")]
		[BoxGroup("Horizontal/Variable A")]
		[HideLabel]
		[SerializeField]
		public double variableA;

		[BoxGroup("Horizontal/Variable B")]
		[HideLabel]
		[SerializeField]
		public double variableB;
		
		private ICalculatorOperation _operation;

		public void SetOperation(ICalculatorOperation operation)
		{
			_operation = operation;
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