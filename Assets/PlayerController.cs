using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    private LevelManager _levelManager;    
    private LinkedList<Vector3> _anchorList = new LinkedList<Vector3>();
    private LinkedListNode<Vector3> _current;

	// Use this for initialization
    void Start()
    {
        _levelManager = LevelManager.Get;        
        _anchorList.AddFirst(_levelManager.Anchor[0].position);
        _anchorList.AddLast(_levelManager.Anchor[1].position);
        _anchorList.AddLast(_levelManager.Anchor[2].position);
        _current = _anchorList.First.Next;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("left")) {
            if (_current.Previous != null)
            {
                transform.position = _current.Previous.Value;
                _current = _current.Previous;
            }
            
        } else if (Input.GetKeyDown("right")) {
            if (_current.Next != null)
            {
                transform.position = _current.Next.Value;
                _current = _current.Next;
            }
                        
        } 
	}
}
