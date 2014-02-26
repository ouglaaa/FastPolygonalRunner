using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastPolygonalRunner.Framework;
using UnityEngine;

namespace FastPolygonalRunner.Framework.Extensions
{
	public static class MonoBehaviourExts
	{
		public static Coroutine2 StartCoroutine2(this MonoBehaviour mb, IEnumerator func)
		{
			return CoroutineManager.Get.StartCoroutine(func);
		}

		public static bool IsRunning(this Coroutine2 routine)
		{
			return routine != null && routine.UseExtensionMethodIsRunning;
		}
	}
}
