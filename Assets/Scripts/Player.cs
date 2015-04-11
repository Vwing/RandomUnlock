using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float speed = 1.0f;

	void Start () 
	{

	}

	void Update ()
	{
		Vector3 walkDirection = new Vector3(Input.GetAxis("Horizontal"),0,0);
		transform.Translate(walkDirection * speed * Time.deltaTime);
	}
}