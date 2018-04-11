using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {


	public float moveSpeed;
	public Rigidbody playerBody;
	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		MovePlayer ();
	}

	void MovePlayer()
	{

		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		moveDirection = new Vector3(horizontal, 0, vertical);

		playerBody.velocity = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

	}
}
