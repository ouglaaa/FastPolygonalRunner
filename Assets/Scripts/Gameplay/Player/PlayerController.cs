using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FastPolygonalRunner.Framework.Extensions;
using FastPolygonalRunner.Framework; 

public class PlayerController : MonoBehaviour
{
	private LinkedList<Vector3> _anchorList = new LinkedList<Vector3>();
	private LinkedListNode<Vector3> _current;

	// Use this for initialization
	void Start()
	{
		foreach (var t in LevelManager.Get.Anchors)
		{
			_anchorList.AddLast(t.position);
		}
		_current = _anchorList.First.Next;
	}

	private Coroutine2 _movingCoroutine; // See /Assets/Framework
	// TODO: Move somewhere in the input manager, somehow...
	void Update()
	{
		if (Input.GetKeyDown("left")) // IsRunning() is an extension that prevents null ref when the coroutine is not running...
		{
			Move(_current.Previous);
		}
		else if (Input.GetKeyDown("right"))
		{
			Move(_current.Next);
		}
		transform.rotation = Quaternion.AngleAxis(Time.time * Mathf.PI * 200,  Vector3.left);
	}

	private void Move(LinkedListNode<Vector3> node)
	{
		if (node != null && !_movingCoroutine.IsRunning())
		{
			_current = node;
			_movingCoroutine = this.StartCoroutine2(MoveTowards(_current.Value));
		}
	}

	public IEnumerator MoveTowards(Vector3 position)
	{
		float time = 0.0f;
		while (transform.position != position)
		{
			time += Time.fixedDeltaTime;
			var pos = Vector3.Lerp(transform.position, position, time);
			transform.position = pos;
			yield return new WaitForEndOfFrame();
		}
	}



}

