using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementController : MonoBehaviour 
{
	static string AchievementFilePath = "Text/achievements";
	static List<Achievement> FullAchievementList = new List<Achievement>();
	[HideInInspector]
	public static List<Achievement> AchievementList = new List<Achievement>();
	[HideInInspector]
	public static List<Achievement> Objectives = new List<Achievement>();
	
	public static int numAchievementsNeeded = 3;
	
	public class Achievement 
	{
		public string biome;
		public string trigger;
		public string description;
		public bool unlocked;
		public int count = 0;
		public string countNeeded;
		
		
		public Achievement(string loc, string trig, string text, string countNeed)
		{
			biome = loc;
			trigger = trig;
			description = text;
			countNeeded = countNeed;
			unlocked = false;
		}
	}
	
	
	static void LoadAllAchievements()
	{
		FullAchievementList.Clear ();
		TextAsset achtxt = Resources.Load (AchievementFilePath) as TextAsset;
		foreach(string line in achtxt.text.Split(new char[1]{'\n'}))
		{
			string[] achArr = line.Split (new char[1]{';'});
			FullAchievementList.Add (new Achievement(achArr[0], achArr[1], achArr[2], achArr[3]));
		}
	}
	
	public static void IncrementAchievement(string trigger)
	{
		for(int i = 0; i < Objectives.Count; ++i){
			if(Objectives[i].trigger == trigger){
				int count = ++Objectives[i].count;
				int needed = System.Convert.ToInt32(Objectives[i].countNeeded);
				if(count == needed){
					Objectives[i].unlocked = true;
				}
			}
		}
	}
	
	public static bool ObjectivesCompleted()
	{
		foreach(Achievement o in Objectives)
		{
			if(!o.unlocked)
				return false;
		}
		return true;
	}
	
	public static void LoadObjectives(string biome)
	{
		AchievementList.Clear();
		Objectives.Clear ();
		foreach(Achievement a in FullAchievementList)
		{
			if(a.biome == biome || a.biome == "A"){
				AchievementList.Add (a);
				a.unlocked = false;
				a.count = 0;
			}
		}
		GenerateRandomObjectives ();
	}
	
	static void GenerateRandomObjectives()
	{
		//Objectives.Clear();
		Shuffle (AchievementList);
		for(int i = 0; i < numAchievementsNeeded; ++i)
			Objectives.Add (AchievementList[i]);
	}
	
	static void Shuffle(List<Achievement> list)
	{
		int n = list.Count;
		for (int i = 0; i < n; ++i) {
			Achievement temp = list[i];
			int randomIndex = Random.Range(i, n);
			list[i] = list[randomIndex];
			list[randomIndex] = temp;
		}
	}
//
//		int n = list.Count;
//		//Random rnd = new Random();
//		while (n > 1) {
//			int k = (Random.Range(0, n) % n);
//			n--;
//			Achievement value = list[k];
//			list[k] = list[n];
//			list[n] = value;
//		}
	
	void Awake()
	{
		LoadAllAchievements ();
		LoadObjectives("M");
	}
	
	void Start () 
	{
	}
	
	void Update()
	{
		
	}
	
}
