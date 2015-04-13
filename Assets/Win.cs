using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Win : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player") && AchievementController.ObjectivesCompleted()) { // && AchievementController.ObjectivesCompleted()
			
			Application.LoadLevel ("win");
		}
	}

}
