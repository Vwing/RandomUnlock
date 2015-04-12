using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementController : MonoBehaviour 
{
	public string AchievementFilePath = "Text/achievements";
	public struct Achievement 
	{
		public string biome;
		public string trigger;
		public string description;

		public Achievement(string loc, string trig, string text)
		{
			biome = loc;
			trigger = trig;
			description = text;
		}
	}

	public List<Achievement> AchievementList = new List<Achievement>();

	void LoadAllAchievements()
	{
		TextAsset achtxt = Resources.Load (AchievementFilePath) as TextAsset;
		foreach(string line in achtxt.text.Split(new char[1]{'\n'}))
		{
			string[] achArr = line.Split (new char[1]{';'});
			AchievementList.Add (new Achievement(achArr[0], achArr[1], achArr[2]));
		}
	}

	void Start () 
	{
		LoadAllAchievements();
	}

}
