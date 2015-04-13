using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class RegexTest : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		TestRegex();
	}
	
	void TestRegex()
	{
		string pattern = @"(^[a-zA-z]+)([\d]*)";
		string input = "Jammin456";

		Match match = Regex.Match(input, pattern);

		Debug.Log (match.Groups[1] + " " + match.Groups[2] + " " + match.Groups[3]);

	}
}
