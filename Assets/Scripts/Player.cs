using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float speed = 1.0f;
	public float jumpForce = 450.0f;
	public float jetForce = 1.0f;
	bool right = true;
	Transform sprite;
	Rigidbody2D rb;

	void Start () 
	{
		sprite = transform.FindChild("Sprite");
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		LateralMovement();
		if(Input.GetButtonDown ("Jump"))
			Jump ();
		if(Input.GetButton ("Fire1"))
			Jetpack ();
	}

	float xAxis;

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

	void Jump()
	{
		rb.AddForce (Vector3.up * jumpForce);
	}

	void Jetpack()
	{
		rb.AddForce(Vector3.up * jetForce);
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