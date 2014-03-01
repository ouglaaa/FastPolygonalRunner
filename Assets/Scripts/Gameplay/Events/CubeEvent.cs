using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UE = UnityEngine;


public class CubeEvent : MonoBehaviour, IEvent
{
	public GameObject Cube;

	//public Action OnDestroy { get; set; }

	//public bool Init(Action onDestroy)
	//{
	//	OnDestroy = onDestroy;
	//	return true;
	//}
	

	public void Start()
	{
		var anchors = LevelManager.Get.Anchors;
		var backAnchor = LevelManager.Get.EventManager.BackAnchor;

		var idx = UE.Random.Range(0, anchors.Length - 1);

		var pos = anchors[idx].position;
		pos.z = backAnchor.position.z;
		transform.position = pos;
	}


	//public void Destroy()
	//{
	//	if (OnDestroy !=null)
	//	{
	//		OnDestroy();
	//	}
	//}
}
