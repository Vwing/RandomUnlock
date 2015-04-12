using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public GameObject followObject;
	float xPos;
	float yPos;

	void Start ()
	{
		yPos = transform.position.y;
	}
	
	void Update ()
	{	
		//if((xPos + 5.0 >= 150) && x
		xPos = followObject.transform.position.x;
		transform.position = new Vector3(xPos,yPos,-10.0f);
	}
}