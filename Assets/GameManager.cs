using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private MovingGround movingGround;
    private GameObject ground;
    private GameObject player;


    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
        ground = GameObject.FindWithTag("ground");
        player = GameObject.FindWithTag("Player");
        movingGround = ground.GetComponent<MovingGround>();
	}
	
	// Update is called once per frame
	void Update () {
        movingGround.move();

        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(-moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
