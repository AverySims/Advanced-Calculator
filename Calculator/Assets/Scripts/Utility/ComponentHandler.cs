using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
	public static class ComponentHandler
	{
		/// <summary>
		/// This method will return the component if it exists, otherwise it will add the component and return it.
		/// </summary>
		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			T component = gameObject.GetComponent<T>();
			if (component == null) component = gameObject.AddComponent<T>();
			return component;
		}
		
		/// <summary>
		/// This method will return the component if it exists, otherwise it will add the component and return it.
		/// </summary>
		public static T GetOrAddComponent<T>(this Component component) where T : Component
		{
			return GetOrAddComponent<T>(component.gameObject);
		}
		
		/// <summary>
		/// This method will find the component if it exists anywhere on the GameObject, parents, or children, otherwise it will return null.
		/// Optionally, you can specify whether or not to use only the parent of the GameObject instead of the root.
		/// </summary>
		public static T FindComponentInGameObject<T>(this GameObject gameObject, bool useParent = false) where T : Component
		{
			T component = gameObject.GetComponent<T>();
			if (component == null)
			{
				if (useParent && gameObject.transform.parent != null) component = gameObject.transform.parent.GetComponentInChildren<T>();
				else component = gameObject.transform.root.GetComponentInChildren<T>();
			}
			return component;
		}
		
		/// <summary>
		/// This method will find the component if it exists anywhere on the GameObject, parents, or children, otherwise it will return null.
		/// Optionally, you can specify whether or not to use only the parent of the GameObject instead of the root.
		/// </summary>
		public static T FindComponentInGameObject<T>(this Component component, bool useParent = false) where T : Component
		{
			return FindComponentInGameObject<T>(component.gameObject, useParent);
		}
	}
}