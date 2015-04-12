using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Pickup") {
			Destroy (other.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
