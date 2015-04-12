using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour
{
	public Vector3 patrolDistance;
	public float patrolSpeed = 1.0f;

	Vector3 initPos;
	Vector3 targetPos;
	Vector3 direction;
	bool goingTowardsTarget = true;
	bool firstTime = true;

	void Start ()
	{
		initPos = transform.position;
		targetPos = initPos + patrolDistance;
		direction = (targetPos - initPos).normalized;
	}
	
	void FixedUpdate ()
	{
		if(Vector3.Dot (direction,targetPos - transform.position) <= 0){
			goingTowardsTarget = false;
			Flip();
		} 
		else if(Vector3.Dot (direction,initPos - transform.position) >= 0){
			goingTowardsTarget = true;
			Flip();
		}

		if(goingTowardsTarget)
			transform.Translate(direction * patrolSpeed * Time.deltaTime);
		else
			transform.Translate(-1.0f * direction * patrolSpeed * Time.deltaTime);
	}

	void Flip ()
	{
		// Multiply the player's x local scale by -1.
		if(!firstTime)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		else
		{
			firstTime = false;
		}
	}
}