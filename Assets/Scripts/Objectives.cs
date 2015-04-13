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
	List<string> achieveList;
		//Debug.Log (achievements.Count);
	//this is the list of achivements still needed^, might have to build based on what/s complete, etc.
	public UnityEngine.UI.Button firstObj;
	public UnityEngine.UI.Button secondObj;
	public UnityEngine.UI.Button thirdObj;
	// Use this for initialization
	void Start () {
		achieveList = new List<string>(){};
		RefreshAchievements();
		firstObj.GetComponentInChildren<Text>().text = achieveList[0];
	}

	public void RefreshAchievements()
	{
		achieveList.Clear ();
		foreach(AchievementController.Achievement o in AchievementController.Objectives)
		{
			if(!o.unlocked)
				achieveList.Add (o.description);
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
	public void MinimizeObjectives(){
		//Debug.Log ("minimizing objectives?");
		secondObj.GetComponent<Image>().color = Color.clear;
		secondObj.GetComponentInChildren<Text>().text = "";
		thirdObj.GetComponent<Image>().color = Color.clear;
		thirdObj.GetComponentInChildren<Text> ().text = "";
	}
	// Update is called once per frame
	void Update () {
		RefreshAchievements ();
	}

}
