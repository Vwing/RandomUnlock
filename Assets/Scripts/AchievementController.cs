using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementController : MonoBehaviour 
{
	string AchievementFilePath = "Text/achievements";
	List<Achievement> FullAchievementList = new List<Achievement>();
	[HideInInspector]
	public List<Achievement> AchievementList = new List<Achievement>();
	[HideInInspector]
	public List<Achievement> Objectives = new List<Achievement>();

	public int numAchivementsNeeded = 5;

	public struct Achievement 
	{
		public string biome;
		public string trigger;
		public string description;
		public bool unlocked;

		public Achievement(string loc, string trig, string text)
		{
			biome = loc;
			trigger = trig;
			description = text;
			unlocked = false;
		}
	}


	void LoadAllAchievements()
	{
		TextAsset achtxt = Resources.Load (AchievementFilePath) as TextAsset;
		foreach(string line in achtxt.text.Split(new char[1]{'\n'}))
		{
			string[] achArr = line.Split (new char[1]{';'});
			FullAchievementList.Add (new Achievement(achArr[0], achArr[1], achArr[2]));
		}
	}

	void LoadObjectives(string biome)
	{
		AchievementList.Clear();
		foreach(Achievement a in FullAchievementList)
		{
			if(a.biome == biome || a.biome == "A")
				AchievementList.Add (a);
		}
		GenerateRandomObjectives ();
	}

	void GenerateRandomObjectives()
	{
		Objectives.Clear();
		Shuffle (AchievementList);
		for(int i = 0; i < numAchivementsNeeded; ++i)
			Objectives.Add (AchievementList[i]);

//		int count = AchievementList.Count;
//		int needed = numAchivementsNeeded - 1;
//		for(int i = 0; i < count; ++i)
//		{
//			if(Random.Range (needed, count - i) <= needed){
//				Objectives.Add (AchievementList[i]);
//				--needed;
//			}
//		}
	}

	void Shuffle(List<Achievement> list) {
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
		foreach(Achievement o in Objectives)
			Debug.Log (o.description);
	}

	void Update()
	{

	}

}
