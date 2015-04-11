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

	void Start ()
	{
		initPos = transform.position;
		targetPos = initPos + patrolDistance;
		direction = (targetPos - initPos).normalized;
	}
	
	void Update ()
	{
		if(transform.position.x >= targetPos.x){
			goingTowardsTarget = false;
		} else if(transform.position.x <= initPos.x){
			goingTowardsTarget = true;
		}
//		float magnitude = (transform.position - targetPos).magnitude;
//		if(transform.position - targetPos){
//			goingTowardsTarget = false;
//		} else if(transform.position.x <= initPos.x){
//			goingTowardsTarget = true;
//		}

		if(goingTowardsTarget)
			transform.Translate(direction * patrolSpeed * Time.deltaTime);
		else
			transform.Translate(-1.0f * direction * patrolSpeed * Time.deltaTime);
	}
}