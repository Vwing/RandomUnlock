using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
/*public class Achievement {
	public Achievement(){}
	public Achievement(string todo, bool done){
		task = todo;
		complete = done;
	}
	public string task { get; set; }
	public bool complete { get; set; }

}*/
public class Objectives : MonoBehaviour {
	//List<string> achieveList = new List<string>(){};
		//Debug.Log (achievements.Count);
	//this is the list of achivements still needed^, might have to build based on what/s complete, etc.
	public UnityEngine.UI.Button firstObj;
	public UnityEngine.UI.Button secondObj;
	public UnityEngine.UI.Button thirdObj;
	public GameObject player;
	string oldBiome;
	Image firstImg;
	Image secondImg;
	Image thirdImg;
	Text txt1;
	Text txt2;
	Text txt3;

	bool firstComplete = false;
	bool secondComplete = false;
	bool thirdComplete = false;

	void Awake(){
		firstImg = firstObj.GetComponent<Image>();
		secondImg = secondObj.GetComponent<Image>();
		thirdImg = thirdObj.GetComponent<Image>();
		txt1 = firstObj.GetComponentInChildren<Text>();
		txt2 = secondObj.GetComponentInChildren<Text>();
		txt3 = thirdObj.GetComponentInChildren<Text>();
	}

	void Start () {
		NewAchievements ();
		oldBiome = player.GetComponent<Player> ().biome;
	}

	void Update () {
		if (oldBiome != player.GetComponent<Player> ().biome)
			NewAchievements ();
		RefreshAchievements ();
		oldBiome = player.GetComponent<Player> ().biome;
	}

	public void RefreshAchievements()
	{
		for(int i = 0; i < 3; ++i)
		{
			if(AchievementController.Objectives[i].unlocked)
				SetComplete(i);
		}
	}

	public void SetComplete(int position)
	{
		if(position == 0)
		{
			firstImg.color = Color.green;
		}
		else if(position == 1)
		{
			secondImg.color = Color.green;
		}
		else if(position == 2)
		{
			thirdImg.color = Color.green;
		}
		if(firstImg.color == Color.green && secondImg.color == Color.green && thirdImg.color == Color.green){
			txt1.text = "Area objectives complete, move to next biome";
			txt2.text = "";
			txt3.text = "";
		}
	}

	void NewAchievements()
	{
		//achieveList.Clear ();
		firstImg.color = Color.white;
		secondImg.color = Color.white;
		thirdImg.color = Color.white;
		
		txt1.text = AchievementController.Objectives [0].description;
		txt2.text = AchievementController.Objectives [1].description;
		txt3.text = AchievementController.Objectives [2].description;
	}
}
//
//		foreach(AchievementController.Achievement o in AchievementController.Objectives)
//		{
//			achieveList.Add (o.description);
//		}
//		for(int i = 0; i < 3; ++i)
//		{
//			achieveList.Add (AchievementController.Objectives[i]);
//		}
<<<<<<< HEAD
	
=======
	}

	public void RefreshAchievements()
	{
		txt1.text = AchievementController.Objectives[0].description;
		txt2.text = AchievementController.Objectives[1].description;
		txt3.text = AchievementController.Objectives[2].description;
		for(int i = 0; i < 3; ++i)
		{
			if(AchievementController.Objectives[i].unlocked)
				SetComplete(i);
		}
	}

	public void ExpandObjectives(){
		//Debug.Log ("expanding objectives????????");
		//Debug.Log (achieveList.Count);
		foreach(string i in achieveList){
		//Debug.Log(i);
	   }
		if (achieveList.Count < 1) {
			firstObj.GetComponent<Image>().color = Color.green;
			firstObj.GetComponentInChildren<Text>().text = "Area objectives complete, move to next biome";
		}
		else{
			firstObj.GetComponentInChildren<Text>().text = achieveList[0];
			if(achieveList.Count > 1){
				secondObj.GetComponentInChildren<Text>().text = achieveList[1];
				secondObj.GetComponent<Image>().color = Color.white;
			}
			if(achieveList.Count > 2){
				thirdObj.GetComponent<Image>().color = Color.white;
				thirdObj.GetComponentInChildren<Text>().text = achieveList[2];
			}
		}
	}
>>>>>>> 031526202495a771c6bb53d541303b95bcd2ae39

//	public void ExpandObjectives(){
//		//Debug.Log ("expanding objectives????????");
//		//Debug.Log (achieveList.Count);
//		foreach(string i in achieveList){
//		//Debug.Log(i);
//	   }
//		if (achieveList.Count < 1) {
//			firstObj.GetComponent<Image>().color = Color.green;
//			firstObj.GetComponentInChildren<Text>().text = "Area objectives complete, move to next biome";
//		}
//		else{
//			firstObj.GetComponentInChildren<Text>().text = achieveList[0];
//			if(achieveList.Count > 1){
//				secondObj.GetComponentInChildren<Text>().text = achieveList[1];
//				secondObj.GetComponent<Image>().color = Color.white;
//			}
//			if(achieveList.Count > 2){
//				thirdObj.GetComponent<Image>().color = Color.white;
//				thirdObj.GetComponentInChildren<Text>().text = achieveList[2];
//			}
//		}
//	}
//
//	public void MinimizeObjectives(){
//		//Debug.Log ("minimizing objectives?");
//		secondObj.GetComponent<Image>().color = Color.clear;
//		secondObj.GetComponentInChildren<Text>().text = "";
//		thirdObj.GetComponent<Image>().color = Color.clear;
//		thirdObj.GetComponentInChildren<Text> ().text = "";
//	}
	// Update is called once per frame
