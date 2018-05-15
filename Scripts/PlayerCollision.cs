using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {


	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Enemy")) 
		{
			SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
		}
	}
}
