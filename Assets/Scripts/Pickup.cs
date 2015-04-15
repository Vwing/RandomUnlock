using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	Player player;
	public AudioClip pickupS;

	void Start ()
	{
		player = GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Pickup") {
			if(other.gameObject.name == "Snowman" && player.biome == "M")
				AchievementController.IncrementAchievement("PSM");
			if(other.gameObject.name == "Snowman" && player.biome == "G")
				AchievementController.IncrementAchievement("PSG");
			if(other.gameObject.name == "Apple") // && player.biome == "G"
				AchievementController.IncrementAchievement("PAG");
			if(other.gameObject.name == "Briefcase") // && player.biome == "U"
				AchievementController.IncrementAchievement("PBU");
			if(other.gameObject.name == "Monument") // && player.biome == "J"
				AchievementController.IncrementAchievement("PMJ");
			if(other.gameObject.name == "Pyramid") // && player.biome == "D"
				AchievementController.IncrementAchievement("PPD");

			AudioSource.PlayClipAtPoint(pickupS,other.transform.position, 0.4f);
			Destroy (other.gameObject);
		}
	}
}
