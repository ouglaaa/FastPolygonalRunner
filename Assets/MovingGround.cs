using UnityEngine;
using System.Collections;

public class MovingGround : MonoBehaviour {

    private float offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void move () {
        Camera.main.fieldOfView = 75;
        offset += Time.deltaTime * 5;
        renderer.material.mainTextureOffset = new Vector2(0, offset);
	}
}
