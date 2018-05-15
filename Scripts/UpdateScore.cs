using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UpdateScore : MonoBehaviour {

	public Text tempText; 
	public GameObject inputInfo; 

	// Use this for initialization
	void Start () {
		tempText.text = "Score: 0"; 
	}
	
	// Update is called once per frame
	void Update () {
		
		ControllerInput script = inputInfo.GetComponent<ControllerInput> ();
		string scoreString = script.score.ToString ();
		tempText.text = "Score: " + scoreString; 
	}
}
