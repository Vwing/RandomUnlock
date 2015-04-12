using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float walkSpeed = 1.0f;
	//public float jumpForce = 450.0f;
	public float jetForce = 1.0f;
	public float jumpSpeed = 16.0f;
	public float maxJumpHeight = 4.0f;
	public float minJumpHeight = 0.5f;
	public ParticleSystem smoke;
	public Transform spawnPoint;
	
	bool right = true;
	bool jumpAllowed = false;
	bool fallEnabled = false;
	float startJumpY;
	
	Transform sprite;
	Transform jetpack;
	Rigidbody2D rb;
	Animator anim;
	BoxCollider2D coll;
	
	void Awake()
	{
		sprite = transform.FindChild("Sprite");
		jetpack = transform.FindChild("Jetpack");
		rb = GetComponent<Rigidbody2D>();
		anim = sprite.GetComponent<Animator>();
		coll = GetComponent<BoxCollider2D>();
	}
	
	void Start () 
	{
	}
	
	void FixedUpdate ()
	{
		LateralMovement();
		if(Input.GetButton ("Fire1")){
			Jetpack ();
			smoke.enableEmission = true;
		} else
			smoke.enableEmission = false;
		if(Input.GetButtonDown ("Jump") && jumpAllowed)
			Jump ();
		if(Input.GetButtonUp ("Jump") && fallEnabled)
			StopJump();
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
			//right = !right;
			Flip ();
//			sprite.RotateAround(transform.position + Vector3.left * -0.5f, Vector3.up, 180);
//			sprite.RotateAround(transform.position + Vector3.left * -0.5f, Vector3.up, 180);
		}
		Vector3 walkDirection = new Vector3(xAxis,0,0);
		transform.Translate(walkDirection * walkSpeed * Time.deltaTime);
	}

	public void Death()
	{
		transform.position = spawnPoint.position;
	}

	void Jump()
	{
		//rb.AddForce (Vector3.up * jumpForce);
		//float jumpVelocity = Mathf.Sqrt( 2 * -Physics.gravity.y * jumpHeight );
		float jumpVelocity = Mathf.Sqrt (4 * -Physics.gravity.y * maxJumpHeight);
		rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
		
		startJumpY = transform.position.y;
		fallEnabled = true;
	}
	
	void StopJump()
	{
		if(rb.velocity.y > 0)
		{
			if(transform.position.y - startJumpY < minJumpHeight)
			{
				float minVel = Mathf.Sqrt(4 * -Physics.gravity.y * ( (startJumpY + minJumpHeight) - transform.position.y) );
				rb.velocity = new Vector2(rb.velocity.x, minVel);
			}
			else
			{
				rb.velocity = new Vector2(rb.velocity.x, 0.1f);
			}
		}
		fallEnabled = false;
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		right = !right;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
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