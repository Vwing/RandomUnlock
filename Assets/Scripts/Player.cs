using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	//public bool externJumpEnabled = true;
	public List<GameObject> colliding = new List<GameObject>();
	public GameObject timerControl;
	public float walkSpeed = 1.0f;
	//public float jumpForce = 450.0f;
	public float jetForce = 10.0f;
	public float jumpSpeed = 16.0f;
	public float maxJumpHeight = 4.0f;
	public float minJumpHeight = 0.5f;
	public ParticleSystem smoke;
	public Transform spawnPoint1;
	public Transform spawnPoint2;
	public Transform spawnPoint3;
	public Transform spawnPoint4;
	public Transform spawnPoint5;
	public AudioClip walk;
	public AudioClip jump;
	private float timer;
	public string biome;
	
	bool right = true;
	public bool jumpAllowed = false;
	bool fallEnabled = false;
	string oldBiome;
	float startJumpY;
	
	Transform sprite;
	//	Transform jetpack;
	Rigidbody2D rb;
	Animator anim;
	//	BoxCollider2D coll;
	
	void Awake()
	{
		biome = "M";
		oldBiome = biome;
		sprite = transform.FindChild("Sprite");
		//		jetpack = transform.FindChild("Jetpack");
		rb = GetComponent<Rigidbody2D>();
		anim = sprite.GetComponent<Animator>();
		//		coll = GetComponent<BoxCollider2D>();
	}
	
	void Start () 
	{
	}
	
	void FixedUpdate ()
	{
		SetBiome ();
		if (biome != oldBiome) {
			timerControl.GetComponent<Timer>().timeLeft = timerControl.GetComponent<Timer>().startTime;
			AchievementController.LoadObjectives(biome);	
		}
		LateralMovement();
		if(Input.GetButton ("Fire1")){
			Jetpack ();
			smoke.enableEmission = true;
		} else
			smoke.enableEmission = false;

		if(colliding.Count == 0)
			jumpAllowed = false;
		else
			jumpAllowed = true;
		if(Input.GetButtonDown ("Jump") && jumpAllowed){
			Jump ();
			AchievementController.IncrementAchievement("J10");
		}
		if(Input.GetButtonUp ("Jump") && fallEnabled)
			StopJump();

		if (jumpAllowed == false) {
			timer += Time.deltaTime;
			if(timer > 2)
			{
				AchievementController.IncrementAchievement("FS2");
			}
			if(timer > 3)
			{
				AchievementController.IncrementAchievement("FS3");
			}
			if(timer > 4 && biome == "J")
			{
				AchievementController.IncrementAchievement("FJ");
			}
			if(timer > 4 && biome == "D")
			{
				AchievementController.IncrementAchievement("FD");
			}
			if(timer > 4 && biome == "U")
			{
				AchievementController.IncrementAchievement("FU");
			}
			if(timer > 4 && biome == "G")
			{
				AchievementController.IncrementAchievement("FG");
			}
			if(timer > 4 && biome == "M")
			{
				AchievementController.IncrementAchievement("FM");
			}
		}
		oldBiome = biome;
	}
	
	void SetBiome()
	{
		if(this.transform.position.y<90 && this.transform.position.y>60)
		{
			biome = "J";
		}
		if(this.transform.position.y<60 && this.transform.position.y>29)
		{
			biome = "D";
		}
		if(this.transform.position.y<29 && this.transform.position.y>0)
		{
			biome = "U";
		}
		if(this.transform.position.y<150 && this.transform.position.y>90)
		{
			biome = "G";
		}
		if(this.transform.position.y<180 && this.transform.position.y>150)
		{
			biome = "M";
		}
	}
	
	float xAxis;
	
	void LateralMovement()
	{
		xAxis = Input.GetAxis ("Horizontal");
		
		if (xAxis == 0) {
			anim.enabled = false;
			
		}else
			anim.enabled = true;
		
		if(xAxis > 0 && !right || xAxis < 0 && right)
			Flip ();
		
		Vector3 walkDirection = new Vector3(xAxis,0,0);
		transform.Translate(walkDirection * walkSpeed * Time.deltaTime);
		
		
	}
	
	public void Death()
	{
		if(biome == "M")
		{
			transform.position = spawnPoint1.position;
		}
		if(biome == "G")
		{
			transform.position = spawnPoint2.position;
		}
		if(biome == "J")
		{
			transform.position = spawnPoint3.position;
		}
		if(biome == "D")
		{
			transform.position = spawnPoint4.position;
		}
		if(biome == "U")
		{
			transform.position = spawnPoint5.position;
		}
		
	}
	
	void Jump()
	{
		//rb.AddForce (Vector3.up * jumpForce);
		//float jumpVelocity = Mathf.Sqrt( 2 * -Physics.gravity.y * jumpHeight );
		float jumpVelocity = Mathf.Sqrt (4 * -Physics.gravity.y * maxJumpHeight);
		rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
		
		startJumpY = transform.position.y;
		fallEnabled = true;
		AudioSource.PlayClipAtPoint (jump, this.transform.position);
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
		colliding.Add (other.gameObject);
		//jumpAllowed = true;
		if(other.gameObject.tag == "MovablePlatform")
			transform.SetParent (other.transform);
		if(biome == "J")
		{
			AchievementController.IncrementAchievement("WJ");
		}
		if(biome == "D")
		{
			AchievementController.IncrementAchievement("WD");
		}
		if(biome == "U")
		{
			AchievementController.IncrementAchievement("WU");
		}
		if(biome == "G")
		{
			AchievementController.IncrementAchievement("WG");
		}
		if(biome == "M")
		{
			AchievementController.IncrementAchievement("WM");
		}
	}
	
	void OnCollisionStay2D(Collision2D other)
	{
		//jumpAllowed = true;
		timer = 0;
	}
	
	void OnCollisionExit2D(Collision2D other)
	{
		//jumpAllowed = false;
		colliding.Remove (other.gameObject);
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