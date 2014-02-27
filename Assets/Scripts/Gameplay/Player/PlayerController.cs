using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FastPolygonalRunner.Framework.Extensions;
using FastPolygonalRunner.Framework;

public class PlayerController : MonoBehaviour
{
	private LinkedList<Vector3> _anchorList = new LinkedList<Vector3>();
	private LinkedListNode<Vector3> _current;
	public float LateralSpeed = 5f;

	private iTweenEvent _jumpTween;
	private GameObject _jumpGhost;
	public AnimationCurve JumpCurve;

	// Use this for initialization
	void Start()
	{
		//animation.Stop();
		foreach (var t in LevelManager.Get.Anchors)
		{
			_anchorList.AddLast(t.position);
		}
		_current = _anchorList.First.Next;
		_jumpTween = gameObject.GetComponent<iTweenEvent>();
		_jumpGhost =  new GameObject("JumpGhost");
		_jumpGhost.transform.parent = transform;
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
		else if (Input.GetKeyDown("space"))
		{
			Jump();
		}
		transform.rotation = Quaternion.AngleAxis(Time.time * Mathf.PI * 200, Vector3.left);
	}


	private void Jump()
	{
		if (!_movingCoroutine.IsRunning() && JumpCurve != null)
		{
			_movingCoroutine =  this.StartCoroutine2(JumpTowards(5f));
		}

	}
	
	private void Move(LinkedListNode<Vector3> node)
	{
		if (node != null && !_movingCoroutine.IsRunning())
		{
			_current = node;
			_movingCoroutine = this.StartCoroutine2(MoveTowards(_current.Value));
		}
	}

	private IEnumerator JumpTowards(float howHigh)
	{
		float time = 0.0f;
		float animTime = 1f;

		var pos = transform.position;

		while (time < animTime)
		{
			var y = JumpCurve.Evaluate(time);
			var ppos = transform.position;
			ppos.y = y;
			transform.position = ppos;
			time += Time.fixedDeltaTime;
			
			yield return new WaitForEndOfFrame();
		}

	}
	public IEnumerator MoveTowards(Vector3 position)
	{
		float time = 0.0f;
		while (transform.position != position)
		{
			time += Time.fixedDeltaTime;
			var pos = Vector3.MoveTowards(transform.position, position, Time.fixedDeltaTime * LateralSpeed); //Vector3.Lerp(transform.position, position, time);
			transform.position = pos;
			Quaternion rotation = transform.rotation * Quaternion.AngleAxis(time * Mathf.PI * 200, pos.normalized.x > 0 ? Vector3.forward : Vector3.back);
			transform.rotation = rotation;
			yield return new WaitForEndOfFrame();
		}
	}



}

