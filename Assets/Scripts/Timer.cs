using UnityEngine;
using System.Collections;
//using Math;
public class Timer : MonoBehaviour {
	public double startTime = 10.0;
	public double timeLeft = 0.0;
	public GUIText timer;
	public static int clocks = 3;
	public double clockValue = 10.0;
	
	// Use this for initialization
	void Start () {
		//StartCoroutine (countdown ());
		timeLeft = startTime;
		
		
		
	}
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		int secondsLeft = (int) timeLeft;
		int minutes = secondsLeft / 60;
		int seconds = secondsLeft % 60;
		string s = seconds.ToString();
		if(seconds < 10) {
			s = "0" + s;
		}
		
		timer.text = minutes.ToString() + ":" + s;
		if (timeLeft <= 0) {
			if(clocks != 0){
				clocks -= 1;
				timeLeft += clockValue;
			}
			else{
				Application.LoadLevel ("GameOver");
				timeLeft = 0.0;
			}
		}
		
		
		
	}
}
