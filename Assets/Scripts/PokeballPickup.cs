using UnityEngine;
using System.Collections;

public class PokeballPickup : MonoBehaviour {
	public Vector3 offset;
	private bool carried;
	private Vector3 newPos;
	private bool entered;
	public GameObject playerchar;
	public Rigidbody2D rb;
	public CircleCollider2D cc;
	//public CircleCollider2D ccColl;
	public float throwVelx;
	public float throwVely;
	public AudioClip picksup;
	public AudioClip throws;
	public AudioClip catchs;
	// Use this for initialization
	void Start () {
		carried = false;
		entered = false;
	}
	// Update is called once per frame
	void Update () {
		if (carried) {
			if(playerchar.transform.localScale.x >0)
				this.transform.position = playerchar.transform.position + offset;
			else
				this.transform.position = playerchar.transform.position + offset;
			rb.isKinematic = false;
			
		}
		if (entered) {
			if (Input.GetButtonDown ("Fire2")) {
				carried = true;
				rb.velocity =  Vector2.zero;
				rb.isKinematic=true;
				cc.isTrigger = true;
				AudioSource.PlayClipAtPoint (picksup, this.transform.position, 0.4f);
			}
		}
		if (carried) {
			playerchar.GetComponent<Player>().colliding.Remove (this.gameObject);
			if(Input.GetButtonDown ("Fire3"))
			{
				//playerchar.GetComponent<Player>().colliding.Add (this.gameObject);
				carried = false;
				//ccColl.isTrigger = false;
				if(playerchar.transform.localScale.x >0)
				{
					this.transform.position = playerchar.transform.position + new Vector3(1,3/5,0);
					rb.velocity = new Vector2(throwVelx,throwVely);
				}
				else
				{
					this.transform.position = playerchar.transform.position + new Vector3(-1,3/5,0);
					rb.velocity = new Vector2(-throwVelx,throwVely);
				}
				rb.isKinematic = false;
				cc.isTrigger = false;
				AudioSource.PlayClipAtPoint (throws, this.transform.position, 0.7f);
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("Entered");
			entered = true;
		}
		
		if (other.gameObject.tag == "Enemy" && (rb.velocity.x > .5 || rb.velocity.x < -0.5)) 
		{
			Destroy (other.gameObject);
			// Gotcha!
			rb.velocity = new Vector2(0,5);
			if (other.transform.position.y < 90 && other.transform.position.y > 59) {
				AchievementController.IncrementAchievement("PJ");
			}
			if (other.transform.position.y < 59 && other.transform.position.y > 29) {
				AchievementController.IncrementAchievement("PD");
			}
			if (other.transform.position.y < 29 && other.transform.position.y > 0) {
				AchievementController.IncrementAchievement("PU");
			}
			if (other.transform.position.y < 148 && other.transform.position.y > 90) {
				AchievementController.IncrementAchievement("PG");
			}
			if (other.transform.position.y < 180 && other.transform.position.y > 150) {
				AchievementController.IncrementAchievement("PM");
			}
			AudioSource.PlayClipAtPoint (catchs, this.transform.position, 9.0f);
		}
		
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("Exit");
			entered = false;
		}
		
	}
	
	
}
