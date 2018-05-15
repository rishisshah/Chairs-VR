using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get (OVRInput.Button.One) && Time.timeSinceLevelLoad > 2) //prevent tapping fast
		{
			SceneManager.LoadScene ("VRScene", LoadSceneMode.Single);
		}
	}
}
