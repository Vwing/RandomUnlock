using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementController : MonoBehaviour 
{
//	string AchievementFilePath = "Text/achievements";
//	List<Achievement> FullAchievementList = new List<Achievement>();
//	List<Achievement> AchievementList = new List<Achievement>();
//
//	public struct Achievement 
//	{
//		public string biome;
//		public string trigger;
//		public string description;
//		public bool unlocked = false;
//
//		public Achievement(string loc, string trig, string text)
//		{
//			biome = loc;
//			trigger = trig;
//			description = text;
//		}
//	}
//
//
//	void LoadAllAchievements()
//	{
//		TextAsset achtxt = Resources.Load (AchievementFilePath) as TextAsset;
//		foreach(string line in achtxt.text.Split(new char[1]{'\n'}))
//		{
//			string[] achArr = line.Split (new char[1]{';'});
//			FullAchievementList.Add (new Achievement(achArr[0], achArr[1], achArr[2]));
//		}
//	}
//
//	void LoadAchievements(string biome)
//	{
//		foreach(Achievement a in FullAchievementList)
//		{
//			if(a.biome == biome || a.biome == "A")
//				AchievementList.Add (a);
//		}
//	}
//
//	void ClearAchievements()
//	{
//		AchievementList.Clear();
//	}
//
//	void Awake()
//	{
//		LoadAllAchievements ();
//	}
//
//	void Start () 
//	{
//		LoadAllAchievements();
//	}

	void Update()
	{

	}

}
