using System;
using System.Collections;
using System.Collections.Generic;
using CalculatorApp.Interfaces;
using CalculatorApp.Operators;
using UnityEngine;
using UnityEngine.Serialization;

namespace CalculatorApp
{
	public class CalculatorInput : MonoBehaviour
	{
		[SerializeField]
		public Calculator calculator;
		
		[SerializeField]
		private Operation calculatorOperation;

		private ICalculatorOperation _operation;
		
		private void Awake()
		{
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