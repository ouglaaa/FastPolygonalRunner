using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Level : MonoBehaviour
{
	public GameObject Graphics = null;

	public Vector3 _size = Vector3.zero;
	private float _speed;
	private float _farPlane;

	public void Awake()
	{
		_size = CalculateSize();
	}

	public void Start()
	{
		var lm = LevelManager.Get;
		_speed = lm.Speed;
		_farPlane = lm.FarPlane;
	}

	public Vector3 GetSize()
	{
		return _size;
	}

	private Vector3 CalculateSize()
	{
		var colliders = Graphics.GetComponentsInChildren<Collider>();

		Vector3 min = Vector3.zero;
		Vector3 max = Vector3.zero;
		foreach (var col in colliders)
		{
			if (min.z > col.bounds.min.z)
				min.z = col.bounds.min.z;
			if (max.z < col.bounds.max.z)
				max.z = col.bounds.max.z;

			if (min.x > col.bounds.min.x)
				min.x = col.bounds.min.x;
			if (max.x < col.bounds.max.x)
				max.x = col.bounds.max.x;

			if (min.y > col.bounds.min.y)
				min.y = col.bounds.min.y;
			if (max.y < col.bounds.max.y)
				max.y = col.bounds.max.y;
		}

		var size = max - min;


		return size;
	}

	public void FixedUpdate()
	{

		
	}
}
