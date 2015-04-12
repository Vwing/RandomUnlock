using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
	public GUITexture clocktexture;
	public int clock_number;
	public Texture transparent; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer.clocks < clock_number) {
			Color texturecolor = GetComponent<GUITexture>().color;
			texturecolor.a = 0;
			clocktexture.color = texturecolor;
		}
	
	}
}
