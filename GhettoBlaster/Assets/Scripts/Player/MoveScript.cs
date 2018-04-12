using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour 
{
    public TrackManager manager;
    public float bpmScale;
	public float moveSpeed;
    public float maxSpeed;
	public Rigidbody playerBody;
    private Vector3 moveDirection;

	void Update () 
	{
		MovePlayer();
		FacingRightStick ();
	}


	void MovePlayer()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.fixedDeltaTime;
        if (playerBody.velocity.magnitude < moveDirection.magnitude)
        {
            playerBody.velocity += moveDirection - playerBody.velocity;
        } 
    }

	void FacingRightStick()
	{
		float horizontal = Input.GetAxis("RightJoystickX");
		float vertical = Input.GetAxis("RightJoystickY");
		float rot_Y = Mathf.Atan2 (vertical, horizontal) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, rot_Y, 0);
	}
}
