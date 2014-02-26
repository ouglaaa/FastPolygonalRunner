using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FastPolygonalRunner.Framework
{
	// Creates a gameobject that will serv as a proxy for coroutins contain every running coroutines

	public class CoroutineManager : MonoBehaviour
	{
		private static CoroutineManager _instance;
		public static CoroutineManager Get
		{
			get
			{
				if (_instance == null)
				{
					CreateCoroutineManager();
				}
				return _instance;
			}
		}
		private static void CreateCoroutineManager()
		{
			var name = typeof(CoroutineManager).Name.ToString();
			var go = GameObject.Find(name);
			if (go == null)
				go = new GameObject(name);
			_instance = go.AddComponent<CoroutineManager>();
		}

		public new Coroutine2 StartCoroutine(IEnumerator func)
		{
			var ret = new Coroutine2(func);
			base.StartCoroutine(ret);
			return ret;
		}

	}
	

}
