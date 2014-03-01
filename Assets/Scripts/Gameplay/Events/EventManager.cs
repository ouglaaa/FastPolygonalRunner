using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using FastPolygonalRunner.Framework.Extensions;
using System.Collections;

public class EventManager : MonoBehaviour
{
	public GameObject[] Events = new GameObject[0];
	public Transform FrontAnchor;
	public Transform BackAnchor;

	private List<MonoBehaviour> _events = new List<MonoBehaviour>();



	public void Start()
	{
		this.StartCoroutine2(CreateNewEvents());
	}


	private void CreateRandomEvent()
	{
		var go = Events.GetRandomElem();

		var newEvent = GameObject.Instantiate(go) as GameObject;
		newEvent.transform.parent = this.transform;
		_events.Add(newEvent.GetComponent<CubeEvent>());

	}
	// TODO: Change to Whatever IEvent might be.
	// Change List vs []
	public MonoBehaviour[] GetEvents()
	{
		return _events.ToArray();
	}

	public void UpdatePositions(float dz)
	{
		foreach (var ev in _events)
		{
			var pos = ev.transform.position;
			pos.z += dz;
			ev.transform.position = pos;
		}

	}


	private float _freq = 1f;

	// TODO: Create Timer to do that fucking shit.
	public IEnumerator CreateNewEvents()
	{
		while (true)
		{

			CreateRandomEvent();
			yield return new WaitForSeconds(_freq);
		}


	}

	public void Update()
	{

		DebugUpdate();
	}


// TODO: Create Behaviour MasterClass with debug infos / inputs in it.
	public void DebugUpdate()
	{
#if DEBUG || UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Insert))
		{
			CreateRandomEvent();
		}
#endif
	}
#if DEBUG || UNITY_EDITOR
	public void OnGUI()
	{
		GUI.Label(new Rect(10, 50, 200, 20), string.Format("EventManager.Count: {0}", _events.Count));
	}
#endif
}
