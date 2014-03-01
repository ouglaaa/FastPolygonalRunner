using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollisionHandler : MonoBehaviour
{
	public void OnCollisionEnter(Collision col)
	{
		Debug.Log("Collided.");
		Debug.Log(col.relativeVelocity);
		


	}
}
