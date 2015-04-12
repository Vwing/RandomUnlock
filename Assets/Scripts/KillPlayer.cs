using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag ("Player"))
			other.gameObject.GetComponent<Player>().Death();
	}
}