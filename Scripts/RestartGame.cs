using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get (OVRInput.Button.One) && Time.timeSinceLevelLoad > 2) {
			SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
		}
	}
}
