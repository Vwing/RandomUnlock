using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public float hoverValue;
	public float speed;

	public void Play(){
		Application.LoadLevel ("master");
	}
	public void Quit(){
		Application.Quit ();
	}

	public void FixedUpdate()
	{
		transform.position =  new Vector3(transform.position.x, hoverValue * Mathf.Sin (speed * Time.timeSinceLevelLoad), transform.position.z); 
	}
}
