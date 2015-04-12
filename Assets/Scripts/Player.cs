using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float walkSpeed = 1.0f;
	//public float jumpForce = 450.0f;
	public float jetForce = 1.0f;
	public float jumpSpeed = 16.0f;

	bool right = true;
	bool jumpAllowed = false;
	bool fallEnabled = false;

	float yBound;
	float xBound;

	Transform sprite;
	Rigidbody2D rb;
	Animator anim;
	BoxCollider2D coll;

	void Awake()
	{
		sprite = transform.FindChild("Sprite");
		rb = GetComponent<Rigidbody2D>();
		anim = sprite.GetComponent<Animator>();
		coll = GetComponent<BoxCollider2D>();
	}

	void Start () 
	{
		yBound = coll.bounds.extents.y;
		xBound = coll.bounds.extents.x;
	}

	void FixedUpdate ()
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
		if(!CanWalk ()){
			rb.velocity = Vector2.zero;
			return;
		}

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

	bool CanWalk()
	{
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(xBound,yBound + 0.1f), Vector2.right, 0.5f);
		if(hit.collider == null)
			return true;
		else
			return false;
	}

	void Jump()
	{
		//rb.AddForce (Vector3.up * jumpForce);
		//float jumpVelocity = Mathf.Sqrt( 2 * -Physics.gravity.y * jumpHeight );
		rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
		//fallEnabled = false;
	}

	void StopJump()
	{
		rb.velocity = new Vector2(rb.velocity.x, 0);
		//fallEnabled = true;
	}

	void Jetpack()
	{
		rb.AddForce(Vector3.up * jetForce);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		jumpAllowed = true;
		if(other.gameObject.tag == "MovablePlatform")
			transform.SetParent (other.transform);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		jumpAllowed = true;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		jumpAllowed = false;
		if(other.gameObject.tag == "MovablePlatform")
			transform.SetParent (null);
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