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
	public float throwVelx;
	public float throwVely;

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
				this.transform.position = playerchar.transform.position - offset;
			rb.isKinematic = false;

		}
		if (entered) {
			Debug.Log("HI");
			if (Input.GetButtonDown ("Fire2")) {
				Debug.Log("HI2");
				carried = true;
				rb.velocity =  Vector2.zero;
				rb.isKinematic=true;
				cc.isTrigger = true;

			}
		}
		if (carried) {
			if(Input.GetButtonDown ("Fire3"))
			{
				carried = false;
				if(playerchar.transform.localScale.x >0)
				{
					this.transform.position = playerchar.transform.position + new Vector3(1,0,0);
					rb.velocity = new Vector2(throwVelx,throwVely);
				}
				else
				{
					this.transform.position = playerchar.transform.position - new Vector3(1,0,0);
					rb.velocity = new Vector2(-throwVelx,-throwVely);
				}
				rb.isKinematic = false;
				cc.isTrigger = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Entered");
			entered = true;
			}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Exit");
			entered = false;
			}

	}

	
}
