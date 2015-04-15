using UnityEngine;
using System.Collections;

public class jumpShark : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			AchievementController.IncrementAchievement("SJ");
			AchievementController.IncrementAchievement("SM");
		}
	}
}