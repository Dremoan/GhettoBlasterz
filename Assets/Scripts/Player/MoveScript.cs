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
	public Animator anim;

	void Update () 
	{
		MovePlayer();
		FacingRightStick ();
		if(anim != null)anim.SetFloat ("speed", playerBody.velocity.magnitude);
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
		transform.rotation = Quaternion.Euler (0, rot_Y + 90, 0);
	}
}
