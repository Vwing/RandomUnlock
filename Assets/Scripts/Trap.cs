using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
	public GameObject player;
	public GameObject mountainTrap;
	public GameObject grasslandTrap;
	public GameObject jungleTrap;
	public GameObject desertTrap;
	public GameObject urbanTrap;

	bool mRot = false;
	bool gRot = false;
	bool jRot = false;
	bool dRot = false;
	bool uRot = false;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		if(!AchievementController.ObjectivesCompleted())
			return;
		if(!mRot && player.GetComponent<Player>().biome == "M"){
			mountainTrap.transform.Rotate (0,0,90);
			mRot = true;
		}
		if(!gRot && player.GetComponent<Player>().biome == "G"){
			grasslandTrap.transform.Rotate (0,0,90);
			gRot = true;
		}
		if(!jRot && player.GetComponent<Player>().biome == "J"){
			jungleTrap.transform.Rotate (0,0,90);
			jRot = true;
		}
		if(!dRot && player.GetComponent<Player>().biome == "D"){
			desertTrap.transform.Rotate (0,0,90);
			dRot = true;
		}
		if(!uRot && player.GetComponent<Player>().biome == "U"){
			urbanTrap.transform.Rotate (0,0,90);
			uRot = true;
		}
	}
}