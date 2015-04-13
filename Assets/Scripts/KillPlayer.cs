using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag ("Player"))
			other.gameObject.GetComponent<Player>().Death();
		AchievementController.IncrementAchievement("Die5");
		AchievementController.IncrementAchievement("Die10");
		if (other.transform.position.y < 90 && other.transform.position.y > 59) {
			AchievementController.IncrementAchievement("DJ");
		}
		if (other.transform.position.y < 59 && other.transform.position.y > 29) {
			AchievementController.IncrementAchievement("DD");
		}
		if (other.transform.position.y < 29 && other.transform.position.y > 0) {
			AchievementController.IncrementAchievement("DU");
		}
		if (other.transform.position.y < 148 && other.transform.position.y > 90) {
			AchievementController.IncrementAchievement("DG");
		}
		if (other.transform.position.y < 180 && other.transform.position.y > 150) {
			AchievementController.IncrementAchievement("DM");
		}
	}
}