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

	public static int numAchivementsNeeded = 3;

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
				Debug.Log (count + ";" + Objectives[i].countNeeded + ": " + Objectives[i].trigger + " " + Objectives[i].description + " " + Objectives[i].unlocked);
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
		foreach(Achievement a in FullAchievementList)
		{
			if(a.biome == biome || a.biome == "A")
				AchievementList.Add (a);
		}
		GenerateRandomObjectives ();
	}

	static void GenerateRandomObjectives()
	{
		Objectives.Clear();
		Shuffle (AchievementList);
		for(int i = 0; i < numAchivementsNeeded; ++i)
			Objectives.Add (AchievementList[i]);
	}

	static void Shuffle(List<Achievement> list) {
		int n = list.Count;
		//Random rnd = new Random();
		while (n > 1) {
			int k = (Random.Range(0, n) % n);
			n--;
			Achievement value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}

	void Awake()
	{
		LoadAllAchievements ();
	}
	
	void Start () 
	{
		LoadObjectives("M");
	}

	void Update()
	{

	}

}
