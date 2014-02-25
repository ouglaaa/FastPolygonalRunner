using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager _instance;
	public static LevelManager Get
	{
		get { return _instance; }
	}


	public GameObject[] Modules;
	public float FarPlane = 240;
	public float NearPlane = -40;
	public int StartingCount = 8;
	public float Speed = 50f;




	private List<GameObject> _levelModules = new List<GameObject>();
	private GameObject _level;

	public  void Awake()
	{
		var lm = GameObject.Find("LevelManager");
		if (lm == null)
		{
			lm = new GameObject("LevelManager");
		}
		_instance = lm.GetComponent<LevelManager>();

		_level = GameObject.Find("Level");
		if (_level == null)
		{
			_level = new GameObject("Level");
		}
	}

	public void Start()
	{
		for (int i = 0; i < StartingCount; ++i)
		{
			PushNewElement();
		}
	}
	
#if DEBUG || UNITY_EDITOR
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			Speed -= 10f;
		}
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			Speed += 10f;
		}
	}

	public void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 200, 20), string.Format("LevelManager.Speed: {0}", Speed));
		GUI.Label(new Rect(10, 30, 200, 20), string.Format("LevelManager.Count: {0}", _levelModules.Count));
	}
#endif

	// TODO: Peut etre faire l'update des positions des modules a un seul endroit, ca eviterait les liens Level <> LevelManager
	public void FixedUpdate()
	{
		var dt = Speed * Time.fixedDeltaTime;
		foreach (var go in _levelModules)
		{
			var pos = go.transform.position;
			pos.z += dt;
			go.transform.position = pos;
		}
	}

	// TODO: OPTIME LOL BAD GETCOMPO DANS UN UPDATE BAD BAD BAD, mais bon la fuck it.
	public void LateUpdate()
	{
		var first = _levelModules.First();
		var firstLevel = first.GetComponent<Level>();
		if (first.transform.position.z + firstLevel.GetSize().z > -20f)
		{
			Debug.Log("FirstZ: " + first.transform.position.z + firstLevel.GetSize().z);
			PushNewElement();
		}

		var last = _levelModules.Last();
		var lastLevel = last.GetComponent<Level>();
		if (last.transform.position.z + lastLevel.GetSize().z > FarPlane)
		{
			Debug.Log("FirstZ: " + last.transform.position.z + lastLevel.GetSize().z);
			
			_levelModules.RemoveAt(_levelModules.Count - 1);
			GameObject.DestroyImmediate(last.gameObject);
		}
	}

	private void PushNewElement()
	{
		int random = UnityEngine.Random.Range(0, Modules.Length - 1);
		var first = _levelModules.FirstOrDefault();
		var piece = Modules[random];
		Vector3 newPos = Vector3.zero;
		var go = GameObject.Instantiate(piece, Vector3.zero, this.transform.rotation) as GameObject;
		go.transform.parent = _level.transform;
		if (first != null)
		{
			var firstPosZ = first.transform.position.z;
			var firstSize = first.GetComponent<Level>().GetSize().z;
			var newSizeZ = go.GetComponent<Level>().GetSize().z;
			var sizeZ = (firstSize + newSizeZ) / 2.0f;
			var newPosZ = firstPosZ - sizeZ;



			go.transform.position = new Vector3(0, 0, newPosZ);

			_levelModules.Insert(0, (go));
		}
		else
		{
			go.transform.position = new Vector3(0, 0, 200f);
			_levelModules.Add(go);
		}
		
	}

	public void UnRegister(GameObject gameObject)
	{
		_levelModules.Remove(gameObject);
	}
}
