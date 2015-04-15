using UnityEngine;
using System.Collections;

public class QuitToMain : MonoBehaviour
{
	void Start ()
	{
		
	}
	
	void Update ()
	{
		if(Input.GetButtonDown("Cancel"))
			Application.LoadLevel ("MainMenu");
	}
}