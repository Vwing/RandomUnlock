using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float speed = 1.0f;
	bool right = true;
	float xAxis;
	Transform sprite;

	void Start () 
	{
		sprite = transform.FindChild("Sprite");
	}

	void Update ()
	{
		LateralMovement();
	}

	void LateralMovement()
	{
		xAxis = Input.GetAxis ("Horizontal");
		if(xAxis > 0 && !right || xAxis < 0 && right){
			right = !right;
			sprite.RotateAround(transform.position + Vector3.left * -0.5f, Vector3.up, 180);
		}
		Vector3 walkDirection = new Vector3(xAxis,0,0);
		transform.Translate(walkDirection * speed * Time.deltaTime);
	}
//	void Rotate180()
//	{
//		sprite.Rotate(Vector3.up * -180);
//		if(!right)
//			sprite.localPosition = Vector3.left * -1.0f;
//		else
//			sprite.localPosition = Vector3.zero;
//	}
}