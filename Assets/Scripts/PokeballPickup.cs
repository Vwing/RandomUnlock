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
	private Player playerScript;

	void Awake()
	{
		playerScript = playerchar.GetComponent<Player> ();
	}
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
				if(!carried)
					AudioSource.PlayClipAtPoint (picksup, this.transform.position);
				carried = true;
				rb.velocity =  Vector2.zero;
				rb.isKinematic=true;
				cc.isTrigger = true;
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
			if (playerScript.biome == "J") {
				AchievementController.IncrementAchievement("PJ");
			}
			if (playerScript.biome == "D") {
				AchievementController.IncrementAchievement("PD");
			}
			if (playerScript.biome == "U") {
				AchievementController.IncrementAchievement("PU");
			}
			if (playerScript.biome == "G") {
				AchievementController.IncrementAchievement("PG");
			}
			if (playerScript.biome == "M") {
				AchievementController.IncrementAchievement("PM");
			}
			if(other.gameObject.name == "Duck")
				AchievementController.IncrementAchievement("PDG");
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
