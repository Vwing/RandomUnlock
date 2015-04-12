using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour
{
	Animator anim;
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	void Update ()
	{
		if(Input.GetButton ("Fire1"))
			anim.SetBool("jetOn",true);
		else
			anim.SetBool ("jetOn",false);
	}
}