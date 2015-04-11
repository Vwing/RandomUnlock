using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float walkSpeed = 1.0f;
	public float jumpForce = 450.0f;
	public float jetForce = 1.0f;

	bool right = true;
	bool jumpAllowed = false;
	//float feetPos;

	Transform sprite;
	Rigidbody2D rb;
	Animator anim;
	GameObject activePlatform = null;

	void Start () 
	{
		sprite = transform.FindChild("Sprite");
		rb = GetComponent<Rigidbody2D>();
		anim = sprite.GetComponent<Animator>();
		//feetPos = GetComponent<BoxCollider2D>().bounds.extents.y;
	}

	void Update ()
	{
		LateralMovement();
		if(Input.GetButton ("Fire1"))
			Jetpack ();
		if(Input.GetButtonDown ("Jump") && jumpAllowed)
			Jump ();
	}

	float xAxis;

	void LateralMovement()
	{
		xAxis = Input.GetAxis ("Horizontal");

		if(xAxis == 0)
			anim.enabled = false;
		else
			anim.enabled = true;

		if(xAxis > 0 && !right || xAxis < 0 && right){
			right = !right;
			sprite.RotateAround(transform.position + Vector3.left * -0.5f, Vector3.up, 180);
		}
		Vector3 walkDirection = new Vector3(xAxis,0,0);
		transform.Translate(walkDirection * walkSpeed * Time.deltaTime);
	}

	void Jump()
	{
		rb.AddForce (Vector3.up * jumpForce);
	}

	void Jetpack()
	{
		rb.AddForce(Vector3.up * jetForce);
	}

//	void MoveWithPlatform()
//	{
//		if (activePlatform != null) {
//			var newGlobalPlatformPoint = activePlatform.TransformPoint(activeLocalPlatformPoint);
//			var moveDistance = (newGlobalPlatformPoint - activeGlobalPlatformPoint);
//			if (moveDistance != Vector3.zero)
//				controller.Move(moveDistance);
//			lastPlatformVelocity = (newGlobalPlatformPoint - activeGlobalPlatformPoint) / Time.deltaTime;
//			
//			// If you want to support moving platform rotation as well:
//			var newGlobalPlatformRotation = activePlatform.rotation * activeLocalPlatformRotation;
//			var rotationDiff = newGlobalPlatformRotation * Quaternion.Inverse(activeGlobalPlatformRotation);
//			
//			// Prevent rotation of the local up vector
//			rotationDiff = Quaternion.FromToRotation(rotationDiff * transform.up, transform.up) * rotationDiff;
//			
//			transform.rotation = rotationDiff * transform.rotation;
//		}
//		else {
//			lastPlatformVelocity = Vector3.zero;
//		}
//	}
	
	void OnCollisionStay2D(Collision2D other)
	{
		jumpAllowed = true;
		if(other.gameObject.tag == "MovablePlatform")
			activePlatform = other.gameObject;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		jumpAllowed = false;
		if(other.gameObject.tag == "MovablePlatform")
			activePlatform = null;
	}
}


//		string otherTag = other.gameObject.tag;
//		if(otherTag == "Ground")

//float feetPos;
//feetPos = GetComponent<BoxCollider2D>().bounds.extents.y;

//	bool IsGrounded()
//	{
//		return Physics2D.Raycast (transform.position,-Vector2.up,feetPos);
//	}

//	void Rotate180()
//	{
//		sprite.Rotate(Vector3.up * -180);
//		if(!right)
//			sprite.localPosition = Vector3.left * -1.0f;
//		else
//			sprite.localPosition = Vector3.zero;
//	}