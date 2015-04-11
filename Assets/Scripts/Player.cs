using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float walkSpeed = 1.0f;
	public float jumpForce = 450.0f;
	public float jetForce = 1.0f;
	public float jumpHeight = 10.0f;

	bool right = true;
	bool jumpAllowed = false;
	bool fallEnabled = false;
	float feetPos;

	Transform sprite;
	Rigidbody2D rb;
	Animator anim;

	Transform activePlatform = null;
	Vector3 activeLocalPlatformPoint;
	Vector3 activeGlobalPlatformPoint;
	Vector3 lastPlatformVelocity;

	void Start () 
	{
		sprite = transform.FindChild("Sprite");
		rb = GetComponent<Rigidbody2D>();
		anim = sprite.GetComponent<Animator>();
		feetPos = GetComponent<BoxCollider2D>().bounds.extents.y;
	}

	void Update ()
	{
		if(activePlatform != null){
			var newGlobalPlatformPoint = activePlatform.TransformPoint(activeLocalPlatformPoint);
			var moveDistance = (newGlobalPlatformPoint - activeGlobalPlatformPoint);
			if (moveDistance != Vector3.zero)
				transform.position += moveDistance;
			lastPlatformVelocity = (newGlobalPlatformPoint - activeGlobalPlatformPoint) / Time.deltaTime;
		} else
			lastPlatformVelocity = Vector3.zero;

		LateralMovement();
		if(Input.GetButton ("Fire1"))
			Jetpack ();
		if(Input.GetButtonDown ("Jump") && jumpAllowed)
			Jump ();
		if(Input.GetButtonUp ("Jump") && fallEnabled)
			StopJump ();

		// Moving platforms support
		if (activePlatform != null) {
			activeGlobalPlatformPoint = transform.position;
			activeLocalPlatformPoint = activePlatform.InverseTransformPoint (transform.position);
		}
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
		//rb.AddForce (Vector3.up * jumpForce);
		rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
		fallEnabled = true;
	}

	void StopJump()
	{
		rb.velocity = new Vector2(rb.velocity.x, 0);
		fallEnabled = false;
	}

	void Jetpack()
	{
		rb.AddForce(Vector3.up * jetForce);
	}
	
	void OnCollisionStay2D(Collision2D other)
	{
		jumpAllowed = true;
		if(other.gameObject.tag == "MovablePlatform" && other.transform.position.y <= feetPos)
			activePlatform = other.transform;
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