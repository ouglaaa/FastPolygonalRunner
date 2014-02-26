using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FastPolygonalRunner.Framework
{
	// TODO: may add debug infos
	public class Coroutine2 : IEnumerator
	{
		private IEnumerator _func;
		private bool _first = false;
		private bool _isRunning;


		public bool UseExtensionMethodIsRunning
		{
			get { return _isRunning; }
		}
		// TODO: may add debug infos
		public Coroutine2(IEnumerator func)
		{
			_func = func;
			
		}


		public object Current
		{
			get { return _func.Current; }
		}

		public bool MoveNext()
		{
			_first = true;
#if DEBUG || UNITY_EDITOR
			if (_first)
				if (_isRunning == false)
					Debug.Log("Coroutine started.");
#endif
			_isRunning = _func.MoveNext();
#if DEBUG || UNITY_EDITOR
			if (_isRunning == false)
				Debug.Log("Coroutine ended.");
#endif
			return _isRunning;
		}

		public void Reset()
		{
			_func.Reset();
		}
	}
}
